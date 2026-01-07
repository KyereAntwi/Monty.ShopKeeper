namespace Monty.ShopKeeper.App.Views
{
    partial class LoginFrm
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
            RegisterBtn = new Button();
            LoginBtn = new Button();
            UserNameTxt = new TextBox();
            PasswordTxt = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ConfirmTxt = new TextBox();
            SuspendLayout();
            // 
            // RegisterBtn
            // 
            RegisterBtn.FlatStyle = FlatStyle.Flat;
            RegisterBtn.Location = new Point(12, 573);
            RegisterBtn.Name = "RegisterBtn";
            RegisterBtn.Size = new Size(392, 48);
            RegisterBtn.TabIndex = 3;
            RegisterBtn.Text = "Register new System User";
            RegisterBtn.UseVisualStyleBackColor = true;
            RegisterBtn.Visible = false;
            RegisterBtn.Click += RegisterBtn_Click;
            // 
            // LoginBtn
            // 
            LoginBtn.FlatStyle = FlatStyle.Flat;
            LoginBtn.Location = new Point(12, 519);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(392, 48);
            LoginBtn.TabIndex = 2;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // UserNameTxt
            // 
            UserNameTxt.BorderStyle = BorderStyle.FixedSingle;
            UserNameTxt.Location = new Point(12, 230);
            UserNameTxt.MaxLength = 255;
            UserNameTxt.Multiline = true;
            UserNameTxt.Name = "UserNameTxt";
            UserNameTxt.Size = new Size(392, 55);
            UserNameTxt.TabIndex = 0;
            // 
            // PasswordTxt
            // 
            PasswordTxt.BorderStyle = BorderStyle.FixedSingle;
            PasswordTxt.Location = new Point(12, 334);
            PasswordTxt.MaxLength = 255;
            PasswordTxt.Multiline = true;
            PasswordTxt.Name = "PasswordTxt";
            PasswordTxt.PasswordChar = 'x';
            PasswordTxt.Size = new Size(392, 55);
            PasswordTxt.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 206);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 4;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 310);
            label2.Name = "label2";
            label2.Size = new Size(83, 21);
            label2.TabIndex = 5;
            label2.Text = "Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(121, 118);
            label3.Name = "label3";
            label3.Size = new Size(170, 21);
            label3.TabIndex = 6;
            label3.Text = "Login to your account";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 407);
            label4.Name = "label4";
            label4.Size = new Size(146, 21);
            label4.TabIndex = 8;
            label4.Text = "Confirm Password:";
            // 
            // ConfirmTxt
            // 
            ConfirmTxt.BorderStyle = BorderStyle.FixedSingle;
            ConfirmTxt.Location = new Point(12, 431);
            ConfirmTxt.MaxLength = 255;
            ConfirmTxt.Multiline = true;
            ConfirmTxt.Name = "ConfirmTxt";
            ConfirmTxt.PasswordChar = 'x';
            ConfirmTxt.Size = new Size(392, 55);
            ConfirmTxt.TabIndex = 7;
            ConfirmTxt.Visible = false;
            // 
            // LoginFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 849);
            Controls.Add(label4);
            Controls.Add(ConfirmTxt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTxt);
            Controls.Add(UserNameTxt);
            Controls.Add(LoginBtn);
            Controls.Add(RegisterBtn);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "LoginFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginFrm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegisterBtn;
        private Button LoginBtn;
        private TextBox UserNameTxt;
        private TextBox PasswordTxt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox ConfirmTxt;
    }
}