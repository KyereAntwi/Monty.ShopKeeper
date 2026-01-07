namespace Monty.ShopKeeper.App.Views
{
    partial class StockProductFrm
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
            label2 = new Label();
            label3 = new Label();
            SaveBtn = new Button();
            ClearBtn = new Button();
            TitleLb = new Label();
            QuantityTxt = new NumericUpDown();
            CostPriceTxt = new NumericUpDown();
            SellingPriceTxt = new NumericUpDown();
            ProfitLb = new Label();
            ((System.ComponentModel.ISupportInitialize)QuantityTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CostPriceTxt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SellingPriceTxt).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 102);
            label1.Name = "label1";
            label1.Size = new Size(196, 21);
            label1.TabIndex = 0;
            label1.Text = "Enter quantity purchased:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 175);
            label2.Name = "label2";
            label2.Size = new Size(421, 21);
            label2.TabIndex = 2;
            label2.Text = "Enter unit cost price (Amount each item cost on market):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 248);
            label3.Name = "label3";
            label3.Size = new Size(431, 21);
            label3.TabIndex = 4;
            label3.Text = "Enter unit selling price (Amount each item would be sold):";
            // 
            // SaveBtn
            // 
            SaveBtn.Enabled = false;
            SaveBtn.FlatStyle = FlatStyle.Flat;
            SaveBtn.Location = new Point(313, 326);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(295, 40);
            SaveBtn.TabIndex = 6;
            SaveBtn.Text = "Save Stock";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // ClearBtn
            // 
            ClearBtn.FlatStyle = FlatStyle.Flat;
            ClearBtn.Location = new Point(127, 326);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(180, 40);
            ClearBtn.TabIndex = 7;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // TitleLb
            // 
            TitleLb.AutoSize = true;
            TitleLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLb.Location = new Point(12, 35);
            TitleLb.Name = "TitleLb";
            TitleLb.Size = new Size(141, 22);
            TitleLb.TabIndex = 8;
            TitleLb.Text = "Stock Product";
            // 
            // QuantityTxt
            // 
            QuantityTxt.Location = new Point(12, 126);
            QuantityTxt.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            QuantityTxt.Name = "QuantityTxt";
            QuantityTxt.Size = new Size(596, 29);
            QuantityTxt.TabIndex = 9;
            QuantityTxt.ValueChanged += QuantityTxt_ValueChanged;
            // 
            // CostPriceTxt
            // 
            CostPriceTxt.DecimalPlaces = 2;
            CostPriceTxt.Location = new Point(12, 199);
            CostPriceTxt.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            CostPriceTxt.Name = "CostPriceTxt";
            CostPriceTxt.Size = new Size(596, 29);
            CostPriceTxt.TabIndex = 10;
            CostPriceTxt.ThousandsSeparator = true;
            CostPriceTxt.ValueChanged += CostPriceTxt_ValueChanged;
            // 
            // SellingPriceTxt
            // 
            SellingPriceTxt.DecimalPlaces = 2;
            SellingPriceTxt.Location = new Point(12, 272);
            SellingPriceTxt.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            SellingPriceTxt.Name = "SellingPriceTxt";
            SellingPriceTxt.Size = new Size(596, 29);
            SellingPriceTxt.TabIndex = 11;
            SellingPriceTxt.ThousandsSeparator = true;
            SellingPriceTxt.ValueChanged += SellingPriceTxt_ValueChanged;
            // 
            // ProfitLb
            // 
            ProfitLb.AutoSize = true;
            ProfitLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProfitLb.ForeColor = Color.IndianRed;
            ProfitLb.Location = new Point(12, 57);
            ProfitLb.Name = "ProfitLb";
            ProfitLb.Size = new Size(186, 22);
            ProfitLb.TabIndex = 12;
            ProfitLb.Text = "Profit on product: 0";
            // 
            // StockProductFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 402);
            Controls.Add(ProfitLb);
            Controls.Add(SellingPriceTxt);
            Controls.Add(CostPriceTxt);
            Controls.Add(QuantityTxt);
            Controls.Add(TitleLb);
            Controls.Add(ClearBtn);
            Controls.Add(SaveBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockProductFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "StockProductFrm";
            ((System.ComponentModel.ISupportInitialize)QuantityTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)CostPriceTxt).EndInit();
            ((System.ComponentModel.ISupportInitialize)SellingPriceTxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button SaveBtn;
        private Button ClearBtn;
        private Label TitleLb;
        private NumericUpDown QuantityTxt;
        private NumericUpDown CostPriceTxt;
        private NumericUpDown SellingPriceTxt;
        private Label ProfitLb;
    }
}