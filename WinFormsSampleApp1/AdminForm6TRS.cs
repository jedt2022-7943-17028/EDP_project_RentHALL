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
        public AdminForm6TRS()
        {
            InitializeComponent();
        }
        private void AdminForm6TRS_Load(object sender, EventArgs e)
        {

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

        
    }
}
