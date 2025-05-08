using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSampleApp1.Properties
{
    public partial class EmployeeForm2RNT : Form
    {
        private dbRepository dbRepo = new dbRepository();
        private string _employeeEmail;

        public EmployeeForm2RNT(string employeeEmail)
        {
            InitializeComponent();
            _employeeEmail = employeeEmail;
        }

        private void EmployeeForm2RNT_Load(object sender, EventArgs e)
        {
            LoadRentalHistory();
            LoadActiveRental();
            LoadRentalSummary();

            // Fetch No Unit (from the inventory table)
            int unitTotalCount = dbRepo.GetUnitTotal();

            // Fetch No Rented Unit (from the inventory table)
            int unitTotalRentedCount = dbRepo.GetUnitRentedTotal();

            // Fetch No Available Unit (from the inventory table)
            int availableUnit = dbRepo.GetAvlUnit();

            // Fetch Total Amount Due Today (from the tenant active_rentals)
            decimal TotalDueToday = dbRepo.GetDueRent();

            // Fetch Total Amount Overdue (from the tenant active_rentals)
            decimal TotalOverdue = dbRepo.GetOverdueRent();


            NoUnit.Text = $"{unitTotalCount}";
            NoRentedUnit.Text = $"{unitTotalRentedCount}";
            NoAvlUnit.Text = $"{availableUnit}";
            DueToday.Text = $"{TotalDueToday:C}";
            OverdueRent.Text = $"{TotalOverdue:C}";

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

        private void LoadRentalHistory(string searchTerm = null)
        {
            try
            {
                // Fetch rental history data from the database
                DataTable rentalHistoryData = dbRepo.GetRentalHistory(searchTerm);

                // Bind the data to the DataGridView
                dataGridViewrental_history.DataSource = rentalHistoryData;

                // Optionally, hide unwanted columns
                dataGridViewrental_history.Columns["rental_agreement_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rental history data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadActiveRental(string searchTerm = null)
        {
            try
            {
                // Fetch rental history data from the database
                DataTable rentalActiveRentalData = dbRepo.GetRentalActiveRental(searchTerm);

                // Bind the data to the DataGridView
                dataGridViewactive_rentals.DataSource = rentalActiveRentalData;

                // Optionally, hide unwanted columns
                dataGridViewactive_rentals.Columns["rental_agreement_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rental history data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRentalSummary(string searchTerm = null)
        {
            try
            {
                // Fetch rental history data from the database
                DataTable rentalRentaSummarylData = dbRepo.GetRentaSummary(searchTerm);

                // Bind the data to the DataGridView
                dataGridViewproduct_rental_summary.DataSource = rentalRentaSummarylData;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rental history data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
