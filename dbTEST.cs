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
    public partial class dbTEST : Form
    {
        public dbTEST()
        {
            InitializeComponent();
        }

        private void dbTEST_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the dbRepository class
            dbRepository db = new dbRepository();

            // Test the database connection
            bool isConnected = db.TestConnection();

            if (isConnected)
            {
                MessageBox.Show("Successfully connected to the database!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to connect to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
