using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Expect.Open.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsSampleApp1.Properties
{
    public partial class EmployeeForm1 : Form
    {
        private dbRepository dbRepo = new dbRepository();
        private string _employeeEmail;

        public EmployeeForm1(string email)
        {
            InitializeComponent();
            _employeeEmail = email;
        }

        private void EmployeeForm1_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
            LoadProductData();
            LoadRentalSummary();

            // Fetch No Unit (from the inventory table)
            int unitTotalCount = dbRepo.GetUnitTotal();

            // Fetch No Rented Unit (from the inventory table)
            int unitTotalRentedCount = dbRepo.GetUnitRentedTotal();

            // Fetch No Available Unit (from the inventory table)
            int availableUnit = dbRepo.GetAvlUnit();

            string employee_name = dbRepo.GetEmployeeName(_employeeEmail);

            NoUnit.Text = $"{unitTotalCount}";
            NoRentedUnit.Text = $"{unitTotalRentedCount}";
            NoAvlUnit.Text = $"{availableUnit}";
            EmpName.Text = $"{employee_name}";

            // Update the circular progress bar
            circularProgressBar1.Maximum = unitTotalCount; // Set the maximum value
            circularProgressBar1.Value = unitTotalRentedCount; // Set the current value

        }


        private void ITEMS_Click(object sender, EventArgs e)
        {
            EmployeeForm1 employeeForm = new EmployeeForm1(_employeeEmail);
            employeeForm.Show();
            this.Hide();
        }

        private void TENANT_Click(object sender, EventArgs e)
        {
            EmployeeForm3TNT employeeForm3 = new EmployeeForm3TNT(_employeeEmail);
            employeeForm3.Show();
            this.Hide();
        }

        private void TRANSACTION_Click(object sender, EventArgs e)
        {
            EmployeeForm4TANS employeeForm4 = new EmployeeForm4TANS(_employeeEmail);
            employeeForm4.Show();
            this.Hide();
        }

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the current employee email from the repository
                string currentEmail = _employeeEmail;

                if (!string.IsNullOrEmpty(currentEmail))
                {
                    // Update status to offline
                    bool success = dbRepo.SetEmployeeOffline(currentEmail);

                    if (!success)
                    {
                        MessageBox.Show("Failed to update logout status.", "Warning",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Navigate to Login
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (dataGridViewINV.Columns.Contains("product_id"))
                    dataGridViewINV.Columns["product_id"].Visible = false;

                // Add Action Button Column if not already added
                if (!dataGridViewINV.Columns.Contains("ActionColumn"))
                {
                    DataGridViewButtonColumn actionColumn = new DataGridViewButtonColumn
                    {
                        Name = "ActionColumn",
                        HeaderText = "Action",
                        Text = "Action",
                        UseColumnTextForButtonValue = false // Uses cell value as button text
                    };
                    dataGridViewINV.Columns.Add(actionColumn);
                }

                // Update button text based on status
                foreach (DataGridViewRow row in dataGridViewINV.Rows)
                {
                    if (row.IsNewRow) continue;

                    string status = row.Cells["status"].Value?.ToString().ToLower();

                    switch (status)
                    {
                        case "available":
                            row.Cells["ActionColumn"].Value = "Rent";
                            break;
                        case "rented":
                            row.Cells["ActionColumn"].Value = "Return";
                            break;
                        case "maintenance":
                            row.Cells["ActionColumn"].Value = "Make Available";
                            break;
                        default:
                            row.Cells["ActionColumn"].Value = "";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRentalSummary(string searchTerm = null)
        {
            try
            {
                // Fetch rental history data from the database
                DataTable rentalRentaSummarylData = dbRepo.GetRentaSummary(searchTerm);

                // Bind the data to the DataGridView first
                dataGridViewItemSummary.DataSource = rentalRentaSummarylData;

                // Now it's safe to modify column visibility
                if (dataGridViewItemSummary.Columns.Contains("product_id"))
                {
                    dataGridViewItemSummary.Columns["product_id"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rental history data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridViewINV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            // Ignore clicks on header or invalid rows
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Only handle clicks in the ActionColumn
            if (senderGrid.Columns[e.ColumnIndex].Name != "ActionColumn") return;

            // Get the clicked row data
            DataGridViewRow row = senderGrid.Rows[e.RowIndex];
            string productId = row.Cells["id"].Value?.ToString();
            string currentStatus = row.Cells["status"].Value?.ToString()?.ToLower();
            string buttonText = row.Cells["ActionColumn"].Value?.ToString();

            // Handle Rent button click
            if (buttonText?.Equals("Rent", StringComparison.OrdinalIgnoreCase) == true)
            {
                ShowRentDialog(productId);
            }
            // Handle Return button click
            else if (buttonText?.Equals("Return", StringComparison.OrdinalIgnoreCase) == true)
            {
                // Implement return logic here
                ReturnProduct(productId);
            }
            // Handle Available button click
            else if (buttonText?.Equals("Make Available", StringComparison.OrdinalIgnoreCase) == true)
            {
                // Implement available logic here
                MarkAsAvailable(productId);
            }
        }

        private void ShowRentDialog(string productId)
        {
            try
            {
                MessageBox.Show($"Attempting to rent product with ID: {productId}",
                      "Product Information",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Information);

                // Get product details
                DataRow inventoryDetails = dbRepo.GetInventoryDetails(productId);
                if (inventoryDetails == null)
                {
                    MessageBox.Show("Product details not found.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get tenants list
                DataTable tenants = dbRepo.GetTenantData();
                if (tenants == null || tenants.Rows.Count == 0)
                {
                    MessageBox.Show("No tenants available.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Create and configure the dialog form
                using (Form rentDialog = new Form()
                {
                    Width = 400,
                    Height = 300,
                    Text = "Rent Product",
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                })
                {
                    // Create and configure controls
                    TextBox txtDetails = new TextBox()
                    {
                        Text = $"Product: {inventoryDetails["product_name"]}\r\n" +
                               $"Serial: {inventoryDetails["serial_number"]}\r\n" +
                               $"Description: {inventoryDetails["description"]}\r\n" +
                               $"Condition: {inventoryDetails["current_condition"]}\r\n" +
                               $"Size: {inventoryDetails["size"]}\r\n" +
                               $"Duration: {inventoryDetails["price_unit"]}\r\n" +
                               $"Price :  ₱{inventoryDetails["base_price"]}",
                        Multiline = true,
                        ReadOnly = true,
                        ScrollBars = ScrollBars.Vertical,
                        Dock = DockStyle.Top,
                        Height = 120
                    };

                    Label lblTenant = new Label()
                    {
                        Text = "Select Tenant:",
                        Dock = DockStyle.Top,
                        Height = 40
                    };

                    ComboBox tenantCombo = new ComboBox()
                    {
                        Dock = DockStyle.Top,
                        DisplayMember = "full_name",
                        ValueMember = "tenant_id",
                        DataSource = tenants,
                        DropDownStyle = ComboBoxStyle.DropDownList
                    };

                    Button btnConfirm = new Button()
                    {
                        Text = "Confirm Rent",
                        Dock = DockStyle.Bottom,
                        Height = 40,
                        Width = 50,
                        DialogResult = DialogResult.OK
                    };

                    // Handle confirm button click
                    btnConfirm.Click += (s, ev) =>
                    {
                        if (tenantCombo.SelectedValue == null)
                        {
                            MessageBox.Show("Please select a tenant", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        DataRowView selectedTenant = (DataRowView)tenantCombo.SelectedItem;
                        string tenantId = selectedTenant["id"].ToString();
                        string duration = inventoryDetails["price_unit"].ToString();
                        string priceUnit = inventoryDetails["base_price"].ToString();
                        string serialNumber = inventoryDetails["serial_number"].ToString();
                        string condition = inventoryDetails["current_condition"].ToString();
                        RentProduct(productId, tenantId, priceUnit, duration, serialNumber, condition);
                    };

                    // Add controls to form
                    rentDialog.Controls.Add(btnConfirm);
                    rentDialog.Controls.Add(tenantCombo);
                    rentDialog.Controls.Add(lblTenant);
                    rentDialog.Controls.Add(txtDetails);

                    // Show dialog
                    if (rentDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        // Refresh data after successful operation
                        LoadInventoryData();
                        LoadProductData();
                        LoadRentalSummary();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error showing rent dialog: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RentProduct(string productId, string tenantId, string priceUnit, string duration, string serialNumber, string condition)
        {
            try
            {
                if (dbRepo.RentProduct(productId, tenantId, _employeeEmail, priceUnit, duration, serialNumber, condition))
                {
                    MessageBox.Show("Product rented successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to rent product", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error renting product: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReturnProduct(string productId)
        {
            try
            {
                if (dbRepo.ReturnProduct(productId))
                {
                    MessageBox.Show("Product return successfully!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh data after successful operation
                    LoadInventoryData();
                    LoadProductData();
                    LoadRentalSummary();
                }
                else
                {
                    MessageBox.Show("Failed to return the product", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning product: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MarkAsAvailable(string productId)
        {
            try
            {
                if (dbRepo.MarkAvailableProduct(productId))
                {
                    MessageBox.Show("Product is available!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Refresh data after successful operation
                    LoadInventoryData();
                    LoadProductData();
                    LoadRentalSummary();
                }
                else
                {
                    MessageBox.Show("Failed to mark the product available", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product as available: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SearchBtm_Click(object sender, EventArgs e)
        {
            // Get the search term from the SearchBox
            string searchTerm = SearchBox.Text.Trim();

            // Reload the data with the search term
            LoadInventoryData(searchTerm);
            LoadProductData(searchTerm);

        }

        private void RENTALSbutton_Click(object sender, EventArgs e)
        {
            EmployeeForm2RNT employeeForm2 = new EmployeeForm2RNT(_employeeEmail);
            employeeForm2.Show();
            this.Hide();
        }
    }
}
