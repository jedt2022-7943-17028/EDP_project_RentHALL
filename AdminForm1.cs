using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSampleApp1.Properties;
using WinFormsSampleApp1.Properties.Models;

namespace WinFormsSampleApp1
{
    public partial class AdminForm1 : Form
    {
        private dbRepository dbRepo = new dbRepository();

        public AdminForm1()
        {
            InitializeComponent();
            LoadActiveRentals();
        }

        private void AdminForm1_Load(object sender, EventArgs e)
        {
            try
            {
                // Fetch total revenue from the database
                decimal totalRevenue = dbRepo.GetTotalRevenue();

                // Fetch maximum revenue (from the fee table)
                decimal maxRevenue = dbRepo.GetMaxRevenue();

                // Fetch No Employee (from the employee table)
                var employeeCount = dbRepo.GetEmpNo();

                // Fetch No Tenant (from the tenant table)
                int tenantCount = dbRepo.GetTenantNo();

                // Fetch Total Amount Due Today (from the tenant active_rentals)
                decimal TotalDueToday = dbRepo.GetDueRent();

                // Fetch Total Amount Overdue (from the tenant active_rentals)
                decimal TotalOverdue = dbRepo.GetOverdueRent();

                // Fetch No exp (from the active_rentals table)
                int expCount = dbRepo.GetExp();

                // Fetch No expd (from the active_rentals table)
                int expdCount = dbRepo.GetExpd();

                // Fetch No Unit (from the inventory table)
                int unitTotalCount = dbRepo.GetUnitTotal();

                // Fetch No Rented Unit (from the inventory table)
                int unitTotalRentedCount = dbRepo.GetUnitRentedTotal();

                // Fetch No Available Unit (from the inventory table)
                int availableUnit = dbRepo.GetAvlUnit();

                // Calculate the percentage of total revenue relative to maxRevenue
                int progressValue = maxRevenue > 0 ? (int)((totalRevenue / maxRevenue) * 100) : 0;

                // Ensure the progress value stays within the valid range (0-100)
                if (progressValue > 100)
                {
                    progressValue = 100; // Cap the progress at 100%
                }

                // Update the label text with the total revenue and progress bar'
                progressBarRevenue.Value = progressValue;
                TotalRevenue.Text = $"{totalRevenue:C}"; // Format as currency
                EmpNo.Text = $"{employeeCount.EmpCount}";
                EmpAct.Text = $"{employeeCount.ActCount}";
                TenantNo.Text = $"{tenantCount}";
                DueToday.Text = $"{TotalDueToday:C}";
                OverdueRent.Text = $"{TotalOverdue:C}";
                NoExp.Text = $"{expCount}";
                NoExpd.Text = $"{expdCount}";
                NoUnit.Text = $"{unitTotalCount}";
                NoRentedUnit.Text = $"{unitTotalRentedCount}";
                NoAvlUnit.Text = $"{availableUnit}";

                if(unitTotalCount > 0)
                {
                    // Update the circular progress bar
                    circularProgressBar1.Maximum = unitTotalCount; // Set the maximum value
                    circularProgressBar1.Value = unitTotalRentedCount; // Set the current value
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DASHBOARD_Click(object sender, EventArgs e)
        {
            WindowManager.ReloadWindow("AdminForm1");
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
            // Navigate to AdminFform1
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();

            // Optionally, hide the current login form
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Method to load active rentals into the DataGridView
        private void LoadActiveRentals()
        {
            try
            {
                List<ActiveRentals> activeRentals = dbRepo.GetActiveRentals();

                if (activeRentals.Count > 0)
                {
                    ActiveRentalsDataGridView.AutoGenerateColumns = false;

                    // Define columns manually, excluding EmployeeFullName
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "RentalAgreementId",
                        HeaderText = "Rental Agreement ID",
                        Name = "RentalAgreementId"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TenantFullName",
                        HeaderText = "Tenant Full Name",
                        Name = "TenantFullName"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TenantEmail",
                        HeaderText = "Tenant Email",
                        Name = "TenantEmail"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TenantMobile",
                        HeaderText = "Tenant Mobile",
                        Name = "TenantMobile"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "SerialNumberId",
                        HeaderText = "Serial Number",
                        Name = "SerialNumberId"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "EndDate",
                        HeaderText = "End Date",
                        Name = "EndDate"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Duration",
                        HeaderText = "Duration",
                        Name = "Duration"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "Status",
                        HeaderText = "Status",
                        Name = "Status"
                    });
                    ActiveRentalsDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        DataPropertyName = "TotalAmountDue",
                        HeaderText = "Total Amount Due",
                        Name = "TotalAmountDue"
                    });

                    ActiveRentalsDataGridView.DataSource = activeRentals; // Bind data to the DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading active rentals: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Handle CellContentClick event for the DataGridView
        private void ActiveRentals_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on a valid cell (not the header row)
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = ActiveRentalsDataGridView.Rows[e.RowIndex];

                // Retrieve the bound object (ActiveRentals) from the DataBoundItem property
                ActiveRentals rental = selectedRow.DataBoundItem as ActiveRentals;

                // Extract data from the ActiveRentals object
                int rentalAgreementId = rental.RentalAgreementId;
                string tenantFullName = rental.TenantFullName;
                string tenantEmail = rental.TenantEmail;
                string tenantMobile = rental.TenantMobile;
                string serialNumberId = rental.SerialNumberId;
                DateTime endDate = rental.EndDate;
                string duration = rental.Duration;
                string status = rental.Status;
                decimal totalAmountDue = rental.TotalAmountDue;
                string employeeFullName = rental.EmployeeFullName;



                // Display the details in a message box or another control
                MessageBox.Show(
                    $"Rental Agreement ID: {rentalAgreementId}\n" +
                    $"Tenant Full Name: {tenantFullName}\n" +
                    $"Tenant Email: {tenantEmail}\n" +
                    $"Tenant Mobile: {tenantMobile}\n" +
                    $"Serial Number: {serialNumberId}\n" +
                    $"End Date: {endDate.ToShortDateString()}\n" +
                    $"Duration: {duration}\n" +
                    $"Status: {status}\n" +
                    $"Total Amount: {totalAmountDue:C}\n" +
                    $"Employee Full Name: {employeeFullName}",
                    "Selected Rental Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void TotalRevenue_Click(object sender, EventArgs e)
        {

        }

        private void progressBarRevenue_Click(object sender, EventArgs e)
        {
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
