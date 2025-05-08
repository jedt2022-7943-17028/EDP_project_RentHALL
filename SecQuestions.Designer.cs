namespace WinFormsSampleApp1
{
    partial class SecQuestions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecQuestions));
            pictureBox2 = new PictureBox();
            one_ans = new TextBox();
            label1 = new Label();
            two_ans = new TextBox();
            label2 = new Label();
            three_ans = new TextBox();
            label3 = new Label();
            Submit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources._02053c90_9350_4488_8fd0_33a40144cd91;
            pictureBox2.ImeMode = ImeMode.NoControl;
            pictureBox2.Location = new Point(-2, -3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(564, 565);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // one_ans
            // 
            one_ans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            one_ans.Font = new Font("Segoe UI", 11.25F);
            one_ans.Location = new Point(636, 176);
            one_ans.MaximumSize = new Size(375, 23);
            one_ans.MinimumSize = new Size(375, 30);
            one_ans.Name = "one_ans";
            one_ans.Size = new Size(375, 30);
            one_ans.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(636, 143);
            label1.Name = "label1";
            label1.Size = new Size(326, 20);
            label1.TabIndex = 9;
            label1.Text = "What is the name of your first rental property?";
            label1.Click += label1_Click;
            // 
            // two_ans
            // 
            two_ans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            two_ans.Font = new Font("Segoe UI", 11.25F);
            two_ans.Location = new Point(636, 285);
            two_ans.MaximumSize = new Size(375, 23);
            two_ans.MinimumSize = new Size(375, 30);
            two_ans.Name = "two_ans";
            two_ans.Size = new Size(375, 30);
            two_ans.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(636, 252);
            label2.Name = "label2";
            label2.Size = new Size(303, 20);
            label2.TabIndex = 11;
            label2.Text = "What year does your rental bussiness start?";
            // 
            // three_ans
            // 
            three_ans.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            three_ans.Font = new Font("Segoe UI", 11.25F);
            three_ans.Location = new Point(636, 398);
            three_ans.MaximumSize = new Size(375, 23);
            three_ans.MinimumSize = new Size(375, 30);
            three_ans.Name = "three_ans";
            three_ans.Size = new Size(375, 30);
            three_ans.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold);
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(636, 365);
            label3.Name = "label3";
            label3.Size = new Size(340, 20);
            label3.TabIndex = 13;
            label3.Text = "What is the first 4 digit of your bussiness permit?";
            // 
            // Submit
            // 
            Submit.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Submit.AutoSize = true;
            Submit.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            Submit.ImeMode = ImeMode.NoControl;
            Submit.Location = new Point(732, 458);
            Submit.Name = "Submit";
            Submit.Size = new Size(173, 44);
            Submit.TabIndex = 15;
            Submit.Text = "Submit";
            Submit.UseVisualStyleBackColor = true;
            Submit.Click += Submit_Click;
            // 
            // SecQuestions
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1115, 563);
            Controls.Add(Submit);
            Controls.Add(three_ans);
            Controls.Add(label3);
            Controls.Add(two_ans);
            Controls.Add(label2);
            Controls.Add(one_ans);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "SecQuestions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SecQuestions";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private TextBox one_ans;
        private Label label1;
        private TextBox two_ans;
        private Label label2;
        private TextBox three_ans;
        private Label label3;
        private Button Submit;
    }
}