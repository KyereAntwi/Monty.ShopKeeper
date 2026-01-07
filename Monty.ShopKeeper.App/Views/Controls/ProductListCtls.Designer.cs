namespace Monty.ShopKeeper.App.Views.Controls
{
    partial class ProductListCtls
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
            label1 = new Label();
            StorageCB = new ComboBox();
            RefreshBtn = new Button();
            GoCodeBtn = new Button();
            label3 = new Label();
            SearchProductByCodeTxt = new TextBox();
            SearchProductTxt = new TextBox();
            panel2 = new Panel();
            ProductsLv = new ListView();
            LvCode = new ColumnHeader();
            LvName = new ColumnHeader();
            LvCreatedAt = new ColumnHeader();
            LvCurrentPrice = new ColumnHeader();
            LvStocksQuantity = new ColumnHeader();
            SelectedProductCMS = new ContextMenuStrip(components);
            updateProductToolStripMenuItem = new ToolStripMenuItem();
            AddStockMS = new ToolStripMenuItem();
            StockHistoryMS = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            AddToStorageMI = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            UpdateProductMS = new ToolStripMenuItem();
            DeleteProductMS = new ToolStripMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SelectedProductCMS.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(StorageCB);
            panel1.Controls.Add(RefreshBtn);
            panel1.Controls.Add(GoCodeBtn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(SearchProductByCodeTxt);
            panel1.Controls.Add(SearchProductTxt);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1262, 81);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(191, 57);
            label1.Name = "label1";
            label1.Size = new Size(203, 21);
            label1.TabIndex = 9;
            label1.Text = "Filter products by storage:";
            // 
            // StorageCB
            // 
            StorageCB.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StorageCB.FormattingEnabled = true;
            StorageCB.Location = new Point(400, 49);
            StorageCB.Name = "StorageCB";
            StorageCB.Size = new Size(264, 29);
            StorageCB.TabIndex = 8;
            StorageCB.SelectedIndexChanged += StorageCB_SelectedIndexChanged;
            // 
            // RefreshBtn
            // 
            RefreshBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RefreshBtn.BackColor = SystemColors.ButtonHighlight;
            RefreshBtn.FlatStyle = FlatStyle.Flat;
            RefreshBtn.Location = new Point(1013, 14);
            RefreshBtn.Name = "RefreshBtn";
            RefreshBtn.Size = new Size(246, 29);
            RefreshBtn.TabIndex = 7;
            RefreshBtn.Text = "Refresh product list";
            RefreshBtn.UseVisualStyleBackColor = false;
            RefreshBtn.Click += RefreshBtn_Click;
            // 
            // GoCodeBtn
            // 
            GoCodeBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            GoCodeBtn.BackColor = SystemColors.ButtonHighlight;
            GoCodeBtn.Enabled = false;
            GoCodeBtn.FlatStyle = FlatStyle.Flat;
            GoCodeBtn.Location = new Point(787, 14);
            GoCodeBtn.Name = "GoCodeBtn";
            GoCodeBtn.Size = new Size(220, 29);
            GoCodeBtn.TabIndex = 5;
            GoCodeBtn.Text = "Apply filter";
            GoCodeBtn.UseVisualStyleBackColor = false;
            GoCodeBtn.Click += GoCodeBtn_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 49);
            label3.Name = "label3";
            label3.Size = new Size(144, 24);
            label3.TabIndex = 4;
            label3.Text = "Products List";
            // 
            // SearchProductByCodeTxt
            // 
            SearchProductByCodeTxt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SearchProductByCodeTxt.Location = new Point(670, 49);
            SearchProductByCodeTxt.Name = "SearchProductByCodeTxt";
            SearchProductByCodeTxt.PlaceholderText = "Search product by Code ...";
            SearchProductByCodeTxt.Size = new Size(284, 29);
            SearchProductByCodeTxt.TabIndex = 2;
            SearchProductByCodeTxt.TextChanged += SearchProductByCodeTxt_TextChanged;
            // 
            // SearchProductTxt
            // 
            SearchProductTxt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SearchProductTxt.Location = new Point(960, 49);
            SearchProductTxt.Name = "SearchProductTxt";
            SearchProductTxt.PlaceholderText = "Search product by Name ...";
            SearchProductTxt.Size = new Size(299, 29);
            SearchProductTxt.TabIndex = 0;
            SearchProductTxt.TextChanged += SearchProductTxt_TextChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(ProductsLv);
            panel2.Location = new Point(3, 90);
            panel2.Name = "panel2";
            panel2.Size = new Size(1262, 767);
            panel2.TabIndex = 1;
            // 
            // ProductsLv
            // 
            ProductsLv.AllowColumnReorder = true;
            ProductsLv.BorderStyle = BorderStyle.FixedSingle;
            ProductsLv.Columns.AddRange(new ColumnHeader[] { LvCode, LvName, LvCreatedAt, LvCurrentPrice, LvStocksQuantity });
            ProductsLv.ContextMenuStrip = SelectedProductCMS;
            ProductsLv.Cursor = Cursors.Hand;
            ProductsLv.Dock = DockStyle.Fill;
            ProductsLv.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductsLv.FullRowSelect = true;
            ProductsLv.GridLines = true;
            ProductsLv.HoverSelection = true;
            ProductsLv.Location = new Point(0, 0);
            ProductsLv.Name = "ProductsLv";
            ProductsLv.Size = new Size(1262, 767);
            ProductsLv.Sorting = SortOrder.Ascending;
            ProductsLv.TabIndex = 0;
            ProductsLv.UseCompatibleStateImageBehavior = false;
            ProductsLv.View = View.Details;
            ProductsLv.SelectedIndexChanged += ProductsLv_SelectedIndexChanged;
            // 
            // LvCode
            // 
            LvCode.Text = "Product Unique Identifier (Code)";
            LvCode.Width = 200;
            // 
            // LvName
            // 
            LvName.Text = "Product Name";
            LvName.Width = 500;
            // 
            // LvCreatedAt
            // 
            LvCreatedAt.Text = "Date Added";
            LvCreatedAt.Width = 200;
            // 
            // LvCurrentPrice
            // 
            LvCurrentPrice.Text = "Current Selling Price of Product";
            LvCurrentPrice.Width = 200;
            // 
            // LvStocksQuantity
            // 
            LvStocksQuantity.Text = "Number of Stocks";
            LvStocksQuantity.Width = 100;
            // 
            // SelectedProductCMS
            // 
            SelectedProductCMS.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SelectedProductCMS.Items.AddRange(new ToolStripItem[] { updateProductToolStripMenuItem, toolStripMenuItem1, AddToStorageMI, toolStripMenuItem2, UpdateProductMS, DeleteProductMS });
            SelectedProductCMS.Name = "SelectedProductCMS";
            SelectedProductCMS.Size = new Size(390, 120);
            // 
            // updateProductToolStripMenuItem
            // 
            updateProductToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddStockMS, StockHistoryMS });
            updateProductToolStripMenuItem.Name = "updateProductToolStripMenuItem";
            updateProductToolStripMenuItem.Size = new Size(389, 26);
            updateProductToolStripMenuItem.Text = "Stock Product";
            // 
            // AddStockMS
            // 
            AddStockMS.Name = "AddStockMS";
            AddStockMS.Size = new Size(213, 26);
            AddStockMS.Text = "Add new stock";
            AddStockMS.Click += AddStockMS_Click;
            // 
            // StockHistoryMS
            // 
            StockHistoryMS.Name = "StockHistoryMS";
            StockHistoryMS.Size = new Size(213, 26);
            StockHistoryMS.Text = "View stock history";
            StockHistoryMS.Click += StockHistoryMS_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(386, 6);
            // 
            // AddToStorageMI
            // 
            AddToStorageMI.Name = "AddToStorageMI";
            AddToStorageMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Shift | Keys.G;
            AddToStorageMI.Size = new Size(389, 26);
            AddToStorageMI.Text = "Add product to storage";
            AddToStorageMI.Click += AddToStorageMI_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(386, 6);
            // 
            // UpdateProductMS
            // 
            UpdateProductMS.Name = "UpdateProductMS";
            UpdateProductMS.Size = new Size(389, 26);
            UpdateProductMS.Text = "Update Product";
            UpdateProductMS.Click += UpdateProductMS_Click;
            // 
            // DeleteProductMS
            // 
            DeleteProductMS.ForeColor = Color.Red;
            DeleteProductMS.Name = "DeleteProductMS";
            DeleteProductMS.Size = new Size(389, 26);
            DeleteProductMS.Text = "Completely Delete Product";
            DeleteProductMS.Click += DeleteProductMS_Click;
            // 
            // ProductListCtls
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "ProductListCtls";
            Size = new Size(1268, 860);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            SelectedProductCMS.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label3;
        private TextBox SearchProductByCodeTxt;
        private TextBox SearchProductTxt;
        private Button GoCodeBtn;
        private ListView ProductsLv;
        private ColumnHeader LvCode;
        private ColumnHeader LvName;
        private ColumnHeader LvCreatedAt;
        private ColumnHeader LvCurrentPrice;
        private Button RefreshBtn;
        private ColumnHeader LvStocksQuantity;
        private ContextMenuStrip SelectedProductCMS;
        private ToolStripMenuItem updateProductToolStripMenuItem;
        private ToolStripMenuItem AddStockMS;
        private ToolStripMenuItem StockHistoryMS;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem UpdateProductMS;
        private ToolStripMenuItem DeleteProductMS;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem AddToStorageMI;
        private Label label1;
        private ComboBox StorageCB;
    }
}
