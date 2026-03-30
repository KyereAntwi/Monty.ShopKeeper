namespace Monty.ShopKeeper.App.Views
{
    partial class PasswordResetFrm
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
            label1 = new Label();
            CurrentPasswordTxt = new TextBox();
            label2 = new Label();
            label3 = new Label();
            NewPasswordTxt = new TextBox();
            label4 = new Label();
            ConfirmPasswordTxt = new TextBox();
            ResetBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 34);
            label1.Name = "label1";
            label1.Size = new Size(187, 25);
            label1.TabIndex = 0;
            label1.Text = "Reset your password";
            // 
            // CurrentPasswordTxt
            // 
            CurrentPasswordTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CurrentPasswordTxt.Location = new Point(12, 154);
            CurrentPasswordTxt.MaxLength = 15;
            CurrentPasswordTxt.Name = "CurrentPasswordTxt";
            CurrentPasswordTxt.PasswordChar = 'X';
            CurrentPasswordTxt.PlaceholderText = "Your current password";
            CurrentPasswordTxt.Size = new Size(466, 33);
            CurrentPasswordTxt.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 126);
            label2.Name = "label2";
            label2.Size = new Size(166, 25);
            label2.TabIndex = 2;
            label2.Text = "Current Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 216);
            label3.Name = "label3";
            label3.Size = new Size(140, 25);
            label3.TabIndex = 4;
            label3.Text = "New Password:";
            // 
            // NewPasswordTxt
            // 
            NewPasswordTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NewPasswordTxt.Location = new Point(12, 244);
            NewPasswordTxt.MaxLength = 15;
            NewPasswordTxt.Name = "NewPasswordTxt";
            NewPasswordTxt.PasswordChar = 'X';
            NewPasswordTxt.PlaceholderText = "New current password";
            NewPasswordTxt.Size = new Size(466, 33);
            NewPasswordTxt.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 321);
            label4.Name = "label4";
            label4.Size = new Size(211, 25);
            label4.TabIndex = 6;
            label4.Text = "Confirm new Password:";
            // 
            // ConfirmPasswordTxt
            // 
            ConfirmPasswordTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ConfirmPasswordTxt.Location = new Point(12, 349);
            ConfirmPasswordTxt.MaxLength = 15;
            ConfirmPasswordTxt.Name = "ConfirmPasswordTxt";
            ConfirmPasswordTxt.PasswordChar = 'X';
            ConfirmPasswordTxt.PlaceholderText = "Confirm new current password";
            ConfirmPasswordTxt.Size = new Size(466, 33);
            ConfirmPasswordTxt.TabIndex = 5;
            // 
            // ResetBtn
            // 
            ResetBtn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ResetBtn.FlatStyle = FlatStyle.Flat;
            ResetBtn.Location = new Point(170, 397);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(308, 38);
            ResetBtn.TabIndex = 7;
            ResetBtn.Text = "Reset Password";
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += ResetBtn_Click;
            // 
            // PasswordResetFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(490, 569);
            Controls.Add(ResetBtn);
            Controls.Add(label4);
            Controls.Add(ConfirmPasswordTxt);
            Controls.Add(label3);
            Controls.Add(NewPasswordTxt);
            Controls.Add(label2);
            Controls.Add(CurrentPasswordTxt);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasswordResetFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reset your password";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox CurrentPasswordTxt;
        private Label label2;
        private Label label3;
        private TextBox NewPasswordTxt;
        private Label label4;
        private TextBox ConfirmPasswordTxt;
        private Button ResetBtn;
    }
}