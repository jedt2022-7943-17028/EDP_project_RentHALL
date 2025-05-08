namespace WinFormsSampleApp1.Properties
{
    partial class EmployeeForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeForm1));
            LOGOUT = new Button();
            TRANSACTION = new Button();
            ITEMS = new Button();
            TENANT = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            EmpName = new Label();
            Employee = new Label();
            panel4 = new Panel();
            label6 = new Label();
            label2 = new Label();
            panel7 = new Panel();
            pictureBox9 = new PictureBox();
            Rented = new Label();
            TotalUnits = new Label();
            label4 = new Label();
            NoAvlUnit = new Label();
            NoRentedUnit = new Label();
            Units = new Label();
            NoUnit = new Label();
            circularProgressBar1 = new CircularProgressBar();
            panel3 = new Panel();
            label1 = new Label();
            dataGridViewItemSummary = new DataGridView();
            RENTALSbutton = new Button();
            panel8 = new Panel();
            label10 = new Label();
            label9 = new Label();
            dataGridViewINV = new DataGridView();
            dataGridViewProd = new DataGridView();
            panel1 = new Panel();
            SearchBtm = new Button();
            SearchBox = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItemSummary).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewINV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProd).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LOGOUT
            // 
            LOGOUT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOGOUT.Location = new Point(24, 577);
            LOGOUT.Name = "LOGOUT";
            LOGOUT.Size = new Size(168, 40);
            LOGOUT.TabIndex = 16;
            LOGOUT.Text = "LOGOUT";
            LOGOUT.UseVisualStyleBackColor = true;
            LOGOUT.Click += LOGOUT_Click;
            // 
            // TRANSACTION
            // 
            TRANSACTION.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TRANSACTION.Location = new Point(24, 329);
            TRANSACTION.Name = "TRANSACTION";
            TRANSACTION.Size = new Size(168, 40);
            TRANSACTION.TabIndex = 14;
            TRANSACTION.Text = "TRANSACTION";
            TRANSACTION.UseVisualStyleBackColor = true;
            TRANSACTION.Click += TRANSACTION_Click;
            // 
            // ITEMS
            // 
            ITEMS.BackColor = Color.Brown;
            ITEMS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ITEMS.ForeColor = SystemColors.Window;
            ITEMS.Location = new Point(24, 150);
            ITEMS.Name = "ITEMS";
            ITEMS.Size = new Size(168, 40);
            ITEMS.TabIndex = 13;
            ITEMS.Text = "ITEMS";
            ITEMS.UseVisualStyleBackColor = false;
            ITEMS.Click += ITEMS_Click;
            // 
            // TENANT
            // 
            TENANT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TENANT.Location = new Point(24, 269);
            TENANT.Name = "TENANT";
            TENANT.Size = new Size(168, 40);
            TENANT.TabIndex = 12;
            TENANT.Text = "TENANT";
            TENANT.UseVisualStyleBackColor = true;
            TENANT.Click += TENANT_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Image = Resources._02053c90_9350_4488_8fd0_33a40144cd91_removebg_preview;
            pictureBox2.Location = new Point(24, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(168, 116);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Location = new Point(-1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 697);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = Resources.employee1;
            pictureBox4.Location = new Point(173, 11);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(79, 74);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // EmpName
            // 
            EmpName.AutoSize = true;
            EmpName.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EmpName.Location = new Point(22, 24);
            EmpName.Name = "EmpName";
            EmpName.Size = new Size(119, 30);
            EmpName.TabIndex = 1;
            EmpName.Text = "Emp Name";
            // 
            // Employee
            // 
            Employee.AutoSize = true;
            Employee.BackColor = SystemColors.Window;
            Employee.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Employee.Location = new Point(22, 58);
            Employee.Name = "Employee";
            Employee.Size = new Size(76, 20);
            Employee.TabIndex = 15;
            Employee.Text = "Employee";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(label6);
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(EmpName);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(Employee);
            panel4.Location = new Point(1076, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(266, 98);
            panel4.TabIndex = 32;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Window;
            label6.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 103);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 57);
            label2.Name = "label2";
            label2.Size = new Size(0, 15);
            label2.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.BackColor = SystemColors.Window;
            panel7.Controls.Add(label3);
            panel7.Controls.Add(pictureBox9);
            panel7.Controls.Add(Rented);
            panel7.Controls.Add(TotalUnits);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(NoAvlUnit);
            panel7.Controls.Add(NoRentedUnit);
            panel7.Controls.Add(Units);
            panel7.Controls.Add(NoUnit);
            panel7.Controls.Add(circularProgressBar1);
            panel7.Location = new Point(1076, 138);
            panel7.Name = "panel7";
            panel7.Size = new Size(266, 171);
            panel7.TabIndex = 33;
            // 
            // pictureBox9
            // 
            pictureBox9.Image = Resources.room_key1;
            pictureBox9.Location = new Point(173, 117);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(41, 33);
            pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox9.TabIndex = 24;
            pictureBox9.TabStop = false;
            // 
            // Rented
            // 
            Rented.Location = new Point(0, 0);
            Rented.Name = "Rented";
            Rented.Size = new Size(100, 23);
            Rented.TabIndex = 25;
            // 
            // TotalUnits
            // 
            TotalUnits.AutoSize = true;
            TotalUnits.BackColor = SystemColors.Window;
            TotalUnits.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TotalUnits.Location = new Point(14, 74);
            TotalUnits.Name = "TotalUnits";
            TotalUnits.Size = new Size(46, 20);
            TotalUnits.TabIndex = 27;
            TotalUnits.Text = "Total ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(160, 88);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 34;
            label4.Text = "Available";
            // 
            // NoAvlUnit
            // 
            NoAvlUnit.AutoSize = true;
            NoAvlUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoAvlUnit.Location = new Point(179, 58);
            NoAvlUnit.Name = "NoAvlUnit";
            NoAvlUnit.Size = new Size(33, 30);
            NoAvlUnit.TabIndex = 38;
            NoAvlUnit.Text = "12";
            // 
            // NoRentedUnit
            // 
            NoRentedUnit.AutoSize = true;
            NoRentedUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoRentedUnit.Location = new Point(15, 100);
            NoRentedUnit.Name = "NoRentedUnit";
            NoRentedUnit.Size = new Size(106, 30);
            NoRentedUnit.TabIndex = 37;
            NoRentedUnit.Text = "No. RUnit";
            // 
            // Units
            // 
            Units.Location = new Point(0, 0);
            Units.Name = "Units";
            Units.Size = new Size(100, 23);
            Units.TabIndex = 39;
            // 
            // NoUnit
            // 
            NoUnit.AutoSize = true;
            NoUnit.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NoUnit.Location = new Point(15, 46);
            NoUnit.Name = "NoUnit";
            NoUnit.Size = new Size(93, 30);
            NoUnit.TabIndex = 36;
            NoUnit.Text = "No. Unit";
            // 
            // circularProgressBar1
            // 
            circularProgressBar1.BackColorArc = Color.LightGray;
            circularProgressBar1.Location = new Point(121, 16);
            circularProgressBar1.Maximum = 100;
            circularProgressBar1.Name = "circularProgressBar1";
            circularProgressBar1.ProgressColor = Color.DarkRed;
            circularProgressBar1.Size = new Size(143, 131);
            circularProgressBar1.TabIndex = 34;
            circularProgressBar1.Text = "circularProgressBar1";
            circularProgressBar1.Value = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(dataGridViewItemSummary);
            panel3.Location = new Point(1076, 329);
            panel3.Name = "panel3";
            panel3.Size = new Size(264, 341);
            panel3.TabIndex = 38;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 8);
            label1.Name = "label1";
            label1.Size = new Size(90, 21);
            label1.TabIndex = 40;
            label1.Text = "SUMMARY";
            // 
            // dataGridViewItemSummary
            // 
            dataGridViewItemSummary.BackgroundColor = SystemColors.Window;
            dataGridViewItemSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewItemSummary.Location = new Point(0, 34);
            dataGridViewItemSummary.Name = "dataGridViewItemSummary";
            dataGridViewItemSummary.Size = new Size(264, 307);
            dataGridViewItemSummary.TabIndex = 0;
            // 
            // RENTALSbutton
            // 
            RENTALSbutton.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RENTALSbutton.Location = new Point(24, 210);
            RENTALSbutton.Name = "RENTALSbutton";
            RENTALSbutton.Size = new Size(168, 40);
            RENTALSbutton.TabIndex = 39;
            RENTALSbutton.Text = "RENTALS";
            RENTALSbutton.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.Window;
            panel8.Controls.Add(label10);
            panel8.Controls.Add(label9);
            panel8.Controls.Add(dataGridViewINV);
            panel8.Controls.Add(dataGridViewProd);
            panel8.Controls.Add(panel1);
            panel8.Location = new Point(239, 12);
            panel8.Name = "panel8";
            panel8.Size = new Size(815, 658);
            panel8.TabIndex = 40;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(3, 286);
            label10.Name = "label10";
            label10.Size = new Size(51, 21);
            label10.TabIndex = 39;
            label10.Text = "Items";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 71);
            label9.Name = "label9";
            label9.Size = new Size(68, 21);
            label9.TabIndex = 38;
            label9.Text = "Product";
            // 
            // dataGridViewINV
            // 
            dataGridViewINV.BackgroundColor = SystemColors.Window;
            dataGridViewINV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewINV.Location = new Point(1, 309);
            dataGridViewINV.Name = "dataGridViewINV";
            dataGridViewINV.Size = new Size(814, 349);
            dataGridViewINV.TabIndex = 37;
            // 
            // dataGridViewProd
            // 
            dataGridViewProd.BackgroundColor = SystemColors.Window;
            dataGridViewProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProd.Location = new Point(0, 95);
            dataGridViewProd.Name = "dataGridViewProd";
            dataGridViewProd.Size = new Size(815, 185);
            dataGridViewProd.TabIndex = 36;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ScrollBar;
            panel1.Controls.Add(SearchBtm);
            panel1.Controls.Add(SearchBox);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(815, 62);
            panel1.TabIndex = 35;
            // 
            // SearchBtm
            // 
            SearchBtm.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchBtm.Location = new Point(640, 12);
            SearchBtm.Name = "SearchBtm";
            SearchBtm.Size = new Size(156, 40);
            SearchBtm.TabIndex = 1;
            SearchBtm.Text = "Search";
            SearchBtm.UseVisualStyleBackColor = true;
            // 
            // SearchBox
            // 
            SearchBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBox.Location = new Point(14, 12);
            SearchBox.MaximumSize = new Size(200, 200);
            SearchBox.MinimumSize = new Size(600, 40);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(600, 40);
            SearchBox.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 130);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 40;
            label3.Text = "Rented";
            // 
            // EmployeeForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 691);
            Controls.Add(panel8);
            Controls.Add(RENTALSbutton);
            Controls.Add(panel3);
            Controls.Add(panel7);
            Controls.Add(panel4);
            Controls.Add(LOGOUT);
            Controls.Add(TRANSACTION);
            Controls.Add(ITEMS);
            Controls.Add(TENANT);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "EmployeeForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EmployeeForm1";
            Load += EmployeeForm1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewItemSummary).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewINV).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProd).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button LOGOUT;
        private Button TRANSACTION;
        private Button ITEMS;
        private Button TENANT;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        public Label EmpName;
        private Label Employee;
        private Panel panel4;
        private Label label6;
        private Label label2;
        private Panel panel7;
        private PictureBox pictureBox9;
        private Label Rented;
        private Label TotalUnits;
        private Label label4;
        public Label NoAvlUnit;
        public Label NoRentedUnit;
        private Label Units;
        public Label NoUnit;
        private CircularProgressBar circularProgressBar1;
        private Panel panel3;
        private Label label1;
        private DataGridView dataGridViewItemSummary;
        private Button RENTALSbutton;
        private Panel panel8;
        private Label label10;
        private Label label9;
        private DataGridView dataGridViewINV;
        private DataGridView dataGridViewProd;
        private Panel panel1;
        private Button SearchBtm;
        private TextBox SearchBox;
        private Label label3;
    }
}