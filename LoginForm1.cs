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
            // Check if the owner table is empty
            bool isOwnerTableEmpty = dbRepo.IsOwnerTableEmpty();

            if (isOwnerTableEmpty)
            {
                Login.Text = "Sign Up"; // Change button text to "Sign Up"
                createOwnerAccount.Text = "Create Admin Account";
            }
        }

        private void Log_In_Click(object sender, EventArgs e)
        {
            string username = username_text_box.Text.Trim();
            string password = password_text_box.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isOwnerTableEmpty = dbRepo.IsOwnerTableEmpty();

            // If owner table is empty, treat this as a sign-up
            if (isOwnerTableEmpty)
            {
                // Hash the password
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

                // Insert the new owner
                bool success = dbRepo.InsertOwner(username, passwordHash);

                if (success)
                {
                    // Open the security questions form
                    SecQuestions secQuestionsForm = new SecQuestions(username);
                    secQuestionsForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create owner account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Existing login logic (your original code)
                string ownerPasswordHash = dbRepo.GetOwnerPasswordHash(username);
                if (!string.IsNullOrEmpty(ownerPasswordHash) && BCrypt.Net.BCrypt.Verify(password, ownerPasswordHash))
                {
                    AdminForm1 adminForm = new AdminForm1();
                    adminForm.Show();
                    this.Hide();
                    return;
                }

                // Check employee login 
                var (employeePasswordHash, role, emp_status) = dbRepo.GetEmployeeCredentials(username);
                if (!string.IsNullOrEmpty(employeePasswordHash) && BCrypt.Net.BCrypt.Verify(password, employeePasswordHash) && (emp_status != "0"))
                {
                    // Track the logged-in employee
                    dbRepo.SetCurrentEmployeeEmail(username);
                    dbRepo.UpdateEmployeeActivityLog(employeePasswordHash);
                    EmployeeForm1 employeeForm = new EmployeeForm1();
                    employeeForm.Show();
                    this.Hide();
                    return;
                }

                MessageBox.Show("Invalid credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2forgot_Click(object sender, EventArgs e)
        {
            string username = username_text_box.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username first.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if username exists in owner table
            if (dbRepo.IsUsernameInOwnerTable(username))
            {
                // Check if security questions are set up (3 questions exist)
                if (dbRepo.GetSecurityQuestionCount(username) == 3)
                {
                    SecQuestions secForm = new SecQuestions(username, true); // true = password reset mode
                    secForm.Show();
                }
                else
                {
                    MessageBox.Show("Security questions not set up.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Check if username exists in employee table
            else if (dbRepo.IsUsernameInEmployeeTable(username))
            {
                MessageBox.Show("Please contact administrator to reset your password.", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Username not found.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
