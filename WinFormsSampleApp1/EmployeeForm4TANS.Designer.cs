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
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            // EmployeeForm4TANS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 691);
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
    }
}