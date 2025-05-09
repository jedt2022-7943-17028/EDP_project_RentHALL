namespace WinFormsSampleApp1
{
    partial class EmployeeForm4TANS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm4TANS));
            RENTALSbutton = new Button();
            LOGOUT = new Button();
            TRANSACTION = new Button();
            ITEMS = new Button();
            TENANT = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            SearchBtmTRNS = new Button();
            SearchTRNS = new TextBox();
            panel1 = new Panel();
            label7 = new Label();
            dataGridrental_agreement_details_withname = new DataGridView();
            panel3 = new Panel();
            dataGridViewpayment = new DataGridView();
            label2 = new Label();
            dataGridViewrental_agreement_withname = new DataGridView();
            panel5 = new Panel();
            pictureBox3 = new PictureBox();
            TotalRevenue = new Label();
            progressBarRevenue = new ProgressBar();
            label1 = new Label();
            panel4 = new Panel();
            dataGridViewFee = new DataGridView();
            label3 = new Label();
            panel6 = new Panel();
            dataGridViewpaid = new DataGridView();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridrental_agreement_details_withname).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewpayment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewrental_agreement_withname).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFee).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewpaid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // RENTALSbutton
            // 
            RENTALSbutton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RENTALSbutton.Location = new Point(24, 209);
            RENTALSbutton.Name = "RENTALSbutton";
            RENTALSbutton.Size = new Size(168, 40);
            RENTALSbutton.TabIndex = 53;
            RENTALSbutton.Text = "RENTALS";
            RENTALSbutton.UseVisualStyleBackColor = true;
            RENTALSbutton.Click += RENTALSbutton_Click;
            // 
            // LOGOUT
            // 
            LOGOUT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOGOUT.Location = new Point(24, 576);
            LOGOUT.Name = "LOGOUT";
            LOGOUT.Size = new Size(168, 40);
            LOGOUT.TabIndex = 52;
            LOGOUT.Text = "LOGOUT";
            LOGOUT.UseVisualStyleBackColor = true;
            LOGOUT.Click += LOGOUT_Click;
            // 
            // TRANSACTION
            // 
            TRANSACTION.BackColor = Color.Brown;
            TRANSACTION.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TRANSACTION.ForeColor = SystemColors.ControlLightLight;
            TRANSACTION.Location = new Point(24, 328);
            TRANSACTION.Name = "TRANSACTION";
            TRANSACTION.Size = new Size(168, 40);
            TRANSACTION.TabIndex = 51;
            TRANSACTION.Text = "TRANSACTION";
            TRANSACTION.UseVisualStyleBackColor = false;
            TRANSACTION.Click += TRANSACTION_Click;
            // 
            // ITEMS
            // 
            ITEMS.BackColor = Color.White;
            ITEMS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ITEMS.ForeColor = SystemColors.WindowText;
            ITEMS.Location = new Point(24, 149);
            ITEMS.Name = "ITEMS";
            ITEMS.Size = new Size(168, 40);
            ITEMS.TabIndex = 50;
            ITEMS.Text = "ITEMS";
            ITEMS.UseVisualStyleBackColor = false;
            ITEMS.Click += ITEMS_Click;
            // 
            // TENANT
            // 
            TENANT.BackColor = Color.Transparent;
            TENANT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TENANT.ForeColor = SystemColors.ActiveCaptionText;
            TENANT.Location = new Point(24, 268);
            TENANT.Name = "TENANT";
            TENANT.Size = new Size(168, 40);
            TENANT.TabIndex = 49;
            TENANT.Text = "TENANT";
            TENANT.UseVisualStyleBackColor = false;
            TENANT.Click += TENANT_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Image = Properties.Resources._02053c90_9350_4488_8fd0_33a40144cd91_removebg_preview;
            pictureBox2.Location = new Point(24, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(168, 116);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 48;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 697);
            pictureBox1.TabIndex = 47;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ScrollBar;
            panel2.Controls.Add(SearchBtmTRNS);
            panel2.Controls.Add(SearchTRNS);
            panel2.Location = new Point(234, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(799, 84);
            panel2.TabIndex = 54;
            // 
            // SearchBtmTRNS
            // 
            SearchBtmTRNS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchBtmTRNS.Location = new Point(618, 21);
            SearchBtmTRNS.Name = "SearchBtmTRNS";
            SearchBtmTRNS.Size = new Size(156, 40);
            SearchBtmTRNS.TabIndex = 3;
            SearchBtmTRNS.Text = "Search";
            SearchBtmTRNS.UseVisualStyleBackColor = true;
            SearchBtmTRNS.Click += SearchBtmTRNS_Click;
            // 
            // SearchTRNS
            // 
            SearchTRNS.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchTRNS.Location = new Point(33, 21);
            SearchTRNS.MaximumSize = new Size(200, 250);
            SearchTRNS.MinimumSize = new Size(570, 40);
            SearchTRNS.Name = "SearchTRNS";
            SearchTRNS.Size = new Size(570, 40);
            SearchTRNS.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(dataGridrental_agreement_details_withname);
            panel1.Location = new Point(234, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(799, 267);
            panel1.TabIndex = 55;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(4, 1);
            label7.Name = "label7";
            label7.Size = new Size(96, 30);
            label7.TabIndex = 18;
            label7.Text = "Contract";
            // 
            // dataGridrental_agreement_details_withname
            // 
            dataGridrental_agreement_details_withname.BackgroundColor = SystemColors.Window;
            dataGridrental_agreement_details_withname.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridrental_agreement_details_withname.Location = new Point(0, 33);
            dataGridrental_agreement_details_withname.Name = "dataGridrental_agreement_details_withname";
            dataGridrental_agreement_details_withname.Size = new Size(799, 234);
            dataGridrental_agreement_details_withname.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(dataGridViewpayment);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(dataGridViewrental_agreement_withname);
            panel3.Location = new Point(234, 400);
            panel3.Name = "panel3";
            panel3.Size = new Size(362, 260);
            panel3.TabIndex = 56;
            // 
            // dataGridViewpayment
            // 
            dataGridViewpayment.BackgroundColor = SystemColors.Window;
            dataGridViewpayment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewpayment.Location = new Point(0, 28);
            dataGridViewpayment.Name = "dataGridViewpayment";
            dataGridViewpayment.Size = new Size(362, 232);
            dataGridViewpayment.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1, 1);
            label2.Name = "label2";
            label2.Size = new Size(161, 30);
            label2.TabIndex = 19;
            label2.Text = "Unpaid Balance";
            // 
            // dataGridViewrental_agreement_withname
            // 
            dataGridViewrental_agreement_withname.BackgroundColor = SystemColors.Window;
            dataGridViewrental_agreement_withname.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewrental_agreement_withname.Location = new Point(816, -240);
            dataGridViewrental_agreement_withname.Name = "dataGridViewrental_agreement_withname";
            dataGridViewrental_agreement_withname.Size = new Size(287, 500);
            dataGridViewrental_agreement_withname.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(pictureBox3);
            panel5.Controls.Add(TotalRevenue);
            panel5.Controls.Add(progressBarRevenue);
            panel5.Controls.Add(label1);
            panel5.Location = new Point(1050, 14);
            panel5.Name = "panel5";
            panel5.Size = new Size(287, 138);
            panel5.TabIndex = 57;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.growth;
            pictureBox3.Location = new Point(156, 21);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(116, 100);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // TotalRevenue
            // 
            TotalRevenue.AutoSize = true;
            TotalRevenue.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalRevenue.Location = new Point(10, 28);
            TotalRevenue.Name = "TotalRevenue";
            TotalRevenue.Size = new Size(66, 30);
            TotalRevenue.TabIndex = 0;
            TotalRevenue.Text = "Pesos";
            // 
            // progressBarRevenue
            // 
            progressBarRevenue.Location = new Point(11, 93);
            progressBarRevenue.Name = "progressBarRevenue";
            progressBarRevenue.Size = new Size(136, 28);
            progressBarRevenue.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Window;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 70);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 12;
            label1.Text = "Revenue";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(dataGridViewFee);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(1050, 167);
            panel4.Name = "panel4";
            panel4.Size = new Size(287, 493);
            panel4.TabIndex = 58;
            // 
            // dataGridViewFee
            // 
            dataGridViewFee.BackgroundColor = SystemColors.Window;
            dataGridViewFee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFee.Location = new Point(0, 34);
            dataGridViewFee.Name = "dataGridViewFee";
            dataGridViewFee.Size = new Size(287, 459);
            dataGridViewFee.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(1, 1);
            label3.Name = "label3";
            label3.Size = new Size(46, 30);
            label3.TabIndex = 20;
            label3.Text = "Fee";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(dataGridViewpaid);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(dataGridView2);
            panel6.Location = new Point(616, 400);
            panel6.Name = "panel6";
            panel6.Size = new Size(417, 260);
            panel6.TabIndex = 57;
            panel6.Paint += panel6_Paint;
            // 
            // dataGridViewpaid
            // 
            dataGridViewpaid.BackgroundColor = SystemColors.Window;
            dataGridViewpaid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewpaid.Location = new Point(0, 28);
            dataGridViewpaid.Name = "dataGridViewpaid";
            dataGridViewpaid.Size = new Size(417, 232);
            dataGridViewpaid.TabIndex = 1;
            dataGridViewpaid.CellContentClick += dataGridViewpaid_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(1, 1);
            label4.Name = "label4";
            label4.Size = new Size(132, 30);
            label4.TabIndex = 19;
            label4.Text = "Paid Balance";
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = SystemColors.Window;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(816, -240);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(287, 500);
            dataGridView2.TabIndex = 2;
            // 
            // EmployeeForm4TANS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 691);
            Controls.Add(panel6);
            Controls.Add(panel4);
            Controls.Add(panel5);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(RENTALSbutton);
            Controls.Add(LOGOUT);
            Controls.Add(TRANSACTION);
            Controls.Add(ITEMS);
            Controls.Add(TENANT);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "EmployeeForm4TANS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm4TANS";
            Load += EmployeeForm4TANS_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridrental_agreement_details_withname).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewpayment).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewrental_agreement_withname).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFee).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewpaid).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button RENTALSbutton;
        private Button LOGOUT;
        private Button TRANSACTION;
        private Button ITEMS;
        private Button TENANT;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Button SearchBtmTRNS;
        private TextBox SearchTRNS;
        private Panel panel1;
        public Label label7;
        private DataGridView dataGridrental_agreement_details_withname;
        private Panel panel3;
        private DataGridView dataGridViewpayment;
        public Label label2;
        private DataGridView dataGridViewrental_agreement_withname;
        private Panel panel5;
        private PictureBox pictureBox3;
        public Label TotalRevenue;
        private ProgressBar progressBarRevenue;
        private Label label1;
        private Panel panel4;
        private DataGridView dataGridViewFee;
        public Label label3;
        private Panel panel6;
        private DataGridView dataGridViewpaid;
        public Label label4;
        private DataGridView dataGridView2;
    }
}