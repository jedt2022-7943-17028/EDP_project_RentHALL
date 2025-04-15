namespace WinFormsSampleApp1.Properties
{
    partial class AdminForm6TRS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm6TRS));
            EMPLOYEES = new Button();
            LOGOUT = new Button();
            RENTALS = new Button();
            TRANSACTION = new Button();
            INVENTORY = new Button();
            TENANT = new Button();
            DASHBOARD = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // EMPLOYEES
            // 
            EMPLOYEES.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EMPLOYEES.Location = new Point(25, 388);
            EMPLOYEES.Name = "EMPLOYEES";
            EMPLOYEES.Size = new Size(168, 40);
            EMPLOYEES.TabIndex = 43;
            EMPLOYEES.Text = "EMPLOYEES";
            EMPLOYEES.UseVisualStyleBackColor = true;
            EMPLOYEES.Click += EMPLOYEES_Click;
            // 
            // LOGOUT
            // 
            LOGOUT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOGOUT.Location = new Point(25, 632);
            LOGOUT.Name = "LOGOUT";
            LOGOUT.Size = new Size(168, 40);
            LOGOUT.TabIndex = 42;
            LOGOUT.Text = "LOGOUT";
            LOGOUT.UseVisualStyleBackColor = true;
            LOGOUT.Click += LOGOUT_Click;
            // 
            // RENTALS
            // 
            RENTALS.BackColor = Color.White;
            RENTALS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RENTALS.ForeColor = SystemColors.MenuText;
            RENTALS.Location = new Point(25, 269);
            RENTALS.Name = "RENTALS";
            RENTALS.Size = new Size(168, 40);
            RENTALS.TabIndex = 41;
            RENTALS.Text = "RENTALS";
            RENTALS.UseVisualStyleBackColor = false;
            RENTALS.Click += RENTALS_Click;
            // 
            // TRANSACTION
            // 
            TRANSACTION.BackColor = Color.Brown;
            TRANSACTION.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TRANSACTION.ForeColor = SystemColors.Window;
            TRANSACTION.Location = new Point(25, 446);
            TRANSACTION.Name = "TRANSACTION";
            TRANSACTION.Size = new Size(168, 40);
            TRANSACTION.TabIndex = 40;
            TRANSACTION.Text = "TRANSACTION";
            TRANSACTION.UseVisualStyleBackColor = false;
            TRANSACTION.Click += TRANSACTION_Click;
            // 
            // INVENTORY
            // 
            INVENTORY.BackColor = Color.White;
            INVENTORY.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            INVENTORY.ForeColor = SystemColors.ActiveCaptionText;
            INVENTORY.Location = new Point(25, 210);
            INVENTORY.Name = "INVENTORY";
            INVENTORY.Size = new Size(168, 40);
            INVENTORY.TabIndex = 39;
            INVENTORY.Text = "INVENTORY";
            INVENTORY.UseVisualStyleBackColor = false;
            INVENTORY.Click += INVENTORY_Click;
            // 
            // TENANT
            // 
            TENANT.BackColor = Color.White;
            TENANT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TENANT.ForeColor = SystemColors.MenuText;
            TENANT.Location = new Point(25, 329);
            TENANT.Name = "TENANT";
            TENANT.Size = new Size(168, 40);
            TENANT.TabIndex = 38;
            TENANT.Text = "TENANT";
            TENANT.UseVisualStyleBackColor = false;
            TENANT.Click += TENANT_Click;
            // 
            // DASHBOARD
            // 
            DASHBOARD.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DASHBOARD.Location = new Point(25, 152);
            DASHBOARD.Name = "DASHBOARD";
            DASHBOARD.Size = new Size(168, 40);
            DASHBOARD.TabIndex = 37;
            DASHBOARD.Text = "DASHBOARD";
            DASHBOARD.UseVisualStyleBackColor = true;
            DASHBOARD.Click += DASHBOARD_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Image = Resources._02053c90_9350_4488_8fd0_33a40144cd91_removebg_preview;
            pictureBox2.Location = new Point(25, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(168, 116);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 36;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Location = new Point(0, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 696);
            pictureBox1.TabIndex = 35;
            pictureBox1.TabStop = false;
            // 
            // AdminForm6TRS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 691);
            Controls.Add(EMPLOYEES);
            Controls.Add(LOGOUT);
            Controls.Add(RENTALS);
            Controls.Add(TRANSACTION);
            Controls.Add(INVENTORY);
            Controls.Add(TENANT);
            Controls.Add(DASHBOARD);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "AdminForm6TRS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm6TRS";
            Load += AdminForm6TRS_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button EMPLOYEES;
        private Button LOGOUT;
        private Button RENTALS;
        private Button TRANSACTION;
        private Button INVENTORY;
        private Button TENANT;
        private Button DASHBOARD;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
    }
}