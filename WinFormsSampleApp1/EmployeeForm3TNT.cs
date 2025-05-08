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
    public partial class EmployeeForm3TNT : Form
    {
        private dbRepository dbRepo = new dbRepository();
        private string _employeeEmail;

        public EmployeeForm3TNT(string employeeEmail)
        {
            InitializeComponent();
            _employeeEmail = employeeEmail;
            openFileDialog1 = new OpenFileDialog();
            SearchBtmTenant.Click += SearchBtmTenant_Click;
            dataGridViewTenant.CellClick += dataGridViewTenant_CellClick;
        }

        private void EmployeeForm3TNT_Load(object sender, EventArgs e)
        {
            try
            {
                if (dbRepo == null)
                    throw new Exception("dbRepo is not initialized!");

                int tenantCount = dbRepo.GetTenantNo();
                TenantNo.Text = $"{tenantCount}";
                LoadTenantData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ITEMS_Click(object sender, EventArgs e)
        {
            EmployeeForm1 employeeForm = new EmployeeForm1(_employeeEmail);
            employeeForm.Show();
            this.Hide();
        }

        private void RENTALSbutton_Click(object sender, EventArgs e)
        {
            EmployeeForm2RNT employeeForm2 = new EmployeeForm2RNT(_employeeEmail);
            employeeForm2.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void InsertGovIdBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog1.FileName);
            }
        }

        private void LoadTenantData(string searchTerm = null)
        {
            try
            {
                // Fetch inventory data from the database
                DataTable tenantData = dbRepo.GetTenantData(searchTerm);

                // Bind the data to the DataGridView
                dataGridViewTenant.DataSource = tenantData;
                dataGridViewTenant.Columns["id_copy_path"].Visible = false;
                dataGridViewTenant.Columns["created_at"].Visible = false;

                // Add Update and Delete button columns
                if (!dataGridViewTenant.Columns.Contains("Update"))
                {
                    DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn
                    {
                        Name = "Update",
                        HeaderText = "Update",
                        Text = "Update",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewTenant.Columns.Add(updateColumn);
                }

                if (!dataGridViewTenant.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewTenant.Columns.Add(deleteColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading inventory data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTenant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row and not the header
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewTenant.Rows[e.RowIndex];

                // Extract data from the selected row
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value); // Assuming 'id' is the primary key
                string fullName = selectedRow.Cells["full_name"].Value?.ToString();
                string email = selectedRow.Cells["email"].Value?.ToString();
                string mobile = selectedRow.Cells["mobile"].Value?.ToString();

                // Check which button was clicked
                if (dataGridViewTenant.Columns[e.ColumnIndex].Name == "Update")
                {
                    // Open the Update dialog
                    OpenUpdateDialogTenant(id, fullName, email, mobile);
                }
                else if (dataGridViewTenant.Columns[e.ColumnIndex].Name == "Delete")
                {
                    // Show the Delete confirmation dialog
                    DeleteTenant(id, fullName);
                }
            }
        }


        private void OpenUpdateDialogTenant(int id, string currentFullName, string currentEmail, string currentMobile)
        {
            using (Form updateForm = new Form())
            {
                updateForm.Text = $"Update Tenant: {currentFullName}";
                updateForm.StartPosition = FormStartPosition.CenterParent;
                updateForm.Size = new System.Drawing.Size(400, 250);

                // Full Name Label and TextBox
                Label fullNameLabel = new Label { Text = "Full Name:", Location = new System.Drawing.Point(20, 20) };
                TextBox fullNameTextBox = new TextBox
                {
                    Text = currentFullName,
                    Location = new System.Drawing.Point(120, 20),
                    Width = 200
                };

                // Email Label and TextBox
                Label emailLabel = new Label { Text = "Email:", Location = new System.Drawing.Point(20, 60) };
                TextBox emailTextBox = new TextBox
                {
                    Text = currentEmail,
                    Location = new System.Drawing.Point(120, 60),
                    Width = 200
                };

                // Mobile Label and TextBox
                Label mobileLabel = new Label { Text = "Mobile:", Location = new System.Drawing.Point(20, 100) };
                TextBox mobileTextBox = new TextBox
                {
                    Text = currentMobile,
                    Location = new System.Drawing.Point(120, 100),
                    Width = 200
                };

                // Update Button
                Button updateButton = new Button { Text = "Update", Location = new System.Drawing.Point(150, 150), Width = 100 };
                updateButton.Click += (sender, e) =>
                {
                    // Validate inputs
                    string newFullName = fullNameTextBox.Text.Trim();
                    string newEmail = emailTextBox.Text.Trim();
                    string newMobile = mobileTextBox.Text.Trim();

                    if (string.IsNullOrEmpty(newFullName) || string.IsNullOrEmpty(newEmail) || string.IsNullOrEmpty(newMobile))
                    {
                        MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Call the repository method to update the tenant
                    bool success = dbRepo.UpdateTenant(id, newFullName, newEmail, newMobile);
                    if (success)
                    {
                        MessageBox.Show("Tenant updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTenantData(); // Refresh the DataGridView
                        updateForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update tenant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Add controls to the form
                updateForm.Controls.AddRange(new Control[] { fullNameLabel, fullNameTextBox, emailLabel, emailTextBox, mobileLabel, mobileTextBox, updateButton });

                // Show the form
                updateForm.ShowDialog();
            }
        }

        private void DeleteTenant(int id, string fullName)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete tenant: {fullName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Call the repository method to delete the tenant
                bool success = dbRepo.DeleteTenant(id);
                if (success)
                {
                    MessageBox.Show("Tenant deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTenantData(); // Refresh the DataGridView
                }
                else
                {
                    MessageBox.Show("Failed to delete tenant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SearchBtmTenant_Click(object sender, EventArgs e)
        {
            // Get the search term from the SearchTenant text box
            string searchTerm = SearchTenant.Text.Trim();

            // Load tenant data with the search term
            LoadTenantData(searchTerm);
        }

        private void InsertTenantbutton_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Validate input fields
                string fullName = TNTnametextBox.Text.Trim();
                string email = TNTemailtextBox.Text.Trim();
                string mobile = TNTmobileNotextBox.Text.Trim();
                string governmentId = TNTgivIDnotextBox.Text.Trim();

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(governmentId))
                {
                    MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 2: Handle the government ID image upload
                string govIdImagePath = SaveGovernmentIdImage(governmentId);

                if (string.IsNullOrEmpty(govIdImagePath))
                {
                    MessageBox.Show("Failed to save government ID image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 3: Insert tenant data into the database
                bool success = dbRepo.InsertTenant(fullName, governmentId, govIdImagePath, email, mobile);

                if (success)
                {
                    MessageBox.Show("Tenant inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields(); // Clear the input fields after successful insertion
                    LoadTenantData();
                }
                else
                {
                    MessageBox.Show("Failed to insert tenant.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting tenant: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string SaveGovernmentIdImage(string fileName)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the file extension of the selected image
                string fileExtension = Path.GetExtension(openFileDialog1.FileName);

                // Combine the provided file name with the file extension
                string destinationFileName = $"{fileName}{fileExtension}";

                // Define the full path to save the file
                string destinationPath = Path.Combine(@"C:\Users\Tripulca\source\repos\WinFormsSampleApp1\WinFormsSampleApp1\Resources\GovId", destinationFileName);

                try
                {
                    // Copy the file to the destination directory
                    File.Copy(openFileDialog1.FileName, destinationPath, overwrite: true);
                    return destinationPath; // Return the path to the saved image
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving government ID image: " + ex.Message);
                    return null;
                }
            }
            return null; // Return null if no file was selected
        }

        private void ClearInputFields()
        {
            TNTnametextBox.Clear();
            TNTemailtextBox.Clear();
            TNTmobileNotextBox.Clear();
            TNTgivIDnotextBox.Clear();
        }

        private void InsertGovIdBtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                string governmentId = TNTgivIDnotextBox.Text.Trim();

                // Step 2: Handle the government ID image upload
                string govIdImagePath = SaveGovernmentIdImage(governmentId);

                if (string.IsNullOrEmpty(govIdImagePath))
                {
                    MessageBox.Show("Failed to save government ID image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting tenant: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
