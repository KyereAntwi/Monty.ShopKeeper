namespace Monty.ShopKeeper.App.Views
{
    partial class ImportProductsFrm
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
            UploadBtn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 81);
            label1.Name = "label1";
            label1.Size = new Size(521, 42);
            label1.TabIndex = 0;
            label1.Text = "Add products list in bulk. \r\nUpload a CSV (comma separated value) file with the required columns.";
            // 
            // UploadBtn
            // 
            UploadBtn.Anchor = AnchorStyles.Top;
            UploadBtn.FlatStyle = FlatStyle.Flat;
            UploadBtn.Location = new Point(229, 150);
            UploadBtn.Name = "UploadBtn";
            UploadBtn.Size = new Size(304, 49);
            UploadBtn.TabIndex = 1;
            UploadBtn.Text = "Upload CSV File";
            UploadBtn.UseVisualStyleBackColor = true;
            UploadBtn.Click += UploadBtn_Click;
            // 
            // ImportProductsFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 290);
            Controls.Add(UploadBtn);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ImportProductsFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Import Products in Bulk";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button UploadBtn;
    }
}