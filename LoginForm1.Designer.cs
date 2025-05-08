namespace WinFormsSampleApp1
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            Login = new Button();
            label1 = new Label();
            username_text_box = new TextBox();
            password_label = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            password_text_box = new TextBox();
            label2forgot = new Label();
            createOwnerAccount = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Login
            // 
            resources.ApplyResources(Login, "Login");
            Login.Name = "Login";
            Login.UseVisualStyleBackColor = true;
            Login.Click += Log_In_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // username_text_box
            // 
            resources.ApplyResources(username_text_box, "username_text_box");
            username_text_box.Name = "username_text_box";
            // 
            // password_label
            // 
            resources.ApplyResources(password_label, "password_label");
            password_label.Name = "password_label";
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Image = Properties.Resources._02053c90_9350_4488_8fd0_33a40144cd91;
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources._491c3a53_63ad_442f_a00a_8d3534a72b61_removebg_preview;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // password_text_box
            // 
            resources.ApplyResources(password_text_box, "password_text_box");
            password_text_box.Name = "password_text_box";
            // 
            // label2forgot
            // 
            resources.ApplyResources(label2forgot, "label2forgot");
            label2forgot.ForeColor = SystemColors.WindowFrame;
            label2forgot.Name = "label2forgot";
            label2forgot.Click += label2forgot_Click;
            // 
            // createOwnerAccount
            // 
            resources.ApplyResources(createOwnerAccount, "createOwnerAccount");
            createOwnerAccount.Name = "createOwnerAccount";
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(createOwnerAccount);
            Controls.Add(label2forgot);
            Controls.Add(password_text_box);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(password_label);
            Controls.Add(username_text_box);
            Controls.Add(label1);
            Controls.Add(Login);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "LoginForm";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Login;
        private Label label1;
        private TextBox username_text_box;
        private Label password_label;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox password_text_box;
        private Label label2forgot;
        private Label createOwnerAccount;
    }
}
