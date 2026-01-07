namespace Monty.ShopKeeper.App.Views
{
    partial class MakeSaleFrm
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
            LineItemsLB = new ListBox();
            label2 = new Label();
            AmountReceivedTxt = new NumericUpDown();
            TotalLb = new Label();
            BalanceTxt = new TextBox();
            label3 = new Label();
            CommentTxt = new RichTextBox();
            label4 = new Label();
            SubmitBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)AmountReceivedTxt).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 13);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(136, 21);
            label1.TabIndex = 0;
            label1.Text = "Basket line items:";
            // 
            // LineItemsLB
            // 
            LineItemsLB.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            LineItemsLB.FormattingEnabled = true;
            LineItemsLB.Location = new Point(15, 37);
            LineItemsLB.Name = "LineItemsLB";
            LineItemsLB.Size = new Size(492, 277);
            LineItemsLB.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 329);
            label2.Name = "label2";
            label2.Size = new Size(144, 21);
            label2.TabIndex = 2;
            label2.Text = "Amount Received:";
            // 
            // AmountReceivedTxt
            // 
            AmountReceivedTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AmountReceivedTxt.Location = new Point(18, 353);
            AmountReceivedTxt.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            AmountReceivedTxt.Name = "AmountReceivedTxt";
            AmountReceivedTxt.Size = new Size(492, 29);
            AmountReceivedTxt.TabIndex = 3;
            AmountReceivedTxt.ValueChanged += AmountReceivedTxt_ValueChanged;
            // 
            // TotalLb
            // 
            TotalLb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            TotalLb.AutoSize = true;
            TotalLb.Location = new Point(172, 13);
            TotalLb.Name = "TotalLb";
            TotalLb.Size = new Size(54, 21);
            TotalLb.TabIndex = 4;
            TotalLb.Text = "label3";
            // 
            // BalanceTxt
            // 
            BalanceTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BalanceTxt.Location = new Point(15, 423);
            BalanceTxt.Name = "BalanceTxt";
            BalanceTxt.ReadOnly = true;
            BalanceTxt.Size = new Size(495, 29);
            BalanceTxt.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 399);
            label3.Name = "label3";
            label3.Size = new Size(70, 21);
            label3.TabIndex = 6;
            label3.Text = "Balance:";
            // 
            // CommentTxt
            // 
            CommentTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CommentTxt.BorderStyle = BorderStyle.FixedSingle;
            CommentTxt.Location = new Point(15, 483);
            CommentTxt.MaxLength = 500;
            CommentTxt.Name = "CommentTxt";
            CommentTxt.Size = new Size(495, 96);
            CommentTxt.TabIndex = 7;
            CommentTxt.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 459);
            label4.Name = "label4";
            label4.Size = new Size(198, 21);
            label4.TabIndex = 8;
            label4.Text = "Any comments (optional):";
            // 
            // SubmitBtn
            // 
            SubmitBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SubmitBtn.Enabled = false;
            SubmitBtn.FlatStyle = FlatStyle.Flat;
            SubmitBtn.Location = new Point(274, 599);
            SubmitBtn.Name = "SubmitBtn";
            SubmitBtn.Size = new Size(236, 35);
            SubmitBtn.TabIndex = 9;
            SubmitBtn.Text = "Submit";
            SubmitBtn.UseVisualStyleBackColor = true;
            SubmitBtn.Click += SubmitBtn_Click;
            // 
            // MakeSaleFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 646);
            Controls.Add(SubmitBtn);
            Controls.Add(label4);
            Controls.Add(CommentTxt);
            Controls.Add(label3);
            Controls.Add(BalanceTxt);
            Controls.Add(TotalLb);
            Controls.Add(AmountReceivedTxt);
            Controls.Add(label2);
            Controls.Add(LineItemsLB);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MakeSaleFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Process Basket";
            ((System.ComponentModel.ISupportInitialize)AmountReceivedTxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox LineItemsLB;
        private Label label2;
        private NumericUpDown AmountReceivedTxt;
        private Label TotalLb;
        private TextBox BalanceTxt;
        private Label label3;
        private RichTextBox CommentTxt;
        private Label label4;
        private Button SubmitBtn;
    }
}