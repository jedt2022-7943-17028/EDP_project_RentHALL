using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsSampleApp1.Properties
{
    public static class WindowManager
    {
        // Dictionary to map form names to their types
        private static readonly Type[] AvailableForms =
        {
            typeof(LoginForm),      // Add form names here
            typeof(AdminForm1),
            typeof(AdminForm2INV),
            typeof(AdminForm3RNT),
            typeof(AdminForm4TNT),
            typeof(AdminForm5EMPY),
            typeof(AdminForm6TRS)
        };

        /// <summary>
        /// Closes the specified window and reopens it.
        /// </summary>
        /// <param name="formName">The name of the form to close and reopen.</param>
        public static void ReloadWindow(string formName)
        {
            try
            {
                // Find the type of the form based on its name
                Type formType = Array.Find(AvailableForms, f => f.Name.Equals(formName, StringComparison.OrdinalIgnoreCase));

                if (formType == null)
                {
                    MessageBox.Show($"Form '{formName}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Find the currently open instance of the form
                Form currentInstance = Application.OpenForms.Cast<Form>()
                    .FirstOrDefault(f => f.GetType() == formType);

                if (currentInstance != null)
                {
                    // Close and dispose of the current instance
                    currentInstance.Close();
                    currentInstance.Dispose();
                }

                // Create a new instance of the form and show it
                Form newInstance = (Form)Activator.CreateInstance(formType);
                newInstance.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reloading window: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}