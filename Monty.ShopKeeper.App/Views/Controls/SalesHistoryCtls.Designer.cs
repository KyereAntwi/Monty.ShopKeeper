namespace Monty.ShopKeeper.App.Views.Controls
{
    partial class SalesHistoryCtls
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewGroup listViewGroup1 = new ListViewGroup("ListViewGroup", HorizontalAlignment.Left);
            panel1 = new Panel();
            FilterBtn = new Button();
            label2 = new Label();
            ToDTP = new DateTimePicker();
            FromDTP = new DateTimePicker();
            CodeTxt = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            SalesHistoryLv = new ListView();
            IdCL = new ColumnHeader();
            ProductNameCL = new ColumnHeader();
            CodeCL = new ColumnHeader();
            QuantityCL = new ColumnHeader();
            AmountCL = new ColumnHeader();
            CommentCL = new ColumnHeader();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(FilterBtn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ToDTP);
            panel1.Controls.Add(FromDTP);
            panel1.Controls.Add(CodeTxt);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(962, 74);
            panel1.TabIndex = 0;
            // 
            // FilterBtn
            // 
            FilterBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            FilterBtn.Location = new Point(751, 3);
            FilterBtn.Name = "FilterBtn";
            FilterBtn.Size = new Size(208, 37);
            FilterBtn.TabIndex = 5;
            FilterBtn.Text = "Apply Filter";
            FilterBtn.UseVisualStyleBackColor = true;
            FilterBtn.Click += FilterBtn_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(374, 18);
            label2.Name = "label2";
            label2.Size = new Size(371, 21);
            label2.TabIndex = 4;
            label2.Text = "Filter list by product code, date from and date to:";
            // 
            // ToDTP
            // 
            ToDTP.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ToDTP.Location = new Point(751, 42);
            ToDTP.MinDate = new DateTime(2026, 1, 5, 0, 0, 0, 0);
            ToDTP.Name = "ToDTP";
            ToDTP.Size = new Size(208, 29);
            ToDTP.TabIndex = 3;
            ToDTP.ValueChanged += ToDTP_ValueChanged;
            // 
            // FromDTP
            // 
            FromDTP.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            FromDTP.Location = new Point(545, 42);
            FromDTP.MinDate = new DateTime(2026, 1, 5, 0, 0, 0, 0);
            FromDTP.Name = "FromDTP";
            FromDTP.Size = new Size(200, 29);
            FromDTP.TabIndex = 2;
            FromDTP.ValueChanged += FromDTP_ValueChanged;
            // 
            // CodeTxt
            // 
            CodeTxt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CodeTxt.CharacterCasing = CharacterCasing.Upper;
            CodeTxt.Location = new Point(303, 42);
            CodeTxt.Name = "CodeTxt";
            CodeTxt.PlaceholderText = "Filter by product code";
            CodeTxt.Size = new Size(236, 29);
            CodeTxt.TabIndex = 1;
            CodeTxt.TextChanged += CodeTxt_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(260, 22);
            label1.TabIndex = 0;
            label1.Text = "Salse History (Per Baskets)";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(SalesHistoryLv);
            panel2.Location = new Point(3, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(962, 654);
            panel2.TabIndex = 1;
            // 
            // SalesHistoryLv
            // 
            SalesHistoryLv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SalesHistoryLv.Columns.AddRange(new ColumnHeader[] { IdCL, ProductNameCL, CodeCL, QuantityCL, AmountCL, CommentCL });
            SalesHistoryLv.Cursor = Cursors.Hand;
            SalesHistoryLv.FullRowSelect = true;
            SalesHistoryLv.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "LVGroupBasket";
            SalesHistoryLv.Groups.AddRange(new ListViewGroup[] { listViewGroup1 });
            SalesHistoryLv.Location = new Point(0, 0);
            SalesHistoryLv.Name = "SalesHistoryLv";
            SalesHistoryLv.Size = new Size(962, 654);
            SalesHistoryLv.TabIndex = 0;
            SalesHistoryLv.UseCompatibleStateImageBehavior = false;
            SalesHistoryLv.View = View.Details;
            // 
            // IdCL
            // 
            IdCL.Text = "";
            // 
            // ProductNameCL
            // 
            ProductNameCL.Text = "Product Name";
            ProductNameCL.Width = 100;
            // 
            // CodeCL
            // 
            CodeCL.Text = "Product Code";
            CodeCL.Width = 100;
            // 
            // QuantityCL
            // 
            QuantityCL.Text = "Quantity";
            QuantityCL.Width = 100;
            // 
            // AmountCL
            // 
            AmountCL.Text = "Amout Paid";
            AmountCL.Width = 100;
            // 
            // CommentCL
            // 
            CommentCL.Text = "Basket Comment";
            CommentCL.Width = 100;
            // 
            // SalesHistoryCtls
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "SalesHistoryCtls";
            Size = new Size(968, 740);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private DateTimePicker ToDTP;
        private DateTimePicker FromDTP;
        private TextBox CodeTxt;
        private Button FilterBtn;
        private Label label2;
        private Panel panel2;
        private ListView SalesHistoryLv;
        private ColumnHeader IdCL;
        private ColumnHeader ProductNameCL;
        private ColumnHeader CodeCL;
        private ColumnHeader QuantityCL;
        private ColumnHeader AmountCL;
        private ColumnHeader CommentCL;
    }
}
