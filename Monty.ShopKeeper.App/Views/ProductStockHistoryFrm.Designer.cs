namespace Monty.ShopKeeper.App.Views
{
    partial class ProductStockHistoryFrm
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
            panel1 = new Panel();
            TitleLb = new Label();
            panel2 = new Panel();
            TotalStockLb = new Label();
            label1 = new Label();
            TotalAmountLb = new Label();
            label3 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            AmountExpectedLb = new Label();
            label4 = new Label();
            panel5 = new Panel();
            TotalSalesLb = new Label();
            label5 = new Label();
            StocksLv = new ListView();
            IdCl = new ColumnHeader();
            QuntityCl = new ColumnHeader();
            QuantityLeftCl = new ColumnHeader();
            CostCl = new ColumnHeader();
            SellingCl = new ColumnHeader();
            CreatedCl = new ColumnHeader();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(TitleLb);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1276, 52);
            panel1.TabIndex = 0;
            // 
            // TitleLb
            // 
            TitleLb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TitleLb.AutoSize = true;
            TitleLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLb.Location = new Point(14, 17);
            TitleLb.Name = "TitleLb";
            TitleLb.Size = new Size(65, 22);
            TitleLb.TabIndex = 0;
            TitleLb.Text = "label1";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.ActiveBorder;
            panel2.Controls.Add(TotalStockLb);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 70);
            panel2.Name = "panel2";
            panel2.Size = new Size(211, 117);
            panel2.TabIndex = 1;
            // 
            // TotalStockLb
            // 
            TotalStockLb.AutoSize = true;
            TotalStockLb.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalStockLb.Location = new Point(75, 48);
            TotalStockLb.Name = "TotalStockLb";
            TotalStockLb.Size = new Size(51, 58);
            TotalStockLb.TabIndex = 2;
            TotalStockLb.Text = "0";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 13);
            label1.Name = "label1";
            label1.Size = new Size(190, 22);
            label1.TabIndex = 1;
            label1.Text = "Total stocks added:";
            // 
            // TotalAmountLb
            // 
            TotalAmountLb.AutoSize = true;
            TotalAmountLb.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalAmountLb.Location = new Point(9, 48);
            TotalAmountLb.Name = "TotalAmountLb";
            TotalAmountLb.Size = new Size(51, 58);
            TotalAmountLb.TabIndex = 2;
            TotalAmountLb.Text = "0";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(9, 13);
            label3.Name = "label3";
            label3.Size = new Size(191, 22);
            label3.TabIndex = 1;
            label3.Text = "Total amount spent:";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.ActiveBorder;
            panel3.Controls.Add(TotalAmountLb);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(229, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(384, 117);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = SystemColors.ActiveBorder;
            panel4.Controls.Add(AmountExpectedLb);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(619, 70);
            panel4.Name = "panel4";
            panel4.Size = new Size(384, 117);
            panel4.TabIndex = 4;
            // 
            // AmountExpectedLb
            // 
            AmountExpectedLb.AutoSize = true;
            AmountExpectedLb.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AmountExpectedLb.Location = new Point(9, 48);
            AmountExpectedLb.Name = "AmountExpectedLb";
            AmountExpectedLb.Size = new Size(51, 58);
            AmountExpectedLb.TabIndex = 2;
            AmountExpectedLb.Text = "0";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(9, 13);
            label4.Name = "label4";
            label4.Size = new Size(332, 22);
            label4.TabIndex = 1;
            label4.Text = "Total amount expected to be made:";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = SystemColors.ActiveBorder;
            panel5.Controls.Add(TotalSalesLb);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(1009, 70);
            panel5.Name = "panel5";
            panel5.Size = new Size(279, 117);
            panel5.TabIndex = 5;
            // 
            // TotalSalesLb
            // 
            TotalSalesLb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TotalSalesLb.AutoSize = true;
            TotalSalesLb.Font = new Font("Bahnschrift", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalSalesLb.Location = new Point(102, 48);
            TotalSalesLb.Name = "TotalSalesLb";
            TotalSalesLb.Size = new Size(51, 58);
            TotalSalesLb.TabIndex = 2;
            TotalSalesLb.Text = "0";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(9, 13);
            label5.Name = "label5";
            label5.Size = new Size(144, 22);
            label5.TabIndex = 1;
            label5.Text = "Total unit sold:\r\n";
            // 
            // StocksLv
            // 
            StocksLv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StocksLv.Columns.AddRange(new ColumnHeader[] { IdCl, QuntityCl, QuantityLeftCl, CostCl, SellingCl, CreatedCl });
            StocksLv.GridLines = true;
            StocksLv.Location = new Point(12, 193);
            StocksLv.MultiSelect = false;
            StocksLv.Name = "StocksLv";
            StocksLv.Size = new Size(1276, 565);
            StocksLv.Sorting = SortOrder.Descending;
            StocksLv.TabIndex = 6;
            StocksLv.UseCompatibleStateImageBehavior = false;
            StocksLv.View = View.Details;
            // 
            // IdCl
            // 
            IdCl.Text = "";
            // 
            // QuntityCl
            // 
            QuntityCl.Text = "Quntity Purchased";
            QuntityCl.Width = 100;
            // 
            // QuantityLeftCl
            // 
            QuantityLeftCl.Text = "Quntity Left in Stock";
            QuantityLeftCl.Width = 100;
            // 
            // CostCl
            // 
            CostCl.Text = "Unit Cost Price";
            CostCl.Width = 100;
            // 
            // SellingCl
            // 
            SellingCl.Text = "Unit Selling Price";
            SellingCl.Width = 100;
            // 
            // CreatedCl
            // 
            CreatedCl.Text = "Date Added";
            CreatedCl.Width = 100;
            // 
            // ProductStockHistoryFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 770);
            Controls.Add(StocksLv);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ProductStockHistoryFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "ProductStockHistoryFrm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label TitleLb;
        private Panel panel2;
        private Label TotalStockLb;
        private Label label1;
        private Label TotalAmountLb;
        private Label label3;
        private Panel panel3;
        private Panel panel4;
        private Label AmountExpectedLb;
        private Label label4;
        private Panel panel5;
        private Label TotalSalesLb;
        private Label label5;
        private ListView StocksLv;
        private ColumnHeader IdCl;
        private ColumnHeader QuntityCl;
        private ColumnHeader QuantityLeftCl;
        private ColumnHeader CostCl;
        private ColumnHeader SellingCl;
        private ColumnHeader CreatedCl;
    }
}