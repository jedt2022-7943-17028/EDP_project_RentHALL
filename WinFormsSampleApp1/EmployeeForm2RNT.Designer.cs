namespace WinFormsSampleApp1.Properties
{
    partial class EmployeeForm2RNT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm2RNT));
            RENTALSbutton = new Button();
            LOGOUT = new Button();
            TRANSACTION = new Button();
            ITEMS = new Button();
            TENANT = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel7 = new Panel();
            label4 = new Label();
            NoAvlUnit = new Label();
            pictureBox9 = new PictureBox();
            Rented = new Label();
            TotalUnits = new Label();
            NoRentedUnit = new Label();
            Product = new Label();
            NoUnit = new Label();
            circularProgressBar1 = new CircularProgressBar();
            panel5 = new Panel();
            pictureBox7 = new PictureBox();
            OverdueRent = new Label();
            RentOverdue = new Label();
            panel4 = new Panel();
            pictureBox6 = new PictureBox();
            DueToday = new Label();
            RentDueToday = new Label();
            panel1 = new Panel();
            label2 = new Label();
            dataGridViewactive_rentals = new DataGridView();
            panel2 = new Panel();
            label1 = new Label();
            dataGridViewrental_history = new DataGridView();
            panel3 = new Panel();
            label3 = new Label();
            dataGridViewproduct_rental_summary = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewactive_rentals).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewrental_history).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewproduct_rental_summary).BeginInit();
            SuspendLayout();
            // 
            // RENTALSbutton
            // 
            RENTALSbutton.BackColor = Color.Brown;
            RENTALSbutton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RENTALSbutton.ForeColor = SystemColors.ControlLightLight;
            RENTALSbutton.Location = new Point(26, 207);
            RENTALSbutton.Name = "RENTALSbutton";
            RENTALSbutton.Size = new Size(168, 40);
            RENTALSbutton.TabIndex = 46;
            RENTALSbutton.Text = "RENTALS";
            RENTALSbutton.UseVisualStyleBackColor = false;
            RENTALSbutton.Click += RENTALSbutton_Click;
            // 
            // LOGOUT
            // 
            LOGOUT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOGOUT.Location = new Point(26, 574);
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
            TRANSACTION.Location = new Point(26, 326);
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
            ITEMS.Location = new Point(26, 147);
            ITEMS.Name = "ITEMS";
            ITEMS.Size = new Size(168, 40);
            ITEMS.TabIndex = 43;
            ITEMS.Text = "ITEMS";
            ITEMS.UseVisualStyleBackColor = false;
            ITEMS.Click += ITEMS_Click;
            // 
            // TENANT
            // 
            TENANT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TENANT.Location = new Point(26, 266);
            TENANT.Name = "TENANT";
            TENANT.Size = new Size(168, 40);
            TENANT.TabIndex = 42;
            TENANT.Text = "TENANT";
            TENANT.UseVisualStyleBackColor = true;
            TENANT.Click += TENANT_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Image = Resources._02053c90_9350_4488_8fd0_33a40144cd91_removebg_preview;
            pictureBox2.Location = new Point(26, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(168, 116);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 41;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Location = new Point(1, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 697);
            pictureBox1.TabIndex = 40;
            pictureBox1.TabStop = false;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Window;
            panel7.Controls.Add(label4);
            panel7.Controls.Add(NoAvlUnit);
            panel7.Controls.Add(pictureBox9);
            panel7.Controls.Add(Rented);
            panel7.Controls.Add(TotalUnits);
            panel7.Controls.Add(NoRentedUnit);
            panel7.Controls.Add(Product);
            panel7.Controls.Add(NoUnit);
            panel7.Controls.Add(circularProgressBar1);
            panel7.Location = new Point(239, 9);
            panel7.Name = "panel7";
            panel7.Size = new Size(475, 203);
            panel7.TabIndex = 47;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(313, 95);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 34;
            label4.Text = "Available";
            // 
            // NoAvlUnit
            // 
            NoAvlUnit.AutoSize = true;
            NoAvlUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoAvlUnit.Location = new Point(331, 62);
            NoAvlUnit.Name = "NoAvlUnit";
            NoAvlUnit.Size = new Size(33, 30);
            NoAvlUnit.TabIndex = 38;
            NoAvlUnit.Text = "12";
            // 
            // pictureBox9
            // 
            pictureBox9.Image = Resources.room_key;
            pictureBox9.Location = new Point(313, 132);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(72, 59);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 24;
            pictureBox9.TabStop = false;
            // 
            // Rented
            // 
            Rented.AutoSize = true;
            Rented.BackColor = SystemColors.Window;
            Rented.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Rented.Location = new Point(32, 135);
            Rented.Name = "Rented";
            Rented.Size = new Size(94, 20);
            Rented.TabIndex = 28;
            Rented.Text = "Rented Prod";
            // 
            // TotalUnits
            // 
            TotalUnits.AutoSize = true;
            TotalUnits.BackColor = SystemColors.Window;
            TotalUnits.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalUnits.Location = new Point(31, 67);
            TotalUnits.Name = "TotalUnits";
            TotalUnits.Size = new Size(79, 20);
            TotalUnits.TabIndex = 27;
            TotalUnits.Text = "Total Prod";
            // 
            // NoRentedUnit
            // 
            NoRentedUnit.AutoSize = true;
            NoRentedUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoRentedUnit.Location = new Point(139, 127);
            NoRentedUnit.Name = "NoRentedUnit";
            NoRentedUnit.Size = new Size(106, 30);
            NoRentedUnit.TabIndex = 37;
            NoRentedUnit.Text = "No. RUnit";
            // 
            // Product
            // 
            Product.AutoSize = true;
            Product.BackColor = SystemColors.Window;
            Product.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Product.Location = new Point(7, 9);
            Product.Name = "Product";
            Product.Size = new Size(85, 20);
            Product.TabIndex = 18;
            Product.Text = "PRODUCTS";
            // 
            // NoUnit
            // 
            NoUnit.AutoSize = true;
            NoUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoUnit.Location = new Point(139, 57);
            NoUnit.Name = "NoUnit";
            NoUnit.Size = new Size(93, 30);
            NoUnit.TabIndex = 36;
            NoUnit.Text = "No. Unit";
            // 
            // circularProgressBar1
            // 
            circularProgressBar1.BackColorArc = Color.LightGray;
            circularProgressBar1.Location = new Point(245, 14);
            circularProgressBar1.Maximum = 100;
            circularProgressBar1.Name = "circularProgressBar1";
            circularProgressBar1.ProgressColor = Color.DarkRed;
            circularProgressBar1.Size = new Size(210, 166);
            circularProgressBar1.TabIndex = 34;
            circularProgressBar1.Text = "circularProgressBar1";
            circularProgressBar1.Value = 0;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(pictureBox7);
            panel5.Controls.Add(OverdueRent);
            panel5.Controls.Add(RentOverdue);
            panel5.Location = new Point(728, 119);
            panel5.Name = "panel5";
            panel5.Size = new Size(293, 94);
            panel5.TabIndex = 49;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Resources.overdue;
            pictureBox7.Location = new Point(188, 7);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(88, 79);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 24;
            pictureBox7.TabStop = false;
            // 
            // OverdueRent
            // 
            OverdueRent.AutoSize = true;
            OverdueRent.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OverdueRent.Location = new Point(17, 18);
            OverdueRent.Name = "OverdueRent";
            OverdueRent.Size = new Size(144, 30);
            OverdueRent.TabIndex = 4;
            OverdueRent.Text = "Rent Overdue";
            // 
            // RentOverdue
            // 
            RentOverdue.AutoSize = true;
            RentOverdue.BackColor = SystemColors.Window;
            RentOverdue.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RentOverdue.Location = new Point(17, 59);
            RentOverdue.Name = "RentOverdue";
            RentOverdue.Size = new Size(103, 20);
            RentOverdue.TabIndex = 24;
            RentOverdue.Text = "Rent Overdue";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(pictureBox6);
            panel4.Controls.Add(DueToday);
            panel4.Controls.Add(RentDueToday);
            panel4.Location = new Point(729, 10);
            panel4.Name = "panel4";
            panel4.Size = new Size(292, 95);
            panel4.TabIndex = 48;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Resources.alert;
            pictureBox6.Location = new Point(187, 5);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(88, 83);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 13;
            pictureBox6.TabStop = false;
            // 
            // DueToday
            // 
            DueToday.AutoSize = true;
            DueToday.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DueToday.Location = new Point(10, 19);
            DueToday.Name = "DueToday";
            DueToday.Size = new Size(164, 30);
            DueToday.TabIndex = 3;
            DueToday.Text = "Rent Due Today";
            // 
            // RentDueToday
            // 
            RentDueToday.AutoSize = true;
            RentDueToday.BackColor = SystemColors.Window;
            RentDueToday.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RentDueToday.Location = new Point(10, 57);
            RentDueToday.Name = "RentDueToday";
            RentDueToday.Size = new Size(117, 20);
            RentDueToday.TabIndex = 23;
            RentDueToday.Text = "Rent Due Today";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dataGridViewactive_rentals);
            panel1.Location = new Point(239, 232);
            panel1.Name = "panel1";
            panel1.Size = new Size(787, 309);
            panel1.TabIndex = 50;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Window;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 10);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 41;
            label2.Text = "ACTIVE RENT";
            // 
            // dataGridViewactive_rentals
            // 
            dataGridViewactive_rentals.BackgroundColor = SystemColors.Window;
            dataGridViewactive_rentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewactive_rentals.Location = new Point(0, 40);
            dataGridViewactive_rentals.Name = "dataGridViewactive_rentals";
            dataGridViewactive_rentals.Size = new Size(788, 267);
            dataGridViewactive_rentals.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dataGridViewrental_history);
            panel2.Location = new Point(239, 552);
            panel2.Name = "panel2";
            panel2.Size = new Size(1097, 132);
            panel2.TabIndex = 51;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Window;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 39;
            label1.Text = "HISTORY";
            // 
            // dataGridViewrental_history
            // 
            dataGridViewrental_history.BackgroundColor = SystemColors.Window;
            dataGridViewrental_history.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewrental_history.Location = new Point(0, 35);
            dataGridViewrental_history.Name = "dataGridViewrental_history";
            dataGridViewrental_history.Size = new Size(1097, 97);
            dataGridViewrental_history.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(dataGridViewproduct_rental_summary);
            panel3.Location = new Point(1048, 9);
            panel3.Name = "panel3";
            panel3.Size = new Size(288, 526);
            panel3.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 11);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 40;
            label3.Text = "SUMMARY";
            // 
            // dataGridViewproduct_rental_summary
            // 
            dataGridViewproduct_rental_summary.BackgroundColor = SystemColors.Window;
            dataGridViewproduct_rental_summary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewproduct_rental_summary.Location = new Point(0, 40);
            dataGridViewproduct_rental_summary.Name = "dataGridViewproduct_rental_summary";
            dataGridViewproduct_rental_summary.Size = new Size(288, 484);
            dataGridViewproduct_rental_summary.TabIndex = 2;
            // 
            // EmployeeForm2RNT
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 691);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel7);
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
            Name = "EmployeeForm2RNT";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm2RNT";
            Load += EmployeeForm2RNT_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewactive_rentals).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewrental_history).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewproduct_rental_summary).EndInit();
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
        private Panel panel7;
        private Label label4;
        public Label NoAvlUnit;
        private PictureBox pictureBox9;
        private Label Rented;
        private Label TotalUnits;
        public Label NoRentedUnit;
        private Label Product;
        public Label NoUnit;
        private CircularProgressBar circularProgressBar1;
        private Panel panel5;
        private PictureBox pictureBox7;
        public Label OverdueRent;
        private Label RentOverdue;
        private Panel panel4;
        private PictureBox pictureBox6;
        public Label DueToday;
        private Label RentDueToday;
        private Panel panel1;
        private Label label2;
        private DataGridView dataGridViewactive_rentals;
        private Panel panel2;
        private Label label1;
        private DataGridView dataGridViewrental_history;
        private Panel panel3;
        private Label label3;
        private DataGridView dataGridViewproduct_rental_summary;
    }
}