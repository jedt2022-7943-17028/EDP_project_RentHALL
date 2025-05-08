using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSampleApp1.Properties;

namespace WinFormsSampleApp1
{
    public partial class AdminForm2INV : Form
    {
        private dbRepository dbRepo = new dbRepository();

        public AdminForm2INV()
        {
            InitializeComponent();
            dataGridViewINV.CellClick += dataGridViewINV_CellClick;
        }

        private void AdminForm2INV_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
            LoadProductData();
            LoadProductTypes();
        }

        private void LoadInventoryData(string searchTerm = null)
        {
            try
            {
                // Fetch inventory data from the database
                DataTable inventoryData = dbRepo.GetInventoryData(searchTerm);

                // Bind the data to the DataGridView
                dataGridViewINV.DataSource = inventoryData;

                // Remove unwanted columns
                dataGridViewINV.Columns["product_id"].Visible = false;

                // Add Update and Delete button columns
                if (!dataGridViewINV.Columns.Contains("Update"))
                {
                    DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn
                    {
                        Name = "Update",
                        HeaderText = "Update",
                        Text = "Update",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewINV.Columns.Add(updateColumn);
                }

                if (!dataGridViewINV.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewINV.Columns.Add(deleteColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewINV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row and not the header
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewINV.Rows[e.RowIndex];

                // Extract data from the selected row
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value); // Assuming 'id' is the primary key
                string serialNumber = selectedRow.Cells["serial_number"].Value?.ToString();
                string size = selectedRow.Cells["size"].Value?.ToString();
                string status = selectedRow.Cells["status"].Value?.ToString();

                // Check which button was clicked
                if (dataGridViewINV.Columns[e.ColumnIndex].Name == "Update")
                {
                    // Open the Update dialog
                    OpenUpdateDialog(id, serialNumber, size, status);
                }
                else if (dataGridViewINV.Columns[e.ColumnIndex].Name == "Delete")
                {
                    // Show the Delete confirmation dialog
                    DeleteInventoryItem(serialNumber, id);
                }
            }
        }

        private void OpenUpdateDialog(int id, string serialNumber, string currentSize, string currentStatus)
        {
            using (Form updateForm = new Form())
            {
                updateForm.Text = $"Update Inventory Item: {serialNumber}";
                updateForm.StartPosition = FormStartPosition.CenterParent;
                updateForm.Size = new System.Drawing.Size(400, 250);

                // Size Label and TextBox
                Label sizeLabel = new Label { Text = "Size:", Location = new System.Drawing.Point(20, 20) };
                TextBox sizeTextBox = new TextBox { Text = currentSize, Location = new System.Drawing.Point(120, 20), Width = 200 };

                // Status Label and ComboBox
                Label statusLabel = new Label { Text = "Status:", Location = new System.Drawing.Point(20, 60) };
                ComboBox statusComboBox = new ComboBox
                {
                    Items = { "available", "maintenance" },
                    SelectedItem = currentStatus,
                    Location = new System.Drawing.Point(120, 60),
                    Width = 200
                };

                // Update Button
                Button updateButton = new Button { Text = "Update", Location = new System.Drawing.Point(120, 120), Width = 100 };
                updateButton.Click += (sender, e) =>
                {
                    // Validate inputs
                    string newSize = sizeTextBox.Text.Trim();
                    string newStatus = statusComboBox.SelectedItem?.ToString();

                    if (string.IsNullOrEmpty(newSize) || string.IsNullOrEmpty(newStatus))
                    {
                        MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Call the repository method to update the item
                    bool success = dbRepo.UpdateInventoryItem(id, newSize, newStatus);
                    if (success)
                    {
                        MessageBox.Show("Item updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadInventoryData();// Refresh the DataGridView
                        LoadProductData();
                        updateForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Add controls to the form
                updateForm.Controls.AddRange(new Control[] { sizeLabel, sizeTextBox, statusLabel, statusComboBox, updateButton });

                // Show the form
                updateForm.ShowDialog();
            }
        }

        private void DeleteInventoryItem(string serialNumber, int id)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete inventory: {serialNumber}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Call the repository method to delete the item
                bool success = dbRepo.DeleteInventoryItem(id);
                if (success)
                {
                    MessageBox.Show("Item deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reload the dataGrid
                    LoadInventoryData();
                    LoadProductData();
                }
                else
                {
                    MessageBox.Show("Failed to delete item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadProductData(string searchTerm = null)
        {
            try
            {
                // Fetch product data from the database
                DataTable productData = dbRepo.GetProductData(searchTerm);

                // Bind the data to the DataGridView
                dataGridViewProd.DataSource = productData;

                // Remove unwanted columns
                dataGridViewProd.Columns["business_id"].Visible = false; // Hide the 'business_id' column
                dataGridViewProd.Columns["product_type_id"].Visible = false; // Hide the 'product_type_id' column
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DASHBOARD_Click(object sender, EventArgs e)
        {
            // Navigate to AdminForm1
            AdminForm1 adminForm1 = new AdminForm1();
            adminForm1.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void INVENTORY_Click(object sender, EventArgs e)
        {
            WindowManager.ReloadWindow("AdminForm2INV");
        }

        private void RENTALS_Click(object sender, EventArgs e)
        {
            // Navigate to AdminFform1
            AdminForm3RNT adminForm3 = new AdminForm3RNT();
            adminForm3.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void TENANT_Click(object sender, EventArgs e)
        {
            // Navigate to AdminFform1
            AdminForm4TNT adminForm4 = new AdminForm4TNT();
            adminForm4.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void EMPLOYEES_Click(object sender, EventArgs e)
        {
            // Navigate to AdminFform1
            AdminForm5EMPY adminForm5 = new AdminForm5EMPY();
            adminForm5.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void TRANSACTION_Click(object sender, EventArgs e)
        {
            // Navigate to AdminFform1
            AdminForm6TRS adminForm6 = new AdminForm6TRS();
            adminForm6.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            // Navigate to Login
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SearchBtm_Click(object sender, EventArgs e)
        {
            // Get the search term from the SearchBox
            string searchTerm = SearchBox.Text.Trim();

            // Reload the data with the search term
            LoadInventoryData(searchTerm);
            LoadProductData(searchTerm);
        }

        private void SbtCateg_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values from the form controls
                string typeName = textBoxType.Text.Trim();
                string prdCode = textBoxCode.Text.Trim();
                string productName = textBoxProd.Text.Trim();
                string description = richTextBoxDescription.Text.Trim();
                decimal basePrice = Convert.ToDecimal(textBoxbasePrice.Text.Trim());
                string priceUnit = comboBoxDuration.SelectedItem.ToString(); // Ensure this is a valid ENUM value

                // Validate inputs
                if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(prdCode) ||
                    string.IsNullOrEmpty(productName) || string.IsNullOrEmpty(description) ||
                    basePrice <= 0 || string.IsNullOrEmpty(priceUnit))
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 1: Insert into product_type table and get the product_type_id
                int productTypeId = dbRepo.InsertProductType(typeName, prdCode);

                if (productTypeId == -1)
                {
                    MessageBox.Show("Failed to insert product type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Insert into product table using the product_type_id
                int product = dbRepo.InsertProduct(productTypeId, productName, description, basePrice, priceUnit);

                if (product == -1)
                {
                    MessageBox.Show("Failed to insert product details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Success message
                MessageBox.Show("Product and Product Type added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadInventoryData();// Refresh the DataGridView
                LoadProductData();

                // Optionally, clear the input fields
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            textBoxType.Clear();
            textBoxCode.Clear();
            textBoxProd.Clear();
            textBoxsize.Clear();
            richTextBoxDescription.Clear();
            textBoxbasePrice.Clear();
            comboBoxDuration.SelectedIndex = -1;
        }

        private void LoadProductTypes()
        {
            try
            {
                // Fetch product types from the database
                DataTable productTypes = dbRepo.GetProductTypes();

                // Bind the data to the ComboBox
                comboBoxCateg.DataSource = productTypes;
                comboBoxCateg.DisplayMember = "type_name";
                comboBoxCateg.ValueMember = "prd_code";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddINV_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the selected prd_code from comboBoxCateg
                var selectedItem = comboBoxCateg.SelectedItem as dynamic;
                if (selectedItem == null)
                {
                    MessageBox.Show("Please select a product category.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string prdCode = selectedItem["prd_code"].ToString();
                string size = textBoxsize.Text.Trim();

                // Validate inputs
                if (string.IsNullOrEmpty(size))
                {
                    MessageBox.Show("Please enter a valid size.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Generate a new serial_number
                string serialNumber = dbRepo.GenerateSerialNumber(prdCode);
                if (string.IsNullOrEmpty(serialNumber))
                {
                    MessageBox.Show("Failed to generate serial number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the product_id using the prd_code
                int productId = dbRepo.GetProductIdByPrdCode(prdCode);
                if (productId == -1)
                {
                    MessageBox.Show("Failed to retrieve product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Debug: Show values before insertion
                //string debugInfo = $"DEBUG VALUES BEFORE INSERT:\n" +
                //                  $"ProductId: {productId}\n" +
                //                  $"serialNumber: {serialNumber}\n" +
                //                  $"size: {size}";

                //MessageBox.Show(debugInfo, "Debug Information",
                //              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Insert the new inventory item
                int success = dbRepo.InsertInventoryItem(productId, serialNumber, size);

                if (success == -1)
                {
                    MessageBox.Show("Failed to insert to inventory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Success message
                MessageBox.Show("Inventory item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProductData();
                LoadInventoryData();

                // Optionally, clear the input fields
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding inventory item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
