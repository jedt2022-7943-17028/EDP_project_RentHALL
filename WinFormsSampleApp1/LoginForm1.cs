using Org.BouncyCastle.Crypto.Generators;
using WinFormsSampleApp1.Properties;
using BCrypt.Net;

namespace WinFormsSampleApp1
{
    public partial class LoginForm : Form
    {
        // Create an instance of the dbRepository class
        private dbRepository dbRepo = new dbRepository();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Log_In_Click(object sender, EventArgs e)
        {
            // Retrieve the username and password from the text boxes
            string username = username_text_box.Text.Trim(); // Trim removes leading/trailing whitespace
            string password = password_text_box.Text.Trim();

            // Check if the username is empty
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Error: Username cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution
            }

            // Check if the password is empty
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Error: Password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Stop further execution
            }

            // Check credentials in the owner table
            string ownerPasswordHash = dbRepo.GetOwnerPasswordHash(username);
            if (!string.IsNullOrEmpty(ownerPasswordHash) && BCrypt.Net.BCrypt.Verify(password, ownerPasswordHash))
            {
                MessageBox.Show("Welcome Admin", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to AdminForm1
                AdminForm1 adminForm = new AdminForm1();
                adminForm.Show();

                // Optionally, hide the current login form
                this.Hide();
                return; // Exit the method after successful login
            }

            // Check credentials in the employee table
            var (employeePasswordHash, role) = dbRepo.GetEmployeeCredentials(username);
            if (!string.IsNullOrEmpty(employeePasswordHash) && BCrypt.Net.BCrypt.Verify(password, employeePasswordHash))
            {
                MessageBox.Show($"Welcome! Your role is {role}", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Navigate to AdminForm1
                AdminForm1 adminForm = new AdminForm1();
                adminForm.Show();

                // Optionally, hide the current login form
                this.Hide();
                return; // Exit the method after successful login
            }

            // If no match is found in either table
            MessageBox.Show("Credentials mismatch", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
