namespace WinFormsSampleApp1
{
    partial class AdminForm2INV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm2INV));
            pictureBox1 = new PictureBox();
            EMPLOYEES = new Button();
            LOGOUT = new Button();
            RENTALS = new Button();
            TRANSACTION = new Button();
            INVENTORY = new Button();
            TENANT = new Button();
            DASHBOARD = new Button();
            pictureBox2 = new PictureBox();
            panel8 = new Panel();
            label10 = new Label();
            label9 = new Label();
            dataGridViewINV = new DataGridView();
            dataGridViewProd = new DataGridView();
            panel1 = new Panel();
            SearchBtm = new Button();
            SearchBox = new TextBox();
            panel2 = new Panel();
            comboBoxCateg = new ComboBox();
            buttonAddINV = new Button();
            label8 = new Label();
            textBoxsize = new TextBox();
            label7 = new Label();
            addPrd = new Label();
            panel3 = new Panel();
            comboBoxDuration = new ComboBox();
            SbtCateg = new Button();
            label6 = new Label();
            label5 = new Label();
            textBoxbasePrice = new TextBox();
            label4 = new Label();
            richTextBoxDescription = new RichTextBox();
            label3 = new Label();
            textBoxProd = new TextBox();
            label2 = new Label();
            textBoxCode = new TextBox();
            label1 = new Label();
            textBoxType = new TextBox();
            addCtg = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewINV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProd).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkRed;
            pictureBox1.Location = new Point(-2, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(223, 696);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // EMPLOYEES
            // 
            EMPLOYEES.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            EMPLOYEES.Location = new Point(23, 389);
            EMPLOYEES.Name = "EMPLOYEES";
            EMPLOYEES.Size = new Size(168, 40);
            EMPLOYEES.TabIndex = 16;
            EMPLOYEES.Text = "EMPLOYEES";
            EMPLOYEES.UseVisualStyleBackColor = true;
            EMPLOYEES.Click += EMPLOYEES_Click;
            // 
            // LOGOUT
            // 
            LOGOUT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LOGOUT.Location = new Point(23, 633);
            LOGOUT.Name = "LOGOUT";
            LOGOUT.Size = new Size(168, 40);
            LOGOUT.TabIndex = 15;
            LOGOUT.Text = "LOGOUT";
            LOGOUT.UseVisualStyleBackColor = true;
            LOGOUT.Click += LOGOUT_Click;
            // 
            // RENTALS
            // 
            RENTALS.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RENTALS.Location = new Point(23, 270);
            RENTALS.Name = "RENTALS";
            RENTALS.Size = new Size(168, 40);
            RENTALS.TabIndex = 14;
            RENTALS.Text = "RENTALS";
            RENTALS.UseVisualStyleBackColor = true;
            RENTALS.Click += RENTALS_Click;
            // 
            // TRANSACTION
            // 
            TRANSACTION.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TRANSACTION.Location = new Point(23, 447);
            TRANSACTION.Name = "TRANSACTION";
            TRANSACTION.Size = new Size(168, 40);
            TRANSACTION.TabIndex = 13;
            TRANSACTION.Text = "TRANSACTION";
            TRANSACTION.UseVisualStyleBackColor = true;
            TRANSACTION.Click += TRANSACTION_Click;
            // 
            // INVENTORY
            // 
            INVENTORY.BackColor = Color.Brown;
            INVENTORY.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            INVENTORY.ForeColor = SystemColors.Control;
            INVENTORY.Location = new Point(23, 211);
            INVENTORY.Name = "INVENTORY";
            INVENTORY.Size = new Size(168, 40);
            INVENTORY.TabIndex = 12;
            INVENTORY.Text = "INVENTORY";
            INVENTORY.UseVisualStyleBackColor = false;
            INVENTORY.Click += INVENTORY_Click;
            // 
            // TENANT
            // 
            TENANT.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TENANT.Location = new Point(23, 330);
            TENANT.Name = "TENANT";
            TENANT.Size = new Size(168, 40);
            TENANT.TabIndex = 11;
            TENANT.Text = "TENANT";
            TENANT.UseVisualStyleBackColor = true;
            TENANT.Click += TENANT_Click;
            // 
            // DASHBOARD
            // 
            DASHBOARD.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DASHBOARD.Location = new Point(23, 153);
            DASHBOARD.Name = "DASHBOARD";
            DASHBOARD.Size = new Size(168, 40);
            DASHBOARD.TabIndex = 10;
            DASHBOARD.Text = "DASHBOARD";
            DASHBOARD.UseVisualStyleBackColor = true;
            DASHBOARD.Click += DASHBOARD_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.DarkRed;
            pictureBox2.Image = Properties.Resources._02053c90_9350_4488_8fd0_33a40144cd91_removebg_preview;
            pictureBox2.Location = new Point(23, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(168, 116);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 9;
            pictureBox2.TabStop = false;
            // 
            // panel8
            // 
            panel8.BackColor = SystemColors.Window;
            panel8.Controls.Add(label10);
            panel8.Controls.Add(label9);
            panel8.Controls.Add(dataGridViewINV);
            panel8.Controls.Add(dataGridViewProd);
            panel8.Controls.Add(panel1);
            panel8.Location = new Point(236, 21);
            panel8.Name = "panel8";
            panel8.Size = new Size(736, 658);
            panel8.TabIndex = 34;
            panel8.Paint += panel8_Paint;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(3, 286);
            label10.Name = "label10";
            label10.Size = new Size(81, 21);
            label10.TabIndex = 39;
            label10.Text = "Inventory";
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
            dataGridViewINV.Size = new Size(735, 349);
            dataGridViewINV.TabIndex = 37;
            // 
            // dataGridViewProd
            // 
            dataGridViewProd.BackgroundColor = SystemColors.Window;
            dataGridViewProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProd.Location = new Point(0, 95);
            dataGridViewProd.Name = "dataGridViewProd";
            dataGridViewProd.Size = new Size(735, 185);
            dataGridViewProd.TabIndex = 36;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ScrollBar;
            panel1.Controls.Add(SearchBtm);
            panel1.Controls.Add(SearchBox);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(736, 62);
            panel1.TabIndex = 35;
            // 
            // SearchBtm
            // 
            SearchBtm.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SearchBtm.Location = new Point(543, 12);
            SearchBtm.Name = "SearchBtm";
            SearchBtm.Size = new Size(156, 40);
            SearchBtm.TabIndex = 1;
            SearchBtm.Text = "Search";
            SearchBtm.UseVisualStyleBackColor = true;
            SearchBtm.Click += SearchBtm_Click;
            // 
            // SearchBox
            // 
            SearchBox.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBox.Location = new Point(14, 12);
            SearchBox.MaximumSize = new Size(200, 200);
            SearchBox.MinimumSize = new Size(500, 40);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(500, 40);
            SearchBox.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MistyRose;
            panel2.Controls.Add(comboBoxCateg);
            panel2.Controls.Add(buttonAddINV);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(textBoxsize);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(addPrd);
            panel2.Location = new Point(1015, 495);
            panel2.Name = "panel2";
            panel2.Size = new Size(315, 184);
            panel2.TabIndex = 35;
            panel2.Paint += panel2_Paint;
            // 
            // comboBoxCateg
            // 
            comboBoxCateg.FormattingEnabled = true;
            comboBoxCateg.Items.AddRange(new object[] { "day", "week", "month", "year" });
            comboBoxCateg.Location = new Point(12, 86);
            comboBoxCateg.Name = "comboBoxCateg";
            comboBoxCateg.Size = new Size(153, 23);
            comboBoxCateg.TabIndex = 38;
            // 
            // buttonAddINV
            // 
            buttonAddINV.Location = new Point(96, 138);
            buttonAddINV.Name = "buttonAddINV";
            buttonAddINV.Size = new Size(118, 29);
            buttonAddINV.TabIndex = 14;
            buttonAddINV.Text = "Submit";
            buttonAddINV.UseVisualStyleBackColor = true;
            buttonAddINV.Click += buttonAddINV_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(179, 68);
            label8.Name = "label8";
            label8.Size = new Size(27, 15);
            label8.TabIndex = 6;
            label8.Text = "Size";
            // 
            // textBoxsize
            // 
            textBoxsize.Location = new Point(179, 86);
            textBoxsize.Name = "textBoxsize";
            textBoxsize.Size = new Size(118, 23);
            textBoxsize.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 68);
            label7.Name = "label7";
            label7.Size = new Size(55, 15);
            label7.TabIndex = 4;
            label7.Text = "Category";
            label7.Click += label7_Click;
            // 
            // addPrd
            // 
            addPrd.AutoSize = true;
            addPrd.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addPrd.Location = new Point(12, 16);
            addPrd.Name = "addPrd";
            addPrd.Size = new Size(135, 30);
            addPrd.TabIndex = 0;
            addPrd.Text = "Add Product";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.InactiveBorder;
            panel3.Controls.Add(comboBoxDuration);
            panel3.Controls.Add(SbtCateg);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBoxbasePrice);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(richTextBoxDescription);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(textBoxProd);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(textBoxCode);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(textBoxType);
            panel3.Controls.Add(addCtg);
            panel3.Location = new Point(1015, 23);
            panel3.Name = "panel3";
            panel3.Size = new Size(315, 438);
            panel3.TabIndex = 36;
            // 
            // comboBoxDuration
            // 
            comboBoxDuration.FormattingEnabled = true;
            comboBoxDuration.Items.AddRange(new object[] { "hour", "day", "week", "month", "year" });
            comboBoxDuration.Location = new Point(160, 213);
            comboBoxDuration.Name = "comboBoxDuration";
            comboBoxDuration.Size = new Size(137, 23);
            comboBoxDuration.TabIndex = 37;
            // 
            // SbtCateg
            // 
            SbtCateg.Location = new Point(179, 383);
            SbtCateg.Name = "SbtCateg";
            SbtCateg.Size = new Size(118, 42);
            SbtCateg.TabIndex = 13;
            SbtCateg.Text = "Submit";
            SbtCateg.UseVisualStyleBackColor = true;
            SbtCateg.Click += SbtCateg_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(160, 195);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 12;
            label6.Text = "Rent Duration";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 195);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 10;
            label5.Text = "Base Price";
            // 
            // textBoxbasePrice
            // 
            textBoxbasePrice.Location = new Point(12, 213);
            textBoxbasePrice.Name = "textBoxbasePrice";
            textBoxbasePrice.Size = new Size(129, 23);
            textBoxbasePrice.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 258);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 8;
            label4.Text = "Product Description";
            // 
            // richTextBoxDescription
            // 
            richTextBoxDescription.Location = new Point(12, 281);
            richTextBoxDescription.Name = "richTextBoxDescription";
            richTextBoxDescription.Size = new Size(285, 93);
            richTextBoxDescription.TabIndex = 7;
            richTextBoxDescription.Text = "";
            richTextBoxDescription.TextChanged += richTextBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 129);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 6;
            label3.Text = "Product Name";
            // 
            // textBoxProd
            // 
            textBoxProd.Location = new Point(12, 147);
            textBoxProd.Name = "textBoxProd";
            textBoxProd.Size = new Size(285, 23);
            textBoxProd.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(179, 61);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 4;
            label2.Text = "Code";
            // 
            // textBoxCode
            // 
            textBoxCode.Location = new Point(179, 79);
            textBoxCode.Name = "textBoxCode";
            textBoxCode.Size = new Size(118, 23);
            textBoxCode.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Type";
            // 
            // textBoxType
            // 
            textBoxType.Location = new Point(12, 79);
            textBoxType.Name = "textBoxType";
            textBoxType.Size = new Size(153, 23);
            textBoxType.TabIndex = 1;
            // 
            // addCtg
            // 
            addCtg.AutoSize = true;
            addCtg.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addCtg.Location = new Point(12, 16);
            addCtg.Name = "addCtg";
            addCtg.Size = new Size(148, 30);
            addCtg.TabIndex = 0;
            addCtg.Text = "Add Category";
            // 
            // AdminForm2INV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1354, 691);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel8);
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
            Name = "AdminForm2INV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminForm2INV";
            Load += AdminForm2INV_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewINV).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProd).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button EMPLOYEES;
        private Button LOGOUT;
        private Button RENTALS;
        private Button TRANSACTION;
        private Button INVENTORY;
        private Button TENANT;
        private Button DASHBOARD;
        private PictureBox pictureBox2;
        private Panel panel8;
        private Panel panel1;
        private Panel panel2;
        private TextBox SearchBox;
        private Button SearchBtm;
        private DataGridView dataGridViewProd;
        private Panel panel3;
        private Label addCtg;
        private Label addPrd;
        private Label label3;
        private TextBox textBoxProd;
        private Label label2;
        private TextBox textBoxCode;
        private Label label1;
        private TextBox textBoxType;
        private Button SbtCateg;
        private Label label6;
        private Label label5;
        private TextBox textBoxbasePrice;
        private Label label4;
        private RichTextBox richTextBoxDescription;
        private Label label7;
        private Button buttonAddINV;
        private Label label8;
        private TextBox textBoxsize;
        private ComboBox comboBoxDuration;
        private ComboBox comboBoxCateg;
        private DataGridView dataGridViewINV;
        private Label label10;
        private Label label9;
    }
}