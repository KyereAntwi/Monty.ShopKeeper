namespace Monty.ShopKeeper.App.Views
{
    partial class RegisterFrm
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
            TitleLb = new Label();
            label1 = new Label();
            UsernameTxt = new TextBox();
            PasswordTxt = new TextBox();
            PasswordLb = new Label();
            ConfirmPassTxt = new TextBox();
            label2 = new Label();
            RegisterBtn = new Button();
            SuspendLayout();
            // 
            // TitleLb
            // 
            TitleLb.AutoSize = true;
            TitleLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLb.Location = new Point(13, 22);
            TitleLb.Margin = new Padding(4, 0, 4, 0);
            TitleLb.Name = "TitleLb";
            TitleLb.Size = new Size(261, 22);
            TitleLb.TabIndex = 0;
            TitleLb.Text = "Register a new system user";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 149);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 1;
            label1.Text = "Username:";
            // 
            // UsernameTxt
            // 
            UsernameTxt.Location = new Point(13, 173);
            UsernameTxt.MaxLength = 225;
            UsernameTxt.Name = "UsernameTxt";
            UsernameTxt.PlaceholderText = "Username here ...";
            UsernameTxt.Size = new Size(505, 29);
            UsernameTxt.TabIndex = 2;
            UsernameTxt.TextChanged += UsernameTxt_TextChanged;
            // 
            // PasswordTxt
            // 
            PasswordTxt.Location = new Point(13, 258);
            PasswordTxt.MaxLength = 16;
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PasswordChar = 'X';
            PasswordTxt.PlaceholderText = "Password here ...";
            PasswordTxt.Size = new Size(505, 29);
            PasswordTxt.TabIndex = 4;
            PasswordTxt.TextChanged += PasswordTxt_TextChanged;
            // 
            // PasswordLb
            // 
            PasswordLb.AutoSize = true;
            PasswordLb.Location = new Point(13, 234);
            PasswordLb.Name = "PasswordLb";
            PasswordLb.Size = new Size(83, 21);
            PasswordLb.TabIndex = 3;
            PasswordLb.Text = "Password:";
            // 
            // ConfirmPassTxt
            // 
            ConfirmPassTxt.Location = new Point(13, 356);
            ConfirmPassTxt.MaxLength = 16;
            ConfirmPassTxt.Name = "ConfirmPassTxt";
            ConfirmPassTxt.PasswordChar = 'X';
            ConfirmPassTxt.PlaceholderText = "Confirm password here ...";
            ConfirmPassTxt.Size = new Size(505, 29);
            ConfirmPassTxt.TabIndex = 6;
            ConfirmPassTxt.TextChanged += ConfirmPassTxt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 332);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 5;
            label2.Text = "Confirm Password:";
            // 
            // RegisterBtn
            // 
            RegisterBtn.Enabled = false;
            RegisterBtn.FlatStyle = FlatStyle.Flat;
            RegisterBtn.Location = new Point(227, 428);
            RegisterBtn.Name = "RegisterBtn";
            RegisterBtn.Size = new Size(291, 38);
            RegisterBtn.TabIndex = 7;
            RegisterBtn.Text = "Register";
            RegisterBtn.UseVisualStyleBackColor = true;
            RegisterBtn.Click += RegisterBtn_Click;
            // 
            // RegisterFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(530, 633);
            Controls.Add(RegisterBtn);
            Controls.Add(ConfirmPassTxt);
            Controls.Add(label2);
            Controls.Add(PasswordTxt);
            Controls.Add(PasswordLb);
            Controls.Add(UsernameTxt);
            Controls.Add(label1);
            Controls.Add(TitleLb);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLb;
        private Label label1;
        private TextBox UsernameTxt;
        private TextBox PasswordTxt;
        private Label PasswordLb;
        private TextBox ConfirmPassTxt;
        private Label label2;
        private Button RegisterBtn;
    }
}