namespace Monty.ShopKeeper.App.Views
{
    partial class CreateStorageFrm
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
            TitleTxt = new TextBox();
            label4 = new Label();
            OrderTxt = new NumericUpDown();
            SaveBtn = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)OrderTxt).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(160, 21);
            label1.TabIndex = 0;
            label1.Text = "Add a storage place.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(12, 30);
            label2.Name = "label2";
            label2.Size = new Size(366, 40);
            label2.TabIndex = 1;
            label2.Text = "Note: If a storage place exist all sales will be deducted from,\r\n storage place and directly from stock.";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 96);
            label3.Name = "label3";
            label3.Size = new Size(118, 21);
            label3.TabIndex = 2;
            label3.Text = "Title of storge:";
            // 
            // TitleTxt
            // 
            TitleTxt.Location = new Point(12, 120);
            TitleTxt.Name = "TitleTxt";
            TitleTxt.PlaceholderText = "Storage title Eg: Refrigirator ...";
            TitleTxt.Size = new Size(410, 29);
            TitleTxt.TabIndex = 3;
            TitleTxt.TextChanged += TitleTxt_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 166);
            label4.Name = "label4";
            label4.Size = new Size(118, 21);
            label4.TabIndex = 4;
            label4.Text = "Storage order:";
            // 
            // OrderTxt
            // 
            OrderTxt.Location = new Point(12, 190);
            OrderTxt.Name = "OrderTxt";
            OrderTxt.Size = new Size(410, 29);
            OrderTxt.TabIndex = 5;
            OrderTxt.ValueChanged += OrderTxt_ValueChanged;
            // 
            // SaveBtn
            // 
            SaveBtn.Enabled = false;
            SaveBtn.Location = new Point(223, 242);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(199, 34);
            SaveBtn.TabIndex = 6;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.IndianRed;
            label5.Location = new Point(136, 166);
            label5.Name = "label5";
            label5.Size = new Size(223, 20);
            label5.TabIndex = 7;
            label5.Text = "products will deducted in this order";
            // 
            // CreateStorageFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 288);
            Controls.Add(label5);
            Controls.Add(SaveBtn);
            Controls.Add(OrderTxt);
            Controls.Add(label4);
            Controls.Add(TitleTxt);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreateStorageFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create a storage place";
            ((System.ComponentModel.ISupportInitialize)OrderTxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox TitleTxt;
        private Label label4;
        private NumericUpDown OrderTxt;
        private Button SaveBtn;
        private Label label5;
    }
}