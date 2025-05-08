using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;


namespace WinFormsSampleApp1.Properties
{
    public partial class AdminForm5EMPY : Form
    {
        private dbRepository dbRepo = new dbRepository();

        public AdminForm5EMPY()
        {
            InitializeComponent();
            LoadEmployeeData();
            dataGridViewEmployee.CellFormatting += dataGridViewEmployee_CellFormatting;
            dataGridViewEmployee.CellClick += dataGridViewEmployee_CellClick;

        }

        private void AdminForm5EMPY_Load(object sender, EventArgs e)
        {
            // Fetch No Employee (from the employee table)
            var employeeCount = dbRepo.GetEmpNo();

            EmpNo.Text = $"{employeeCount.EmpCount}";
            EmpAct.Text = $"{employeeCount.ActCount}";

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

            // Navigate to AdminFform1
            AdminForm2INV adminForm2 = new AdminForm2INV();
            adminForm2.Show();

            // Optionally, hide the current login form
            this.Hide();
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
            WindowManager.ReloadWindow("AdminForm5EMPY");

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

        private void LoadEmployeeData(string searchTerm = null)
        {
            try
            {
                // Fetch inventory data from the database
                DataTable employeeData = dbRepo.GetEmployeeData(searchTerm);

                // Bind the data to the DataGridView
                dataGridViewEmployee.DataSource = employeeData;
                dataGridViewEmployee.Columns["id"].Visible = false;
                dataGridViewEmployee.Columns["business_id"].Visible = false;
                dataGridViewEmployee.Columns["created_at"].Visible = false;

                dataGridViewEmployee.Columns["email"].HeaderText = "username";

                dataGridViewEmployee.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                // Add Update and Delete button columns
                if (!dataGridViewEmployee.Columns.Contains("Update"))
                {
                    DataGridViewButtonColumn updateColumn = new DataGridViewButtonColumn
                    {
                        Name = "Update",
                        HeaderText = "Update",
                        Text = "Update",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewEmployee.Columns.Add(updateColumn);
                }

                if (!dataGridViewEmployee.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn
                    {
                        Name = "Delete",
                        HeaderText = "Delete",
                        Text = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridViewEmployee.Columns.Add(deleteColumn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewEmployee_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check if the current cell belongs to the "status" column
            if (dataGridViewEmployee.Columns[e.ColumnIndex].Name == "status")
            {
                // Safely get the status value as a string
                string status = e.Value?.ToString()?.ToLower(); // Normalize to lowercase

                if (status == "active")
                {
                    // Display a green circle
                    e.Value = "⦿"; // Unicode circle symbol
                    dataGridViewEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Green;
                }
                else if (status == "offline")
                {
                    // Display a gray circle
                    e.Value = "⦿"; // Unicode circle symbol
                    dataGridViewEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Gray;
                }
                else
                {
                    // Handle unexpected values gracefully
                    e.Value = ""; // Display a question mark for unknown statuses
                    dataGridViewEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                }

                // Center-align the content and increase the font size
                dataGridViewEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                dataGridViewEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Ensure the cell's formatting is updated
                e.FormattingApplied = true;
            }
        }

        private void dataGridViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid row and not the header
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewEmployee.Rows[e.RowIndex];

                // Extract data from the selected row
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value); // Assuming 'id' is the primary key
                string fullName = selectedRow.Cells["full_name"].Value?.ToString();
                string email = selectedRow.Cells["email"].Value?.ToString();
                string mobile = selectedRow.Cells["mobile"].Value?.ToString();
                string password = selectedRow.Cells["emp_password"].Value?.ToString();
                string role = selectedRow.Cells["role"].Value?.ToString();

                // Check which button was clicked
                if (dataGridViewEmployee.Columns[e.ColumnIndex].Name == "Update")
                {
                    // Open the Update dialog
                    OpenUpdateDialogEmployee(id, fullName, email, mobile, password, role);
                }
                else if (dataGridViewEmployee.Columns[e.ColumnIndex].Name == "Delete")
                {
                    // Show the Delete confirmation dialog
                    DeleteEmpoloyee(id, fullName);
                }
            }
        }

        private void OpenUpdateDialogEmployee(int id, string currentFullName, string currentEmail, string currentMobile, string currentPassword, string currentRole)
        {
            using (Form updateForm = new Form())
            {
                updateForm.Text = $"Update Tenant: {currentFullName}";
                updateForm.StartPosition = FormStartPosition.CenterParent;
                updateForm.Size = new System.Drawing.Size(400, 300);

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

                // Password Label and TextBox
                Label passwordLabel = new Label { Text = "Password:", Location = new System.Drawing.Point(20, 140) };
                TextBox passwordTextBox = new TextBox
                {
                    Text = currentPassword,
                    Location = new System.Drawing.Point(120, 140),
                    Width = 200
                };

                // Role Label and TextBox
                Label roleLabel = new Label { Text = "Role:", Location = new System.Drawing.Point(20, 180) };
                ComboBox roleComboBox = new ComboBox
                {
                    Location = new System.Drawing.Point(120, 180),
                    Width = 200,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                // Populate the ComboBox with valid roles
                roleComboBox.Items.AddRange(new string[] { "manager", "staff" });

                // Optionally, set a default selected value if needed
                roleComboBox.SelectedItem = currentRole;

                // Update Button
                Button updateButton = new Button { Text = "Update", Location = new System.Drawing.Point(150, 220), Width = 100 };
                updateButton.Click += (sender, e) =>
                {
                    // Validate inputs
                    string newFullName = fullNameTextBox.Text.Trim();
                    string newEmail = emailTextBox.Text.Trim();
                    string newMobile = mobileTextBox.Text.Trim();
                    string newPassword = passwordTextBox.Text.Trim();
                    string newRole = roleComboBox.Text.Trim();

                    if (string.IsNullOrEmpty(newFullName) || string.IsNullOrEmpty(newEmail) || string.IsNullOrEmpty(newMobile) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(newRole))
                    {
                        MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    // Call the repository method to update the tenant
                    bool success = dbRepo.UpdateEmployee(id, newFullName, newEmail, newMobile, newPassword, newRole);
                    if (success)
                    {
                        MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeData(); // Refresh the DataGridView
                        updateForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Add controls to the form
                updateForm.Controls.AddRange(new Control[] { fullNameLabel, fullNameTextBox, emailLabel, emailTextBox, mobileLabel, mobileTextBox, passwordLabel, passwordTextBox, roleLabel, roleComboBox, updateButton });

                // Show the form
                updateForm.ShowDialog();
            }
        }

        private void DeleteEmpoloyee(int id, string fullName)
        {
            // Show a confirmation dialog
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete employee: {fullName}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Call the repository method to delete the tenant
                bool success = dbRepo.DeleteEmployee(id);
                if (success)
                {
                    MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployeeData(); // Refresh the DataGridView
                }
                else
                {
                    MessageBox.Show("Failed to delete employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InserEmployeebutton_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Validate input fields
                string fullName = EMPnametextBox.Text.Trim();
                string email = EMPemailtextBox.Text.Trim();
                string mobile = EMPmobileNotextBox.Text.Trim();
                string password = EMPpasswordtextBox.Text.Trim();
                string role = comboBoxRole.SelectedItem.ToString();

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(mobile) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
                {
                    MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Step 3: Insert tenant data into the database
                bool success = dbRepo.InsertEmployee(fullName, email, mobile, password, role);

                if (success)
                {
                    MessageBox.Show("Employee inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputFields(); // Clear the input fields after successful insertion
                    LoadEmployeeData();
                }
                else
                {
                    MessageBox.Show("Failed to insert employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            EMPnametextBox.Clear();
            EMPemailtextBox.Clear();
            EMPmobileNotextBox.Clear();
            EMPpasswordtextBox.Clear();
            comboBoxRole.SelectedIndex = 0;
        }

        private void SearchBtmEmployee_Click(object sender, EventArgs e)
        {
            // Get the search term from the SearchTenant text box
            string searchTerm = SearchEmployee.Text.Trim();

            // Load tenant data with the search term
            LoadEmployeeData(searchTerm);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
