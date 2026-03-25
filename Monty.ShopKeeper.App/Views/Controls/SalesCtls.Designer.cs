namespace Monty.ShopKeeper.App.Views.Controls
{
    partial class SalesCtls
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            SendBtn = new Button();
            ReloadBtn = new Button();
            TodayLb = new Label();
            panel2 = new Panel();
            BasketLb = new ListBox();
            panel6 = new Panel();
            ClearBtn = new Button();
            AddBtn = new Button();
            QuantityTxt = new NumericUpDown();
            label6 = new Label();
            label4 = new Label();
            CodeTxt = new TextBox();
            panel4 = new Panel();
            BasketTotalLb = new Label();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            BasketHistoryLv = new ListView();
            IdCl = new ColumnHeader();
            CreatedAtCl = new ColumnHeader();
            TotalCl = new ColumnHeader();
            AmountReceivedCl = new ColumnHeader();
            BalancePaidCl = new ColumnHeader();
            DescriptionCl = new ColumnHeader();
            SalesItemMenus = new ContextMenuStrip(components);
            viewDetailsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            printReceiptToolStripMenuItem = new ToolStripMenuItem();
            makeAReturnOnThisSaleToolStripMenuItem = new ToolStripMenuItem();
            panel5 = new Panel();
            TotalLb = new Label();
            label3 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuantityTxt).BeginInit();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SalesItemMenus.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(SendBtn);
            panel1.Controls.Add(ReloadBtn);
            panel1.Controls.Add(TodayLb);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1249, 74);
            panel1.TabIndex = 0;
            // 
            // SendBtn
            // 
            SendBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SendBtn.BackColor = SystemColors.ButtonHighlight;
            SendBtn.FlatStyle = FlatStyle.Flat;
            SendBtn.Location = new Point(866, 19);
            SendBtn.Name = "SendBtn";
            SendBtn.Size = new Size(258, 52);
            SendBtn.TabIndex = 2;
            SendBtn.Text = "Process Basket";
            SendBtn.UseVisualStyleBackColor = false;
            SendBtn.Click += SendBtn_Click;
            // 
            // ReloadBtn
            // 
            ReloadBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ReloadBtn.BackColor = Color.DarkSalmon;
            ReloadBtn.FlatStyle = FlatStyle.Flat;
            ReloadBtn.ForeColor = Color.Brown;
            ReloadBtn.Location = new Point(1130, 19);
            ReloadBtn.Name = "ReloadBtn";
            ReloadBtn.Size = new Size(116, 52);
            ReloadBtn.TabIndex = 1;
            ReloadBtn.Text = "Reload";
            ReloadBtn.UseVisualStyleBackColor = false;
            ReloadBtn.Click += ReloadBtn_Click;
            // 
            // TodayLb
            // 
            TodayLb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            TodayLb.AutoSize = true;
            TodayLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TodayLb.Location = new Point(3, 30);
            TodayLb.Name = "TodayLb";
            TodayLb.Size = new Size(65, 22);
            TodayLb.TabIndex = 0;
            TodayLb.Text = "label1";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(BasketLb);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(3, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(484, 777);
            panel2.TabIndex = 1;
            // 
            // BasketLb
            // 
            BasketLb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BasketLb.FormattingEnabled = true;
            BasketLb.Location = new Point(0, 266);
            BasketLb.Name = "BasketLb";
            BasketLb.Size = new Size(481, 508);
            BasketLb.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(ClearBtn);
            panel6.Controls.Add(AddBtn);
            panel6.Controls.Add(QuantityTxt);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(CodeTxt);
            panel6.Location = new Point(3, 68);
            panel6.Name = "panel6";
            panel6.Size = new Size(478, 196);
            panel6.TabIndex = 1;
            // 
            // ClearBtn
            // 
            ClearBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ClearBtn.FlatStyle = FlatStyle.Flat;
            ClearBtn.Location = new Point(147, 157);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(161, 31);
            ClearBtn.TabIndex = 6;
            ClearBtn.Text = "Clear Basket";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // AddBtn
            // 
            AddBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddBtn.Enabled = false;
            AddBtn.FlatStyle = FlatStyle.Flat;
            AddBtn.Location = new Point(314, 157);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(161, 31);
            AddBtn.TabIndex = 5;
            AddBtn.Text = "Add to basket";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // QuantityTxt
            // 
            QuantityTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            QuantityTxt.Location = new Point(0, 122);
            QuantityTxt.Name = "QuantityTxt";
            QuantityTxt.Size = new Size(475, 29);
            QuantityTxt.TabIndex = 4;
            QuantityTxt.ValueChanged += QuantityTxt_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 98);
            label6.Name = "label6";
            label6.Size = new Size(72, 21);
            label6.TabIndex = 3;
            label6.Text = "Quantity";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 18);
            label4.Name = "label4";
            label4.Size = new Size(113, 21);
            label4.TabIndex = 1;
            label4.Text = "Product code:";
            // 
            // CodeTxt
            // 
            CodeTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            CodeTxt.CharacterCasing = CharacterCasing.Upper;
            CodeTxt.Location = new Point(3, 42);
            CodeTxt.Multiline = true;
            CodeTxt.Name = "CodeTxt";
            CodeTxt.PlaceholderText = "Product code here.... Eg: MG01";
            CodeTxt.Size = new Size(472, 46);
            CodeTxt.TabIndex = 0;
            CodeTxt.TextChanged += CodeTxt_TextChanged;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = SystemColors.ControlDark;
            panel4.Controls.Add(BasketTotalLb);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(label1);
            panel4.Location = new Point(3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(478, 59);
            panel4.TabIndex = 0;
            // 
            // BasketTotalLb
            // 
            BasketTotalLb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BasketTotalLb.AutoSize = true;
            BasketTotalLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BasketTotalLb.Location = new Point(297, 19);
            BasketTotalLb.Name = "BasketTotalLb";
            BasketTotalLb.Size = new Size(21, 22);
            BasketTotalLb.TabIndex = 2;
            BasketTotalLb.Text = "0";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(297, 0);
            label2.Name = "label2";
            label2.Size = new Size(178, 21);
            label2.TabIndex = 1;
            label2.Text = "Total amount in basket:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(14, 20);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 0;
            label1.Text = "Basket";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(BasketHistoryLv);
            panel3.Controls.Add(panel5);
            panel3.Location = new Point(493, 83);
            panel3.Name = "panel3";
            panel3.Size = new Size(756, 777);
            panel3.TabIndex = 2;
            // 
            // BasketHistoryLv
            // 
            BasketHistoryLv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BasketHistoryLv.Columns.AddRange(new ColumnHeader[] { IdCl, CreatedAtCl, TotalCl, AmountReceivedCl, BalancePaidCl, DescriptionCl });
            BasketHistoryLv.ContextMenuStrip = SalesItemMenus;
            BasketHistoryLv.FullRowSelect = true;
            BasketHistoryLv.GridLines = true;
            BasketHistoryLv.Location = new Point(3, 68);
            BasketHistoryLv.Name = "BasketHistoryLv";
            BasketHistoryLv.Size = new Size(750, 706);
            BasketHistoryLv.TabIndex = 1;
            BasketHistoryLv.UseCompatibleStateImageBehavior = false;
            BasketHistoryLv.View = View.Details;
            // 
            // IdCl
            // 
            IdCl.Text = "Id";
            // 
            // CreatedAtCl
            // 
            CreatedAtCl.Text = "Created At";
            CreatedAtCl.Width = 200;
            // 
            // TotalCl
            // 
            TotalCl.Text = "Total Amount";
            TotalCl.Width = 200;
            // 
            // AmountReceivedCl
            // 
            AmountReceivedCl.DisplayIndex = 5;
            AmountReceivedCl.Text = "Amount Received";
            AmountReceivedCl.Width = 100;
            // 
            // BalancePaidCl
            // 
            BalancePaidCl.Text = "Balance Paid";
            BalancePaidCl.Width = 100;
            // 
            // DescriptionCl
            // 
            DescriptionCl.DisplayIndex = 3;
            DescriptionCl.Text = "Comments";
            DescriptionCl.Width = 200;
            // 
            // SalesItemMenus
            // 
            SalesItemMenus.Items.AddRange(new ToolStripItem[] { viewDetailsToolStripMenuItem, toolStripMenuItem1, printReceiptToolStripMenuItem, makeAReturnOnThisSaleToolStripMenuItem });
            SalesItemMenus.Name = "SalesItemMenus";
            SalesItemMenus.Size = new Size(210, 76);
            // 
            // viewDetailsToolStripMenuItem
            // 
            viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            viewDetailsToolStripMenuItem.Size = new Size(209, 22);
            viewDetailsToolStripMenuItem.Text = "View Details";
            viewDetailsToolStripMenuItem.Click += viewDetailsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(206, 6);
            // 
            // printReceiptToolStripMenuItem
            // 
            printReceiptToolStripMenuItem.Name = "printReceiptToolStripMenuItem";
            printReceiptToolStripMenuItem.Size = new Size(209, 22);
            printReceiptToolStripMenuItem.Text = "Print Receipt";
            printReceiptToolStripMenuItem.Click += printReceiptToolStripMenuItem_Click;
            // 
            // makeAReturnOnThisSaleToolStripMenuItem
            // 
            makeAReturnOnThisSaleToolStripMenuItem.Name = "makeAReturnOnThisSaleToolStripMenuItem";
            makeAReturnOnThisSaleToolStripMenuItem.Size = new Size(209, 22);
            makeAReturnOnThisSaleToolStripMenuItem.Text = "Make a return on this sale";
            makeAReturnOnThisSaleToolStripMenuItem.Click += makeAReturnOnThisSaleToolStripMenuItem_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = SystemColors.ControlDark;
            panel5.Controls.Add(TotalLb);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(750, 59);
            panel5.TabIndex = 0;
            // 
            // TotalLb
            // 
            TotalLb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TotalLb.AutoSize = true;
            TotalLb.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TotalLb.Location = new Point(522, 21);
            TotalLb.Name = "TotalLb";
            TotalLb.Size = new Size(21, 22);
            TotalLb.TabIndex = 4;
            TotalLb.Text = "0";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(14, 20);
            label3.Name = "label3";
            label3.Size = new Size(226, 21);
            label3.TabIndex = 3;
            label3.Text = "Basket logs so far for the day:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(522, 0);
            label5.Name = "label5";
            label5.Size = new Size(228, 21);
            label5.TabIndex = 3;
            label5.Text = "Total amount sales for the day";
            // 
            // SalesCtls
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "SalesCtls";
            Size = new Size(1255, 863);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)QuantityTxt).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            SalesItemMenus.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label TodayLb;
        private Button ReloadBtn;
        private Panel panel2;
        private Button SendBtn;
        private Panel panel3;
        private Panel panel4;
        private Label BasketTotalLb;
        private Label label2;
        private Label label1;
        private Panel panel5;
        private Label TotalLb;
        private Label label3;
        private Label label5;
        private Panel panel6;
        private NumericUpDown QuantityTxt;
        private Label label6;
        private Label label4;
        private TextBox CodeTxt;
        private ListBox BasketLb;
        private Button AddBtn;
        private ListView BasketHistoryLv;
        private ColumnHeader IdCl;
        private ColumnHeader CreatedAtCl;
        private ColumnHeader TotalCl;
        private ColumnHeader DescriptionCl;
        private Button ClearBtn;
        private ColumnHeader AmountReceivedCl;
        private ColumnHeader BalancePaidCl;
        private ContextMenuStrip SalesItemMenus;
        private ToolStripMenuItem viewDetailsToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem printReceiptToolStripMenuItem;
        private ToolStripMenuItem makeAReturnOnThisSaleToolStripMenuItem;
    }
}
