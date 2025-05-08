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
    public partial class EmployeeForm1 : Form
    {
        private dbRepository dbRepo = new dbRepository();

        public EmployeeForm1()
        {
            InitializeComponent();
        }

        private void EmployeeForm1_Load(object sender, EventArgs e)
        {
            LoadInventoryData();
            LoadProductData();

            // Fetch No Unit (from the inventory table)
            int unitTotalCount = dbRepo.GetUnitTotal();

            // Fetch No Rented Unit (from the inventory table)
            int unitTotalRentedCount = dbRepo.GetUnitRentedTotal();

            // Fetch No Available Unit (from the inventory table)
            int availableUnit = dbRepo.GetAvlUnit();

            string employee_name = dbRepo.GetEmployeeName();

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

        }

        private void TENANT_Click(object sender, EventArgs e)
        {

        }

        private void TRANSACTION_Click(object sender, EventArgs e)
        {

        }

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            // Navigate to Login
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();

            // Optionally, hide the current login form
            this.Hide();
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



    }
}
