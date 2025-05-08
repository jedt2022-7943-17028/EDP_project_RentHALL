namespace WinFormsSampleApp1
{
    partial class EmployeeForm3TNT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm3TNT));
            RENTALSbutton = new Button();
            LOGOUT = new Button();
            TRANSACTION = new Button();
            ITEMS = new Button();
            TENANT = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            pictureBox5 = new PictureBox();
            TenantNo = new Label();
            Tenants = new Label();
            panel1 = new Panel();
            InsertGovIdBtn = new Button();
            InsertTenantbutton = new Button();
            label5 = new Label();
            TNTgivIDnotextBox = new TextBox();
            label4 = new Label();
            TNTmobileNotextBox = new TextBox();
            label3 = new Label();
            TNTemailtextBox = new TextBox();
            label2 = new Label();
            TNTnametextBox = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            dataGridViewTenant = new DataGridView();
            SearchBtmTenant = new Button();
            SearchTenant = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTenant).BeginInit();
            SuspendLayout();
            // 
            // RENTALSbutton
            // 
            RENTALSbutton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RENTALSbutton.Location = new Point(24, 209);
            RENTALSbutton.Name = "RENTALSbutton";
            RENTALSbutton.Size = new Size(168, 40);
            RENTALSbutton.TabIndex = 46;
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
            LOGOUT.TabIndex = 45;
            LOGOUT.Text = "LOGOUT";
            LOGOUT.UseVisualStyleBackColor = true;
            LOGOUT.Click += LOGOUT_Click;
            // 
            // TRANSACTION
            // 
            TRANSACTION.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TRANSACTION.Location = new Point(24, 328);
            TRANSACTION.Name = "TRANSACTION";
            TRANSACTION.Size = new Size(168, 40);
            TRANSACTION.TabIndex = 44;
            TRANSACTION.Text = "TRANSACTION";
            TRANSACTION.UseVisualStyleBackColor = true;
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
            ITEMS.TabIndex = 43;
            ITEMS.Text = "ITEMS";
            ITEMS.UseVisualStyleBackColor = false;
            ITEMS.Click += ITEMS_Click;
            // 
            // TENANT
            // 
            TENANT.BackColor = Color.Brown;
            TENANT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TENANT.ForeColor = SystemColors.ControlLightLight;
            TENANT.Location = new Point(24, 268);
            TENANT.Name = "TENANT";
            TENANT.Size = new Size(168, 40);
            TENANT.TabIndex = 42;
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
            pictureBox2.TabIndex = 41;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Location = new Point(-1, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 697);
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(pictureBox5);
            panel5.Controls.Add(TenantNo);
            panel5.Controls.Add(Tenants);
            panel5.Location = new Point(238, 15);
            panel5.Name = "panel5";
            panel5.Size = new Size(266, 138);
            panel5.TabIndex = 47;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = Properties.Resources.renter;
            pictureBox5.Location = new Point(145, 17);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(101, 100);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 16;
            pictureBox5.TabStop = false;
            // 
            // TenantNo
            // 
            TenantNo.AutoSize = true;
            TenantNo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TenantNo.Location = new Point(22, 28);
            TenantNo.Name = "TenantNo";
            TenantNo.Size = new Size(126, 30);
            TenantNo.TabIndex = 2;
            TenantNo.Text = "Tenants No.";
            // 
            // Tenants
            // 
            Tenants.AutoSize = true;
            Tenants.BackColor = SystemColors.Window;
            Tenants.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Tenants.Location = new Point(13, 70);
            Tenants.Name = "Tenants";
            Tenants.Size = new Size(61, 20);
            Tenants.TabIndex = 16;
            Tenants.Text = "Tenants";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(InsertGovIdBtn);
            panel1.Controls.Add(InsertTenantbutton);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TNTgivIDnotextBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TNTmobileNotextBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TNTemailtextBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(TNTnametextBox);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(238, 173);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 506);
            panel1.TabIndex = 48;
            // 
            // InsertGovIdBtn
            // 
            InsertGovIdBtn.Location = new Point(22, 378);
            InsertGovIdBtn.Name = "InsertGovIdBtn";
            InsertGovIdBtn.Size = new Size(99, 23);
            InsertGovIdBtn.TabIndex = 28;
            InsertGovIdBtn.Text = "Brows File";
            InsertGovIdBtn.UseVisualStyleBackColor = true;
            InsertGovIdBtn.Click += InsertGovIdBtn_Click_1;
            // 
            // InsertTenantbutton
            // 
            InsertTenantbutton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            InsertTenantbutton.Location = new Point(63, 425);
            InsertTenantbutton.Name = "InsertTenantbutton";
            InsertTenantbutton.Size = new Size(119, 43);
            InsertTenantbutton.TabIndex = 27;
            InsertTenantbutton.Text = "Submit";
            InsertTenantbutton.UseVisualStyleBackColor = true;
            InsertTenantbutton.Click += InsertTenantbutton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Window;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(22, 289);
            label5.Name = "label5";
            label5.Size = new Size(82, 20);
            label5.TabIndex = 23;
            label5.Text = "Gov Id No.";
            // 
            // TNTgivIDnotextBox
            // 
            TNTgivIDnotextBox.Location = new Point(21, 312);
            TNTgivIDnotextBox.MinimumSize = new Size(210, 23);
            TNTgivIDnotextBox.Name = "TNTgivIDnotextBox";
            TNTgivIDnotextBox.Size = new Size(223, 23);
            TNTgivIDnotextBox.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(21, 216);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 21;
            label4.Text = "Mobile No.";
            // 
            // TNTmobileNotextBox
            // 
            TNTmobileNotextBox.Location = new Point(20, 239);
            TNTmobileNotextBox.MinimumSize = new Size(210, 23);
            TNTmobileNotextBox.Name = "TNTmobileNotextBox";
            TNTmobileNotextBox.Size = new Size(223, 23);
            TNTmobileNotextBox.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(21, 147);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 19;
            label3.Text = "Email";
            // 
            // TNTemailtextBox
            // 
            TNTemailtextBox.Location = new Point(20, 170);
            TNTemailtextBox.MinimumSize = new Size(210, 23);
            TNTemailtextBox.Name = "TNTemailtextBox";
            TNTemailtextBox.Size = new Size(223, 23);
            TNTemailtextBox.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Window;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 80);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 17;
            label2.Text = "Full Name";
            // 
            // TNTnametextBox
            // 
            TNTnametextBox.Location = new Point(20, 103);
            TNTnametextBox.MinimumSize = new Size(210, 23);
            TNTnametextBox.Name = "TNTnametextBox";
            TNTnametextBox.Size = new Size(223, 23);
            TNTnametextBox.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(64, 17);
            label1.Name = "label1";
            label1.Size = new Size(132, 30);
            label1.TabIndex = 17;
            label1.Text = "Add Tenants";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ScrollBar;
            panel2.Controls.Add(dataGridViewTenant);
            panel2.Controls.Add(SearchBtmTenant);
            panel2.Controls.Add(SearchTenant);
            panel2.Location = new Point(530, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(799, 661);
            panel2.TabIndex = 49;
            // 
            // dataGridViewTenant
            // 
            dataGridViewTenant.BackgroundColor = SystemColors.ControlLightLight;
            dataGridViewTenant.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTenant.Location = new Point(31, 86);
            dataGridViewTenant.Name = "dataGridViewTenant";
            dataGridViewTenant.Size = new Size(743, 546);
            dataGridViewTenant.TabIndex = 4;
            // 
            // SearchBtmTenant
            // 
            SearchBtmTenant.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchBtmTenant.Location = new Point(618, 21);
            SearchBtmTenant.Name = "SearchBtmTenant";
            SearchBtmTenant.Size = new Size(156, 40);
            SearchBtmTenant.TabIndex = 3;
            SearchBtmTenant.Text = "Search";
            SearchBtmTenant.UseVisualStyleBackColor = true;
            SearchBtmTenant.Click += SearchBtmTenant_Click;
            // 
            // SearchTenant
            // 
            SearchTenant.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchTenant.Location = new Point(33, 21);
            SearchTenant.MaximumSize = new Size(200, 250);
            SearchTenant.MinimumSize = new Size(570, 40);
            SearchTenant.Name = "SearchTenant";
            SearchTenant.Size = new Size(570, 40);
            SearchTenant.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Window;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(25, 355);
            label6.Name = "label6";
            label6.Size = new Size(96, 20);
            label6.TabIndex = 50;
            label6.Text = "Insert Img ID";
            // 
            // EmployeeForm3TNT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 691);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel5);
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
            Name = "EmployeeForm3TNT";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm3TNT";
            Load += EmployeeForm3TNT_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTenant).EndInit();
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
        private Panel panel5;
        private PictureBox pictureBox5;
        public Label TenantNo;
        private Label Tenants;
        private Panel panel1;
        private Button InsertTenantbutton;
        private Label label5;
        private TextBox TNTgivIDnotextBox;
        private OpenFileDialog openFileDialog1;
        private Label label4;
        private TextBox TNTmobileNotextBox;
        private Label label3;
        private TextBox TNTemailtextBox;
        private Label label2;
        private TextBox TNTnametextBox;
        public Label label1;
        private Panel panel2;
        private DataGridView dataGridViewTenant;
        private Button SearchBtmTenant;
        private TextBox SearchTenant;
        private Button InsertGovIdBtn;
        private Label label6;
    }
}