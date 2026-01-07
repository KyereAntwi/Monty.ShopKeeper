namespace Monty.ShopKeeper.App.Views
{
    partial class AddProductToStorageFrm
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
            StoragesCB = new ComboBox();
            SaveBtn = new Button();
            QuantityTxt = new NumericUpDown();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)QuantityTxt).BeginInit();
            SuspendLayout();
            // 
            // TitleLb
            // 
            TitleLb.AutoSize = true;
            TitleLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLb.Location = new Point(12, 47);
            TitleLb.Name = "TitleLb";
            TitleLb.Size = new Size(65, 22);
            TitleLb.TabIndex = 0;
            TitleLb.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 99);
            label1.Name = "label1";
            label1.Size = new Size(113, 21);
            label1.TabIndex = 1;
            label1.Text = "Select Storge:";
            // 
            // StoragesCB
            // 
            StoragesCB.FormattingEnabled = true;
            StoragesCB.Location = new Point(12, 123);
            StoragesCB.Name = "StoragesCB";
            StoragesCB.Size = new Size(388, 29);
            StoragesCB.TabIndex = 2;
            StoragesCB.SelectedIndexChanged += StoragesCB_SelectedIndexChanged;
            // 
            // SaveBtn
            // 
            SaveBtn.Enabled = false;
            SaveBtn.FlatStyle = FlatStyle.Flat;
            SaveBtn.Location = new Point(150, 240);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(250, 34);
            SaveBtn.TabIndex = 3;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // QuantityTxt
            // 
            QuantityTxt.Location = new Point(12, 195);
            QuantityTxt.Name = "QuantityTxt";
            QuantityTxt.Size = new Size(388, 29);
            QuantityTxt.TabIndex = 4;
            QuantityTxt.ValueChanged += QuantityTxt_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 171);
            label2.Name = "label2";
            label2.Size = new Size(155, 21);
            label2.TabIndex = 5;
            label2.Text = "Quantity of product";
            // 
            // AddProductToStorageFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 283);
            Controls.Add(label2);
            Controls.Add(QuantityTxt);
            Controls.Add(SaveBtn);
            Controls.Add(StoragesCB);
            Controls.Add(label1);
            Controls.Add(TitleLb);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProductToStorageFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add product to storage";
            ((System.ComponentModel.ISupportInitialize)QuantityTxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLb;
        private Label label1;
        private ComboBox StoragesCB;
        private Button SaveBtn;
        private NumericUpDown QuantityTxt;
        private Label label2;
    }
}