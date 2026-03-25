namespace Monty.ShopKeeper.App.Views
{
    partial class CompleteCreditedPurchaseFrm
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
            AmountReceivedTb = new NumericUpDown();
            label1 = new Label();
            CompleteBtn = new Button();
            BalanceTxt = new Label();
            BalanceTb = new NumericUpDown();
            TotalToPayLb = new Label();
            ((System.ComponentModel.ISupportInitialize)AmountReceivedTb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BalanceTb).BeginInit();
            SuspendLayout();
            // 
            // AmountReceivedTb
            // 
            AmountReceivedTb.Location = new Point(12, 133);
            AmountReceivedTb.Name = "AmountReceivedTb";
            AmountReceivedTb.Size = new Size(422, 33);
            AmountReceivedTb.TabIndex = 0;
            AmountReceivedTb.ValueChanged += AmountReceivedTb_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 105);
            label1.Name = "label1";
            label1.Size = new Size(168, 25);
            label1.TabIndex = 1;
            label1.Text = "Amount Received:";
            // 
            // CompleteBtn
            // 
            CompleteBtn.Enabled = false;
            CompleteBtn.FlatStyle = FlatStyle.Flat;
            CompleteBtn.Location = new Point(179, 261);
            CompleteBtn.Name = "CompleteBtn";
            CompleteBtn.Size = new Size(255, 36);
            CompleteBtn.TabIndex = 2;
            CompleteBtn.Text = "Complete Purchase";
            CompleteBtn.UseVisualStyleBackColor = true;
            CompleteBtn.Click += CompleteBtn_Click;
            // 
            // BalanceTxt
            // 
            BalanceTxt.AutoSize = true;
            BalanceTxt.Location = new Point(12, 194);
            BalanceTxt.Name = "BalanceTxt";
            BalanceTxt.Size = new Size(124, 25);
            BalanceTxt.TabIndex = 4;
            BalanceTxt.Text = "Balance Paid:";
            // 
            // BalanceTb
            // 
            BalanceTb.Location = new Point(12, 222);
            BalanceTb.Name = "BalanceTb";
            BalanceTb.ReadOnly = true;
            BalanceTb.Size = new Size(422, 33);
            BalanceTb.TabIndex = 3;
            // 
            // TotalToPayLb
            // 
            TotalToPayLb.AutoSize = true;
            TotalToPayLb.Location = new Point(12, 37);
            TotalToPayLb.Name = "TotalToPayLb";
            TotalToPayLb.Size = new Size(64, 25);
            TotalToPayLb.TabIndex = 5;
            TotalToPayLb.Text = "label2";
            // 
            // CompleteCreditedPurchaseFrm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 387);
            Controls.Add(TotalToPayLb);
            Controls.Add(BalanceTxt);
            Controls.Add(BalanceTb);
            Controls.Add(CompleteBtn);
            Controls.Add(label1);
            Controls.Add(AmountReceivedTb);
            Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CompleteCreditedPurchaseFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Complete a credited purchase";
            Load += CompleteCreditedPurchaseFrm_Load;
            ((System.ComponentModel.ISupportInitialize)AmountReceivedTb).EndInit();
            ((System.ComponentModel.ISupportInitialize)BalanceTb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown AmountReceivedTb;
        private Label label1;
        private Button CompleteBtn;
        private Label BalanceTxt;
        private NumericUpDown BalanceTb;
        private Label TotalToPayLb;
    }
}