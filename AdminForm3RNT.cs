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
    public partial class AdminForm3RNT : Form
    {
        private dbRepository dbRepo = new dbRepository();

        public AdminForm3RNT()
        {
            InitializeComponent();
        }

        private void AdminForm3RNT_Load(object sender, EventArgs e)
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
            WindowManager.ReloadWindow("AdminForm3RNT");
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NoAvlUnit_Click(object sender, EventArgs e)
        {

        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
