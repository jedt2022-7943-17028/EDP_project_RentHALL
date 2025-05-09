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
    public partial class EmployeeForm4TANS : Form
    {
        private dbRepository dbRepo = new dbRepository();
        private string _employeeEmail;

        public EmployeeForm4TANS(string employeeEmail)
        {
            InitializeComponent();
            _employeeEmail = employeeEmail;

            LoaddataRental_agreement_details_withname();
            LoaddataRental_payment_withname();
            LoaddataRental_fee();
            LoaddataRental_paid();

            dataGridrental_agreement_details_withname.CellClick += DataGridrental_agreement_details_withname_CellClick;
            dataGridViewpayment.CellClick += DataGridViewpayment_CellClick;
            dataGridViewFee.CellClick += DataGridViewFee_CellClick;
        }


        private void EmployeeForm4TANS_Load(object sender, EventArgs e)
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

        private void ITEMS_Click(object sender, EventArgs e)
        {
            EmployeeForm1 employeeForm = new EmployeeForm1(_employeeEmail);
            employeeForm.Show();
            this.Hide();
        }

        private void RENTALSbutton_Click(object sender, EventArgs e)
        {
            EmployeeForm2RNT employeeForm2 = new EmployeeForm2RNT(_employeeEmail);
            employeeForm2.Show();
            this.Hide();
        }

        private void TENANT_Click(object sender, EventArgs e)
        {
            EmployeeForm3TNT employeeForm3 = new EmployeeForm3TNT(_employeeEmail);
            employeeForm3.Show();
            this.Hide();
        }

        private void TRANSACTION_Click(object sender, EventArgs e)
        {
            EmployeeForm4TANS employeeForm4 = new EmployeeForm4TANS(_employeeEmail);
            employeeForm4.Show();
            this.Hide();
        }

        private void LOGOUT_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the current employee email from the repository
                string currentEmail = _employeeEmail;

                if (!string.IsNullOrEmpty(currentEmail))
                {
                    // Update status to offline
                    bool success = dbRepo.SetEmployeeOffline(currentEmail);

                    if (!success)
                    {
                        MessageBox.Show("Failed to update logout status.", "Warning",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Navigate to Login
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during logout: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                // Add action button columns if they don't exist
                if (!dataGridrental_agreement_details_withname.Columns.Contains("AddFee"))
                {
                    DataGridViewButtonColumn addFeeColumn = new DataGridViewButtonColumn
                    {
                        Name = "AddFee",
                        HeaderText = "AddFee",
                        Text = "Add Fee",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridrental_agreement_details_withname.Columns.Add(addFeeColumn);
                }

                if (!dataGridrental_agreement_details_withname.Columns.Contains("Terminate"))
                {
                    DataGridViewButtonColumn terminateColumn = new DataGridViewButtonColumn
                    {
                        Name = "Terminate",
                        HeaderText = "Terminate",
                        Text = "Terminate",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridrental_agreement_details_withname.Columns.Add(terminateColumn);
                }

                if (!dataGridrental_agreement_details_withname.Columns.Contains("Print"))
                {
                    DataGridViewButtonColumn printColumn = new DataGridViewButtonColumn
                    {
                        Name = "Print",
                        HeaderText = "Print",
                        Text = "Print",
                        UseColumnTextForButtonValue = true
                    };
                    dataGridrental_agreement_details_withname.Columns.Add(printColumn);
                }
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
                // Fetch all payment data
                DataTable allPayments = dbRepo.GetPayment_withname(rentalAgreementId);

                // Filter to only incomplete payments
                DataTable incompletePayments = allPayments.Clone();
                foreach (DataRow row in allPayments.Rows)
                {
                    if (!row["payment_status"].ToString().Equals("done", StringComparison.OrdinalIgnoreCase))
                    {
                        incompletePayments.ImportRow(row);
                    }
                }

                // Clear and bind the filtered data
                dataGridViewpayment.DataSource = incompletePayments;

                // Hide unnecessary columns
                dataGridViewpayment.Columns["rental_agreement_id"].Visible = false;
                dataGridViewpayment.Columns["received_by_employee_id"].Visible = false;
                dataGridViewpayment.Columns["payment_date"].Visible = false;
                dataGridViewpayment.Columns["payment_method"].Visible = false;
                dataGridViewpayment.Columns["payment_status"].Visible = false;
                dataGridViewpayment.Columns["reference_number"].Visible = false;
                dataGridViewpayment.Columns["received_by_employee_name"].Visible = false;

                // Add Pay button if needed
                if (!dataGridViewpayment.Columns.Contains("PAY"))
                {
                    DataGridViewButtonColumn payColumn = new DataGridViewButtonColumn
                    {
                        Name = "PAY",
                        HeaderText = "Action",
                        Text = "Pay",
                        UseColumnTextForButtonValue = true,
                        DefaultCellStyle = new DataGridViewCellStyle
                        {
                            BackColor = Color.LightGreen,
                            Alignment = DataGridViewContentAlignment.MiddleCenter
                        }
                    };
                    dataGridViewpayment.Columns.Add(payColumn);
                }

                // Handle empty results
                if (incompletePayments.Rows.Count == 0)
                {
                    MessageBox.Show("No incomplete payments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoaddataRental_paid(string rentalAgreementId = null)
        {
            try
            {
                // Fetch all payment data
                DataTable allPayments = dbRepo.GetPayment_withname(rentalAgreementId);

                // Filter to only incomplete payments
                DataTable incompletePayments = allPayments.Clone();
                foreach (DataRow row in allPayments.Rows)
                {
                    if (!row["payment_status"].ToString().Equals("pending", StringComparison.OrdinalIgnoreCase))
                    {
                        incompletePayments.ImportRow(row);
                    }
                }

                // Clear and bind the filtered data
                dataGridViewpaid.DataSource = incompletePayments;

                // Hide unnecessary columns
                dataGridViewpaid.Columns["rental_agreement_id"].Visible = false;
                dataGridViewpaid.Columns["received_by_employee_id"].Visible = false;
                dataGridViewpaid.Columns["payment_method"].Visible = false;
                dataGridViewpaid.Columns["payment_status"].Visible = false;
                dataGridViewpaid.Columns["reference_number"].Visible = false;

                // Handle empty results
                if (incompletePayments.Rows.Count == 0)
                {
                    MessageBox.Show("No incomplete payments found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        LoaddataRental_paid(rentalAgreementId);
                    }
                    else
                    {
                        LoaddataRental_fee();
                        LoaddataRental_agreement_details_withname();
                        LoaddataRental_payment_withname();
                        LoaddataRental_paid();
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
                // First check if it's a button column click
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var columnName = dataGridViewpayment.Columns[e.ColumnIndex].Name;

                    if (columnName == "PAY")
                    {
                        // Get the rental agreement ID
                        var row = dataGridViewpayment.Rows[e.RowIndex];
                        int agreementId = Convert.ToInt32(row.Cells["rental_agreement_id"].Value);
                        FeePaymentForm(agreementId);
                        return;
                    }
                }

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
                        LoaddataRental_payment_withname(rentalAgreementId);
                        LoaddataRental_paid(rentalAgreementId);
                    }
                    else
                    {
                        LoaddataRental_fee();
                        LoaddataRental_agreement_details_withname();
                        LoaddataRental_payment_withname();
                        LoaddataRental_paid();
                    }
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
                // First check if it's a button column click
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var columnName = dataGridrental_agreement_details_withname.Columns[e.ColumnIndex].Name;

                    if (columnName == "AddFee")
                    {
                        // Get the rental agreement ID
                        var row = dataGridrental_agreement_details_withname.Rows[e.RowIndex];
                        int agreementId = Convert.ToInt32(row.Cells["id"].Value);
                        AddFeeForAgreement(agreementId);
                        return;
                    }

                    if (columnName == "Terminate")
                    {
                        // Get the rental agreement ID
                        var row = dataGridrental_agreement_details_withname.Rows[e.RowIndex];
                        int agreementId = Convert.ToInt32(row.Cells["id"].Value);
                        TerminateAgreement(agreementId);
                        return;
                    }

                    if (columnName == "Print")
                    {
                        var row = dataGridrental_agreement_details_withname.Rows[e.RowIndex];
                        int agreementId = Convert.ToInt32(row.Cells["id"].Value);

                        SaveFileDialog saveDialog = new SaveFileDialog();
                        saveDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
                        saveDialog.FileName = $"Rental_Transaction_{agreementId}.xlsx";
                        saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            bool success = dbRepo.ExportTransactionHistoryToExcel(agreementId, saveDialog.FileName);
                        }

                        return;
                    }
                }

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
                        LoaddataRental_fee(rentalAgreementId);
                        LoaddataRental_agreement_details_withname(rentalAgreementId);
                        LoaddataRental_payment_withname(rentalAgreementId);
                        LoaddataRental_paid(rentalAgreementId);
                    }
                    else
                    {
                        LoaddataRental_fee();
                        LoaddataRental_agreement_details_withname();
                        LoaddataRental_payment_withname();
                        LoaddataRental_paid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing row click: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddFeeForAgreement(int agreementId)
        {
            // Create a custom form for fee input
            using (Form inputForm = new Form())
            {
                inputForm.Text = $"Add Fee for Agreement #{agreementId}";
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.Size = new Size(400, 300);
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.MaximizeBox = false;
                inputForm.MinimizeBox = false;

                // Fee Type
                Label lblFeeType = new Label() { Text = "Fee Type:", Left = 20, Top = 20, Width = 100 };
                ComboBox cmbFeeType = new ComboBox() { Left = 120, Top = 20, Width = 200 };
                cmbFeeType.Items.AddRange(new string[] { "late", "damage", "utility", "electricity", "water", "internet", "other" });
                cmbFeeType.SelectedIndex = 0;

                // Amount
                Label lblAmount = new Label() { Text = "Amount:", Left = 20, Top = 60, Width = 100 };
                NumericUpDown numAmount = new NumericUpDown() { Left = 120, Top = 60, Width = 200, Minimum = 0, Maximum = 10000, DecimalPlaces = 2 };

                // Description
                Label lblDescription = new Label() { Text = "Description:", Left = 20, Top = 100, Width = 100 };
                TextBox txtDescription = new TextBox() { Left = 120, Top = 100, Width = 200, Height = 60, Multiline = true };

                // Submit Button
                Button btnSubmit = new Button() { Text = "Submit", Left = 120, Top = 180, Width = 80 };
                btnSubmit.Click += (sender, e) =>
                {
                    if (string.IsNullOrWhiteSpace(cmbFeeType.Text))
                    {
                        MessageBox.Show("Please select a fee type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool success = dbRepo.InsertFee(
                        agreementId,
                        cmbFeeType.Text,
                        numAmount.Value,
                        txtDescription.Text
                    );

                    if (success)
                    {
                        MessageBox.Show("Fee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        inputForm.DialogResult = DialogResult.OK;
                        inputForm.Close();
                        LoaddataRental_fee();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Add controls to form
                inputForm.Controls.AddRange(new Control[] {
            lblFeeType, cmbFeeType,
            lblAmount, numAmount,
            lblDescription, txtDescription,
            btnSubmit
        });

                // Show form
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    // Refresh data if needed
                    LoaddataRental_agreement_details_withname();
                }
            }
        }

        private void FeePaymentForm(int rentalAgreementId)
        {
            try
            {
                DataTable fees = dbRepo.GetFeesByRentalAgreement(rentalAgreementId);
                if (fees.Rows.Count == 0)
                {
                    MessageBox.Show("No unpaid fees found.", "No Fees", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                decimal totalDue = fees.AsEnumerable().Sum(row => row.Field<decimal>("amount"));
                List<int> feeIds = fees.AsEnumerable().Select(row => row.Field<int>("id")).ToList();

                DialogResult confirmResult = MessageBox.Show(
                    $"Total amount due: {totalDue:C}\n\nDo you want to proceed with this payment?",
                    "Confirm Payment",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes)
                    return;

                // Ask for payment method and reference number
                if (!ShowPaymentInputDialog(out string paymentMethod, out string referenceNumber))
                    return;

                // Process payment (now accepts employeeEmail as parameter)
                bool success = dbRepo.ProcessPayment(
                    rentalAgreementId,
                    feeIds,
                    totalDue,
                    _employeeEmail,
                    paymentMethod,
                    referenceNumber);

                if (success)
                {
                    MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoaddataRental_fee(rentalAgreementId.ToString());
                    LoaddataRental_payment_withname(rentalAgreementId.ToString());

                    // Call Renewal Method
                    RenewRentalAgreement(rentalAgreementId);

                    // Refresh progress bar and revenue label
                    decimal totalRevenue = dbRepo.GetTotalRevenue();
                    decimal maxRevenue = dbRepo.GetMaxRevenue();
                    int progressValue = maxRevenue > 0 ? (int)((totalRevenue / maxRevenue) * 100) : 0;
                    if (progressValue > 100) progressValue = 100;
                    progressBarRevenue.Value = progressValue;
                    TotalRevenue.Text = $"{totalRevenue:C}";
                }
                else
                {
                    MessageBox.Show("Failed to process payment. Amount mismatch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ShowPaymentInputDialog(out string paymentMethod, out string referenceNumber)
        {
            paymentMethod = "";
            referenceNumber = "";

            // Create temporary form to hold input controls
            using (Form inputForm = new Form())
            {
                inputForm.Text = "Enter Payment Details";
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.MaximizeBox = false;
                inputForm.MinimizeBox = false;
                inputForm.ClientSize = new Size(350, 180);

                Label lblMethod = new Label() { Text = "Payment Method:", Left = 20, Top = 20 };
                ComboBox cmbMethod = new ComboBox()
                {
                    Left = 130,
                    Top = 17,
                    Width = 200,
                    Items = { "cash", "credit_card", "bank_transfer", "check", "other" },
                    SelectedIndex = 0
                };

                Label lblRef = new Label() { Text = "Reference No.:", Left = 20, Top = 60 };
                TextBox txtRef = new TextBox() { Left = 130, Top = 57, Width = 200 };

                Button btnOk = new Button() { Text = "OK", Left = 100, Top = 120, Width = 75 };
                Button btnCancel = new Button() { Text = "Cancel", Left = 190, Top = 120, Width = 75 };

                inputForm.Controls.AddRange(new Control[] { lblMethod, cmbMethod, lblRef, txtRef, btnOk, btnCancel });

                btnOk.DialogResult = DialogResult.OK;
                btnCancel.DialogResult = DialogResult.Cancel;

                inputForm.AcceptButton = btnOk;
                inputForm.CancelButton = btnCancel;

                var result = inputForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    paymentMethod = cmbMethod.SelectedItem?.ToString();
                    referenceNumber = txtRef.Text.Trim();
                    return true;
                }

                return false;
            }
        }


        private void RenewRentalAgreement(int rentalAgreementId)
        {
            try
            {
                var result = MessageBox.Show("Do you want to renew this rental agreement?",
                                             "Confirm Renewal",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Proceed with renewal
                    bool success = dbRepo.RenewRentalAgreement(rentalAgreementId);

                    if (!success)
                    {
                        MessageBox.Show("Failed to renew agreement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Rental agreement renewed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (result == DialogResult.No)
                {
                    // Ask if they want to mark agreement as complete
                    var confirmComplete = MessageBox.Show(
                        "Mark this agreement as complete?",
                        "Set Agreement Status",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirmComplete == DialogResult.Yes)
                    {
                        // Call repository to update agreement status to 'complete'
                        bool success = dbRepo.UpdateRentalAgreementStatusToComplete(rentalAgreementId);

                        if (!success)
                        {
                            MessageBox.Show("Failed to update agreement status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MessageBox.Show("Rental agreement marked as complete.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // If Cancel is clicked, do nothing

                // Refresh UI
                LoaddataRental_agreement_details_withname(rentalAgreementId.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during renewal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TerminateAgreement(int rentalAgreementId)
        {
            try
            {

                // Ask if they want to terminate the aggreement
                var confirmComplete = MessageBox.Show(
                    "Terminate this agreement??",
                    "Terminate",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmComplete == DialogResult.Yes)
                {
                    // Call repository to update agreement status to 'complete'
                    bool success = dbRepo.TerminateRentalAgreement(rentalAgreementId);

                    if (!success)
                    {
                        MessageBox.Show("Failed to terminate agreement.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Rental agreement marked terminated.", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // If Cancel is clicked, do nothing

                // Refresh UI
                LoaddataRental_agreement_details_withname(rentalAgreementId.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during renewal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewpaid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
