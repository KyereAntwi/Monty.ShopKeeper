namespace Monty.ShopKeeper.App.Views
{
    partial class AddProductFrm
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
            AddProductTitleLb = new Label();
            label1 = new Label();
            ProductNameTxt = new TextBox();
            ProductUniueIdentifierTxt = new TextBox();
            label2 = new Label();
            ProductDescriptionTxt = new TextBox();
            label3 = new Label();
            SaveBtn = new Button();
            ClearBtn = new Button();
            SuspendLayout();
            // 
            // AddProductTitleLb
            // 
            AddProductTitleLb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AddProductTitleLb.AutoSize = true;
            AddProductTitleLb.Location = new Point(236, 9);
            AddProductTitleLb.Name = "AddProductTitleLb";
            AddProductTitleLb.Size = new Size(149, 21);
            AddProductTitleLb.TabIndex = 0;
            AddProductTitleLb.Text = "Add a new Product";
            AddProductTitleLb.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 78);
            label1.Name = "label1";
            label1.Size = new Size(161, 21);
            label1.TabIndex = 1;
            label1.Text = "Enter Product Name:";
            // 
            // ProductNameTxt
            // 
            ProductNameTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProductNameTxt.BorderStyle = BorderStyle.FixedSingle;
            ProductNameTxt.Location = new Point(12, 102);
            ProductNameTxt.MaxLength = 200;
            ProductNameTxt.Name = "ProductNameTxt";
            ProductNameTxt.PlaceholderText = "Name Eg: Casapreko";
            ProductNameTxt.Size = new Size(635, 29);
            ProductNameTxt.TabIndex = 2;
            ProductNameTxt.TextChanged += ProductNameTxt_TextChanged;
            // 
            // ProductUniueIdentifierTxt
            // 
            ProductUniueIdentifierTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProductUniueIdentifierTxt.BorderStyle = BorderStyle.FixedSingle;
            ProductUniueIdentifierTxt.Location = new Point(12, 176);
            ProductUniueIdentifierTxt.MaxLength = 5;
            ProductUniueIdentifierTxt.Name = "ProductUniueIdentifierTxt";
            ProductUniueIdentifierTxt.PlaceholderText = "Unique identifier Eg: CP003";
            ProductUniueIdentifierTxt.Size = new Size(635, 29);
            ProductUniueIdentifierTxt.TabIndex = 4;
            ProductUniueIdentifierTxt.TextChanged += ProductUniueIdentifierTxt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 152);
            label2.Name = "label2";
            label2.Size = new Size(582, 21);
            label2.TabIndex = 3;
            label2.Text = "Enter Product Unique Identifier or Code (would be used for shortened search):";
            // 
            // ProductDescriptionTxt
            // 
            ProductDescriptionTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ProductDescriptionTxt.BorderStyle = BorderStyle.FixedSingle;
            ProductDescriptionTxt.Location = new Point(12, 253);
            ProductDescriptionTxt.MaxLength = 1000;
            ProductDescriptionTxt.Multiline = true;
            ProductDescriptionTxt.Name = "ProductDescriptionTxt";
            ProductDescriptionTxt.PlaceholderText = "Description ...";
            ProductDescriptionTxt.Size = new Size(635, 136);
            ProductDescriptionTxt.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 229);
            label3.Name = "label3";
            label3.Size = new Size(280, 21);
            label3.TabIndex = 5;
            label3.Text = "Enter any description here (optional):";
            // 
            // SaveBtn
            // 
            SaveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SaveBtn.Enabled = false;
            SaveBtn.FlatStyle = FlatStyle.Flat;
            SaveBtn.Location = new Point(400, 395);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(247, 38);
            SaveBtn.TabIndex = 7;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // ClearBtn
            // 
            ClearBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ClearBtn.FlatStyle = FlatStyle.Flat;
            ClearBtn.Location = new Point(236, 395);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(158, 38);
            ClearBtn.TabIndex = 8;
            ClearBtn.Text = "Clear Form";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // AddProductFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 445);
            Controls.Add(ClearBtn);
            Controls.Add(SaveBtn);
            Controls.Add(ProductDescriptionTxt);
            Controls.Add(label3);
            Controls.Add(ProductUniueIdentifierTxt);
            Controls.Add(label2);
            Controls.Add(ProductNameTxt);
            Controls.Add(label1);
            Controls.Add(AddProductTitleLb);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddProductFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add or Edit a Product";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddProductTitleLb;
        private Label label1;
        private TextBox ProductNameTxt;
        private TextBox ProductUniueIdentifierTxt;
        private Label label2;
        private TextBox ProductDescriptionTxt;
        private Label label3;
        private Button SaveBtn;
        private Button ClearBtn;
    }
}