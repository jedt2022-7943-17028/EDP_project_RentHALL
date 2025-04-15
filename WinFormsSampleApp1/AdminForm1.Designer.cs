namespace WinFormsSampleApp1
{
    partial class AdminForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm1));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            DASHBOARD = new Button();
            TENANT = new Button();
            INVENTORY = new Button();
            TRANSACTION = new Button();
            RENTALS = new Button();
            LOGOUT = new Button();
            EMPLOYEES = new Button();
            monthCalendar1 = new MonthCalendar();
            progressBarRevenue = new ProgressBar();
            label1 = new Label();
            Employee = new Label();
            Tenants = new Label();
            Units = new Label();
            RentDueToday = new Label();
            RentOverdue = new Label();
            Expiring = new Label();
            Activity = new Label();
            TotalUnits = new Label();
            Rented = new Label();
            ActiveRentalsDataGridView = new DataGridView();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            TotalRevenue = new Label();
            panel2 = new Panel();
            pictureBox6 = new PictureBox();
            DueToday = new Label();
            panel3 = new Panel();
            pictureBox7 = new PictureBox();
            OverdueRent = new Label();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            EmpNo = new Label();
            label2 = new Label();
            panel5 = new Panel();
            pictureBox5 = new PictureBox();
            TenantNo = new Label();
            panel6 = new Panel();
            pictureBox8 = new PictureBox();
            NoExpd = new Label();
            NoExp = new Label();
            label3 = new Label();
            panel7 = new Panel();
            pictureBox9 = new PictureBox();
            label4 = new Label();
            NoAvlUnit = new Label();
            NoRentedUnit = new Label();
            NoUnit = new Label();
            circularProgressBar1 = new WinFormsSampleApp1.Properties.CircularProgressBar();
            panel8 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ActiveRentalsDataGridView).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Location = new Point(-3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 697);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Image = Properties.Resources._02053c90_9350_4488_8fd0_33a40144cd91_removebg_preview;
            pictureBox2.Location = new Point(22, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(168, 116);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // DASHBOARD
            // 
            DASHBOARD.BackColor = Color.Brown;
            DASHBOARD.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DASHBOARD.ForeColor = SystemColors.Control;
            DASHBOARD.Location = new Point(22, 153);
            DASHBOARD.Name = "DASHBOARD";
            DASHBOARD.Size = new Size(168, 40);
            DASHBOARD.TabIndex = 2;
            DASHBOARD.Text = "DASHBOARD";
            DASHBOARD.UseVisualStyleBackColor = false;
            DASHBOARD.Click += DASHBOARD_Click;
            // 
            // TENANT
            // 
            TENANT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TENANT.Location = new Point(22, 330);
            TENANT.Name = "TENANT";
            TENANT.Size = new Size(168, 40);
            TENANT.TabIndex = 3;
            TENANT.Text = "TENANT";
            TENANT.UseVisualStyleBackColor = true;
            TENANT.Click += TENANT_Click;
            // 
            // INVENTORY
            // 
            INVENTORY.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            INVENTORY.Location = new Point(22, 211);
            INVENTORY.Name = "INVENTORY";
            INVENTORY.Size = new Size(168, 40);
            INVENTORY.TabIndex = 4;
            INVENTORY.Text = "INVENTORY";
            INVENTORY.UseVisualStyleBackColor = true;
            INVENTORY.Click += INVENTORY_Click;
            // 
            // TRANSACTION
            // 
            TRANSACTION.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TRANSACTION.Location = new Point(22, 447);
            TRANSACTION.Name = "TRANSACTION";
            TRANSACTION.Size = new Size(168, 40);
            TRANSACTION.TabIndex = 5;
            TRANSACTION.Text = "TRANSACTION";
            TRANSACTION.UseVisualStyleBackColor = true;
            TRANSACTION.Click += TRANSACTION_Click;
            // 
            // RENTALS
            // 
            RENTALS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RENTALS.Location = new Point(22, 270);
            RENTALS.Name = "RENTALS";
            RENTALS.Size = new Size(168, 40);
            RENTALS.TabIndex = 6;
            RENTALS.Text = "RENTALS";
            RENTALS.UseVisualStyleBackColor = true;
            RENTALS.Click += RENTALS_Click;
            // 
            // LOGOUT
            // 
            LOGOUT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOGOUT.Location = new Point(22, 577);
            LOGOUT.Name = "LOGOUT";
            LOGOUT.Size = new Size(168, 40);
            LOGOUT.TabIndex = 7;
            LOGOUT.Text = "LOGOUT";
            LOGOUT.UseVisualStyleBackColor = true;
            LOGOUT.Click += LOGOUT_Click;
            // 
            // EMPLOYEES
            // 
            EMPLOYEES.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EMPLOYEES.Location = new Point(22, 389);
            EMPLOYEES.Name = "EMPLOYEES";
            EMPLOYEES.Size = new Size(168, 40);
            EMPLOYEES.TabIndex = 8;
            EMPLOYEES.Text = "EMPLOYEES";
            EMPLOYEES.UseVisualStyleBackColor = true;
            EMPLOYEES.Click += EMPLOYEES_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            monthCalendar1.Location = new Point(1092, 18);
            monthCalendar1.MaximumSize = new Size(237, 172);
            monthCalendar1.MinimumSize = new Size(237, 172);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 10;
            // 
            // progressBarRevenue
            // 
            progressBarRevenue.Location = new Point(10, 93);
            progressBarRevenue.Name = "progressBarRevenue";
            progressBarRevenue.Size = new Size(121, 28);
            progressBarRevenue.TabIndex = 11;
            progressBarRevenue.Click += progressBarRevenue_Click;
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
            label1.Click += label1_Click;
            // 
            // Employee
            // 
            Employee.AutoSize = true;
            Employee.BackColor = SystemColors.Window;
            Employee.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Employee.Location = new Point(17, 70);
            Employee.Name = "Employee";
            Employee.Size = new Size(76, 20);
            Employee.TabIndex = 15;
            Employee.Text = "Employee";
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
            // Units
            // 
            Units.AutoSize = true;
            Units.BackColor = SystemColors.Window;
            Units.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Units.Location = new Point(7, 13);
            Units.Name = "Units";
            Units.Size = new Size(85, 20);
            Units.TabIndex = 18;
            Units.Text = "PRODUCTS";
            // 
            // RentDueToday
            // 
            RentDueToday.AutoSize = true;
            RentDueToday.BackColor = SystemColors.Window;
            RentDueToday.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RentDueToday.Location = new Point(10, 79);
            RentDueToday.Name = "RentDueToday";
            RentDueToday.Size = new Size(117, 20);
            RentDueToday.TabIndex = 23;
            RentDueToday.Text = "Rent Due Today";
            // 
            // RentOverdue
            // 
            RentOverdue.AutoSize = true;
            RentOverdue.BackColor = SystemColors.Window;
            RentOverdue.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RentOverdue.Location = new Point(17, 79);
            RentOverdue.Name = "RentOverdue";
            RentOverdue.Size = new Size(103, 20);
            RentOverdue.TabIndex = 24;
            RentOverdue.Text = "Rent Overdue";
            // 
            // Expiring
            // 
            Expiring.AutoSize = true;
            Expiring.BackColor = SystemColors.Window;
            Expiring.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Expiring.Location = new Point(13, 38);
            Expiring.Name = "Expiring";
            Expiring.Size = new Size(66, 20);
            Expiring.TabIndex = 25;
            Expiring.Text = "Expiring";
            // 
            // Activity
            // 
            Activity.AutoSize = true;
            Activity.BackColor = SystemColors.Window;
            Activity.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Activity.Location = new Point(246, 340);
            Activity.Name = "Activity";
            Activity.Size = new Size(86, 20);
            Activity.TabIndex = 26;
            Activity.Text = "Active Rent";
            // 
            // TotalUnits
            // 
            TotalUnits.AutoSize = true;
            TotalUnits.BackColor = SystemColors.Window;
            TotalUnits.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalUnits.Location = new Point(14, 331);
            TotalUnits.Name = "TotalUnits";
            TotalUnits.Size = new Size(79, 20);
            TotalUnits.TabIndex = 27;
            TotalUnits.Text = "Total Prod";
            // 
            // Rented
            // 
            Rented.AutoSize = true;
            Rented.BackColor = SystemColors.Window;
            Rented.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Rented.Location = new Point(14, 404);
            Rented.Name = "Rented";
            Rented.Size = new Size(94, 20);
            Rented.TabIndex = 28;
            Rented.Text = "Rented Prod";
            // 
            // ActiveRentalsDataGridView
            // 
            ActiveRentalsDataGridView.BackgroundColor = SystemColors.Window;
            ActiveRentalsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ActiveRentalsDataGridView.Location = new Point(246, 366);
            ActiveRentalsDataGridView.Name = "ActiveRentalsDataGridView";
            ActiveRentalsDataGridView.Size = new Size(810, 313);
            ActiveRentalsDataGridView.TabIndex = 29;
            ActiveRentalsDataGridView.CellContentClick += ActiveRentals_CellContentClick;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(TotalRevenue);
            panel1.Controls.Add(progressBarRevenue);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(236, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(266, 138);
            panel1.TabIndex = 30;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.growth;
            pictureBox3.Location = new Point(149, 28);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(95, 88);
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
            TotalRevenue.Click += TotalRevenue_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(pictureBox6);
            panel2.Controls.Add(DueToday);
            panel2.Controls.Add(RentDueToday);
            panel2.Location = new Point(236, 177);
            panel2.Name = "panel2";
            panel2.Size = new Size(266, 138);
            panel2.TabIndex = 31;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.alert;
            pictureBox6.Location = new Point(149, 25);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(95, 88);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 13;
            pictureBox6.TabStop = false;
            // 
            // DueToday
            // 
            DueToday.AutoSize = true;
            DueToday.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DueToday.Location = new Point(10, 25);
            DueToday.Name = "DueToday";
            DueToday.Size = new Size(164, 30);
            DueToday.TabIndex = 3;
            DueToday.Text = "Rent Due Today";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(pictureBox7);
            panel3.Controls.Add(OverdueRent);
            panel3.Controls.Add(RentOverdue);
            panel3.Location = new Point(517, 177);
            panel3.Name = "panel3";
            panel3.Size = new Size(266, 138);
            panel3.TabIndex = 32;
            // 
            // pictureBox7
            // 
            pictureBox7.Image = Properties.Resources.overdue;
            pictureBox7.Location = new Point(154, 25);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(95, 88);
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.TabIndex = 24;
            pictureBox7.TabStop = false;
            // 
            // OverdueRent
            // 
            OverdueRent.AutoSize = true;
            OverdueRent.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OverdueRent.Location = new Point(17, 25);
            OverdueRent.Name = "OverdueRent";
            OverdueRent.Size = new Size(144, 30);
            OverdueRent.TabIndex = 4;
            OverdueRent.Text = "Rent Overdue";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(EmpNo);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(Employee);
            panel4.Location = new Point(517, 16);
            panel4.Name = "panel4";
            panel4.Size = new Size(266, 138);
            panel4.TabIndex = 31;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Properties.Resources.employee;
            pictureBox4.Location = new Point(148, 21);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(101, 100);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // EmpNo
            // 
            EmpNo.AutoSize = true;
            EmpNo.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmpNo.Location = new Point(17, 28);
            EmpNo.Name = "EmpNo";
            EmpNo.Size = new Size(96, 30);
            EmpNo.TabIndex = 1;
            EmpNo.Text = "Emp No.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 57);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.Window;
            panel5.Controls.Add(pictureBox5);
            panel5.Controls.Add(TenantNo);
            panel5.Controls.Add(Tenants);
            panel5.Location = new Point(800, 15);
            panel5.Name = "panel5";
            panel5.Size = new Size(266, 138);
            panel5.TabIndex = 31;
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
            TenantNo.Location = new Point(13, 28);
            TenantNo.Name = "TenantNo";
            TenantNo.Size = new Size(126, 30);
            TenantNo.TabIndex = 2;
            TenantNo.Text = "Tenants No.";
            // 
            // panel6
            // 
            panel6.BackColor = SystemColors.Window;
            panel6.Controls.Add(pictureBox8);
            panel6.Controls.Add(NoExpd);
            panel6.Controls.Add(NoExp);
            panel6.Controls.Add(label3);
            panel6.Controls.Add(Expiring);
            panel6.Location = new Point(800, 177);
            panel6.Name = "panel6";
            panel6.Size = new Size(266, 138);
            panel6.TabIndex = 31;
            // 
            // pictureBox8
            // 
            pictureBox8.Image = Properties.Resources.warning;
            pictureBox8.Location = new Point(150, 25);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(95, 88);
            pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox8.TabIndex = 25;
            pictureBox8.TabStop = false;
            // 
            // NoExpd
            // 
            NoExpd.AutoSize = true;
            NoExpd.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoExpd.Location = new Point(13, 69);
            NoExpd.Name = "NoExpd";
            NoExpd.Size = new Size(125, 30);
            NoExpd.TabIndex = 35;
            NoExpd.Text = "No. Expired";
            // 
            // NoExp
            // 
            NoExp.AutoSize = true;
            NoExp.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoExp.Location = new Point(13, 8);
            NoExp.Name = "NoExp";
            NoExp.Size = new Size(131, 30);
            NoExp.TabIndex = 5;
            NoExp.Text = "No. Expiring";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 103);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 34;
            label3.Text = "Expired";
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Window;
            panel7.Controls.Add(pictureBox9);
            panel7.Controls.Add(Rented);
            panel7.Controls.Add(TotalUnits);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(NoAvlUnit);
            panel7.Controls.Add(NoRentedUnit);
            panel7.Controls.Add(Units);
            panel7.Controls.Add(NoUnit);
            panel7.Controls.Add(circularProgressBar1);
            panel7.Location = new Point(1092, 202);
            panel7.Name = "panel7";
            panel7.Size = new Size(237, 477);
            panel7.TabIndex = 31;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = Properties.Resources.room_key;
            pictureBox9.Location = new Point(86, 210);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(63, 61);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 24;
            pictureBox9.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(81, 172);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 34;
            label4.Text = "Available";
            label4.Click += label4_Click;
            // 
            // NoAvlUnit
            // 
            NoAvlUnit.AutoSize = true;
            NoAvlUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoAvlUnit.Location = new Point(100, 138);
            NoAvlUnit.Name = "NoAvlUnit";
            NoAvlUnit.Size = new Size(33, 30);
            NoAvlUnit.TabIndex = 38;
            NoAvlUnit.Text = "12";
            // 
            // NoRentedUnit
            // 
            NoRentedUnit.AutoSize = true;
            NoRentedUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoRentedUnit.Location = new Point(108, 396);
            NoRentedUnit.Name = "NoRentedUnit";
            NoRentedUnit.Size = new Size(106, 30);
            NoRentedUnit.TabIndex = 37;
            NoRentedUnit.Text = "No. RUnit";
            // 
            // NoUnit
            // 
            NoUnit.AutoSize = true;
            NoUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoUnit.Location = new Point(108, 331);
            NoUnit.Name = "NoUnit";
            NoUnit.Size = new Size(93, 30);
            NoUnit.TabIndex = 36;
            NoUnit.Text = "No. Unit";
            // 
            // circularProgressBar1
            // 
            circularProgressBar1.BackColorArc = Color.LightGray;
            circularProgressBar1.Location = new Point(-17, 68);
            circularProgressBar1.Maximum = 100;
            circularProgressBar1.Name = "circularProgressBar1";
            circularProgressBar1.ProgressColor = Color.DarkRed;
            circularProgressBar1.Size = new Size(268, 183);
            circularProgressBar1.TabIndex = 34;
            circularProgressBar1.Text = "circularProgressBar1";
            circularProgressBar1.Value = 0;
            circularProgressBar1.Click += circularProgressBar1_Click;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.Window;
            panel8.Location = new Point(236, 330);
            panel8.Name = "panel8";
            panel8.Size = new Size(830, 359);
            panel8.TabIndex = 33;
            // 
            // AdminForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(1354, 691);
            Controls.Add(ActiveRentalsDataGridView);
            Controls.Add(Activity);
            Controls.Add(monthCalendar1);
            Controls.Add(EMPLOYEES);
            Controls.Add(LOGOUT);
            Controls.Add(RENTALS);
            Controls.Add(TRANSACTION);
            Controls.Add(INVENTORY);
            Controls.Add(TENANT);
            Controls.Add(DASHBOARD);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel5);
            Controls.Add(panel4);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "AdminForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm1";
            Load += AdminForm1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)ActiveRentalsDataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button DASHBOARD;
        private Button TENANT;
        private Button INVENTORY;
        private Button TRANSACTION;
        private Button RENTALS;
        private Button LOGOUT;
        private Button EMPLOYEES;
        private MonthCalendar monthCalendar1;
        private ProgressBar progressBarRevenue;
        private Label label1;
        private Label Employee;
        private Label Tenants;
        private Label Units;
        private Label RentDueToday;
        private Label RentOverdue;
        private Label Expiring;
        private Label Activity;
        private Label TotalUnits;
        private Label Rented;
        private DataGridView ActiveRentalsDataGridView;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        public Label TotalRevenue;
        public Label EmpNo;
        private Label label2;
        public Label TenantNo;
        public Label DueToday;
        public Label OverdueRent;
        public Label NoExpd;
        public Label NoExp;
        private Label label3;
        public Label NoRentedUnit;
        public Label NoUnit;
        public Label NoAvlUnit;
        private Label label4;
        private Properties.CircularProgressBar circularProgressBar1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
    }
}