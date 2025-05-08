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
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsSampleApp1
{
    public partial class SecQuestions : Form
    {
        // Create an instance of the dbRepository class
        private dbRepository dbRepo = new dbRepository();
        public string _username;
        public bool _isPasswordResetMode;

        public SecQuestions(string username, bool isPasswordResetMode = false)
        {
            InitializeComponent();
            _username = username;

            _isPasswordResetMode = isPasswordResetMode;

            if (_isPasswordResetMode)
            {
                Submit.Text = "Reset Password";
                this.Text = "Password Recovery";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Submit_Click(object sender, EventArgs e)
        {
            string answer1 = one_ans.Text.Trim();
            string answer2 = two_ans.Text.Trim();
            string answer3 = three_ans.Text.Trim();

            if (string.IsNullOrEmpty(answer1) || string.IsNullOrEmpty(answer2) || string.IsNullOrEmpty(answer3))
            {
                MessageBox.Show("All security answers are required.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ownerId = dbRepo.GetOwnerId(_username);
            if (ownerId == -1)
            {
                MessageBox.Show("Owner not found.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_isPasswordResetMode)
            {
                bool answersCorrect = dbRepo.VerifySecurityAnswers(ownerId, answer1, answer2, answer3);

                if (answersCorrect)
                {
                    // Show password input directly in MessageBox
                    string newPassword = Microsoft.VisualBasic.Interaction.InputBox(
                        "Enter new password:",
                        "Password Reset",
                        "",
                        -1, -1); // Default position

                    if (!string.IsNullOrEmpty(newPassword))
                    {
                        string confirmPassword = Microsoft.VisualBasic.Interaction.InputBox(
                            "Confirm new password:",
                            "Password Reset",
                            "",
                            -1, -1);

                        if (newPassword == confirmPassword)
                        {
                            string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
                            bool success = dbRepo.UpdateOwnerPassword(_username, newPasswordHash);

                            if (success)
                            {
                                MessageBox.Show("Password reset successfully!", "Success",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Failed to update password.", "Error",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Passwords do not match.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect security answers.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Original account setup code remains the same
                bool success = dbRepo.InsertSecurityAnswers(
                    ownerId,
                    1, answer1,
                    2, answer2,
                    3, answer3
                );

                if (success)
                {
                    MessageBox.Show("Account setup complete!", "Success",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AdminForm1 adminForm = new AdminForm1();
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to save security answers.", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
