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
    public partial class AdminForm6TRS : Form
    {
        private dbRepository dbRepo = new dbRepository();
        public AdminForm6TRS()
        {
            

            InitializeComponent();
            LoaddataRental_agreement_details_withname();
            LoaddataRental_payment_withname();
            LoaddataRental_fee();

            dataGridrental_agreement_details_withname.CellClick += DataGridrental_agreement_details_withname_CellClick;
            dataGridViewpayment.CellClick += DataGridViewpayment_CellClick;
            dataGridViewFee.CellClick += DataGridViewFee_CellClick;
        }
        private void AdminForm6TRS_Load(object sender, EventArgs e)
        {
            // Fetch total revenue from the database
            decimal totalRevenue = dbRepo.GetTotalRevenue();

            // Fetch maximum revenue (from the fee table)
            decimal maxRevenue = dbRepo.GetMaxRevenue();

            // Calculate the percentage of total revenue relative to maxRevenue
            int progressValue = maxRevenue > 0 ? (int)((totalRevenue / maxRevenue) * 100) : 0;

            // Ensure the progress value stays within the valid range (0-100)
            if (progressValue > 100)
            {
                progressValue = 100; // Cap the progress at 100%
            }

            progressBarRevenue.Value = progressValue;
            TotalRevenue.Text = $"{totalRevenue:C}"; // Format as currency
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
            // Navigate to AdminFform1
            AdminForm5EMPY adminForm5 = new AdminForm5EMPY();
            adminForm5.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void TRANSACTION_Click(object sender, EventArgs e)
        {
            WindowManager.ReloadWindow("AdminForm6TRS");
        }

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            // Navigate to Login
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();

            // Optionally, hide the current login form
            this.Hide();
        }

        private void SearchBtmTRNS_Click(object sender, EventArgs e)
        {
            // Get the search term from the SearchTenant text box
            string searchTerm = SearchTRNS.Text.Trim();

            // Load tenant data with the search term
            LoaddataRental_agreement_details_withname(searchTerm);
        }


        private void LoaddataRental_agreement_details_withname(string searchTerm = null)
        {
            try
            {
                // Fetch inventory data from the database
                DataTable agreement_wthname = dbRepo.GetRentalAgreement_withname(searchTerm);

                // Bind the data to the DataGridView
                dataGridrental_agreement_details_withname.DataSource = agreement_wthname;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoaddataRental_payment_withname(string rentalAgreementId = null)
        {
            try
            {
                // Fetch payment data based on the provided rentalAgreementId
                DataTable payments = dbRepo.GetPayment_withname(rentalAgreementId);

                // Clear the existing data source
                dataGridViewpayment.DataSource = null;

                // Bind the new data to the DataGridView
                dataGridViewpayment.DataSource = payments;
                dataGridViewpayment.Columns["rental_agreement_id"].Visible = false;
                dataGridViewpayment.Columns["received_by_employee_id"].Visible = false;
                // Force the DataGridView to refresh
                dataGridViewpayment.Refresh();

                

                // Handle empty results gracefully
                if (payments.Rows.Count == 0)
                {
                    MessageBox.Show("No matching payments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading payment data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoaddataRental_fee(string rentalAgreementId = null)
        {
            try
            {
                // Fetch payment data based on the provided rentalAgreementId
                DataTable fee = dbRepo.GetRental_Fee(rentalAgreementId);

                // Clear the existing data source
                dataGridViewFee.DataSource = null;

                // Bind the new data to the DataGridView
                dataGridViewFee.DataSource = fee;
                dataGridViewFee.Columns["rental_agreement_id"].Visible = false;
                dataGridViewFee.Columns["id"].Visible = false;
                dataGridViewFee.Columns["fee_type"].Visible = false;
                // Force the DataGridView to refresh
                dataGridViewFee.Refresh();



                // Handle empty results gracefully
                if (fee.Rows.Count == 0)
                {
                    MessageBox.Show("No matching fee found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading fee data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void DataGridViewFee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is on a valid row (not the header)
                if (e.RowIndex >= 0)
                {
                    // Get the clicked row
                    DataGridViewRow row = dataGridViewFee.Rows[e.RowIndex];

                    // Extract the id from the "id" column
                    string rentalAgreementId = row.Cells["rental_agreement_id"]?.Value?.ToString();

                    if (!string.IsNullOrEmpty(rentalAgreementId))
                    {
                        // Pass the id to LoaddataRental_fee
                        LoaddataRental_fee(rentalAgreementId);
                        LoaddataRental_agreement_details_withname(rentalAgreementId);
                        LoaddataRental_payment_withname(rentalAgreementId);
                    }
                    else
                    {
                        LoaddataRental_fee();
                        LoaddataRental_agreement_details_withname();
                        LoaddataRental_payment_withname();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing row click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewpayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is on a valid row (not the header)
                if (e.RowIndex >= 0)
                {
                    // Get the clicked row
                    DataGridViewRow row = dataGridViewpayment.Rows[e.RowIndex];

                    // Extract the id from the "id" column
                    string rentalAgreementId = row.Cells["rental_agreement_id"]?.Value?.ToString();

                    if (!string.IsNullOrEmpty(rentalAgreementId))
                    {
                        // Pass the id to LoaddataRental_fee
                        LoaddataRental_fee(rentalAgreementId);
                        LoaddataRental_agreement_details_withname(rentalAgreementId);
                    }
                    else
                    {
                        LoaddataRental_fee();
                        LoaddataRental_agreement_details_withname();
                        LoaddataRental_payment_withname();
                    }
                }
                else if (e.RowIndex < 0)
                {
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing row click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridrental_agreement_details_withname_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ensure the click is on a valid row (not the header)
                if (e.RowIndex >= 0)
                {
                    // Get the clicked row
                    DataGridViewRow row = dataGridrental_agreement_details_withname.Rows[e.RowIndex];

                    // Extract the id from the "id" column
                    string rentalAgreementId = row.Cells["id"]?.Value?.ToString();

                    if (!string.IsNullOrEmpty(rentalAgreementId))
                    {
                        // Pass the id to LoaddataRental_payment_withname
                        LoaddataRental_payment_withname(rentalAgreementId);
                        LoaddataRental_fee(rentalAgreementId);
                    }
                    else
                    {
                        LoaddataRental_fee();
                        LoaddataRental_agreement_details_withname();
                        LoaddataRental_payment_withname();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing row click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
