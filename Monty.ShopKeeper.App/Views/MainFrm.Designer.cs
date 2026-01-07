namespace Monty.ShopKeeper.App.Views
{
    partial class MainFrm
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            logoutCurrentAccountToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ExistApplicationMI = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            systemAdministrationToolStripMenuItem = new ToolStripMenuItem();
            registerSystemUserToolStripMenuItem = new ToolStripMenuItem();
            viewAllSystemUsersToolStripMenuItem = new ToolStripMenuItem();
            ProductsMI = new ToolStripMenuItem();
            AddProductMI = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            ListProductsMI = new ToolStripMenuItem();
            storageStagesToolStripMenuItem = new ToolStripMenuItem();
            NewStorageMI = new ToolStripMenuItem();
            AllStorageMI = new ToolStripMenuItem();
            salesToolStripMenuItem = new ToolStripMenuItem();
            SaleMI = new ToolStripMenuItem();
            SalesHistoryMI = new ToolStripMenuItem();
            MainPanel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, ProductsMI, storageStagesToolStripMenuItem, salesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1291, 29);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logoutCurrentAccountToolStripMenuItem, toolStripMenuItem1, ExistApplicationMI, toolStripMenuItem3, systemAdministrationToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F;
            fileToolStripMenuItem.Size = new Size(47, 25);
            fileToolStripMenuItem.Text = "File";
            // 
            // logoutCurrentAccountToolStripMenuItem
            // 
            logoutCurrentAccountToolStripMenuItem.Name = "logoutCurrentAccountToolStripMenuItem";
            logoutCurrentAccountToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.A;
            logoutCurrentAccountToolStripMenuItem.Size = new Size(345, 26);
            logoutCurrentAccountToolStripMenuItem.Text = "Logout current Account";
            logoutCurrentAccountToolStripMenuItem.Click += logoutCurrentAccountToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(342, 6);
            // 
            // ExistApplicationMI
            // 
            ExistApplicationMI.Name = "ExistApplicationMI";
            ExistApplicationMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.E;
            ExistApplicationMI.Size = new Size(345, 26);
            ExistApplicationMI.Text = "Exist Application";
            ExistApplicationMI.Click += ExistApplicationMI_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(342, 6);
            // 
            // systemAdministrationToolStripMenuItem
            // 
            systemAdministrationToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registerSystemUserToolStripMenuItem, viewAllSystemUsersToolStripMenuItem });
            systemAdministrationToolStripMenuItem.Name = "systemAdministrationToolStripMenuItem";
            systemAdministrationToolStripMenuItem.Size = new Size(345, 26);
            systemAdministrationToolStripMenuItem.Text = "System Administration";
            // 
            // registerSystemUserToolStripMenuItem
            // 
            registerSystemUserToolStripMenuItem.Name = "registerSystemUserToolStripMenuItem";
            registerSystemUserToolStripMenuItem.Size = new Size(235, 26);
            registerSystemUserToolStripMenuItem.Text = "Register System User";
            // 
            // viewAllSystemUsersToolStripMenuItem
            // 
            viewAllSystemUsersToolStripMenuItem.Name = "viewAllSystemUsersToolStripMenuItem";
            viewAllSystemUsersToolStripMenuItem.Size = new Size(235, 26);
            viewAllSystemUsersToolStripMenuItem.Text = "View all system users";
            // 
            // ProductsMI
            // 
            ProductsMI.DropDownItems.AddRange(new ToolStripItem[] { AddProductMI, toolStripMenuItem2, ListProductsMI });
            ProductsMI.Name = "ProductsMI";
            ProductsMI.ShortcutKeys = Keys.Alt | Keys.P;
            ProductsMI.Size = new Size(87, 25);
            ProductsMI.Text = "Products";
            // 
            // AddProductMI
            // 
            AddProductMI.Name = "AddProductMI";
            AddProductMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.P;
            AddProductMI.Size = new Size(338, 26);
            AddProductMI.Text = "Add a product";
            AddProductMI.Click += AddProductMI_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(335, 6);
            // 
            // ListProductsMI
            // 
            ListProductsMI.Name = "ListProductsMI";
            ListProductsMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Shift | Keys.P;
            ListProductsMI.Size = new Size(338, 26);
            ListProductsMI.Text = "View all products";
            ListProductsMI.Click += ListProductsMI_Click;
            // 
            // storageStagesToolStripMenuItem
            // 
            storageStagesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { NewStorageMI, AllStorageMI });
            storageStagesToolStripMenuItem.Name = "storageStagesToolStripMenuItem";
            storageStagesToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.R;
            storageStagesToolStripMenuItem.Size = new Size(133, 25);
            storageStagesToolStripMenuItem.Text = "Storage Stages";
            // 
            // NewStorageMI
            // 
            NewStorageMI.Name = "NewStorageMI";
            NewStorageMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.R;
            NewStorageMI.Size = new Size(342, 26);
            NewStorageMI.Text = "Add a new storge stage";
            NewStorageMI.Click += NewStorageMI_Click;
            // 
            // AllStorageMI
            // 
            AllStorageMI.Name = "AllStorageMI";
            AllStorageMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Shift | Keys.R;
            AllStorageMI.Size = new Size(342, 26);
            AllStorageMI.Text = "View all Stages";
            AllStorageMI.Click += AllStorageMI_Click;
            // 
            // salesToolStripMenuItem
            // 
            salesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaleMI, SalesHistoryMI });
            salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            salesToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.S;
            salesToolStripMenuItem.Size = new Size(59, 25);
            salesToolStripMenuItem.Text = "Sales";
            // 
            // SaleMI
            // 
            SaleMI.Name = "SaleMI";
            SaleMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
            SaleMI.Size = new Size(342, 26);
            SaleMI.Text = "Make a sale";
            SaleMI.Click += SaleMI_Click;
            // 
            // SalesHistoryMI
            // 
            SalesHistoryMI.Name = "SalesHistoryMI";
            SalesHistoryMI.ShortcutKeys = Keys.Control | Keys.Alt | Keys.Shift | Keys.S;
            SalesHistoryMI.Size = new Size(342, 26);
            SalesHistoryMI.Text = "View sales history";
            SalesHistoryMI.Click += SalesHistoryMI_Click;
            // 
            // MainPanel
            // 
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 29);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1291, 797);
            MainPanel.TabIndex = 1;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1291, 826);
            Controls.Add(MainPanel);
            Controls.Add(menuStrip1);
            Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "MainFrm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shop Keeping SMS";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem ExistApplicationMI;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem logoutCurrentAccountToolStripMenuItem;
        private ToolStripMenuItem ProductsMI;
        private ToolStripMenuItem AddProductMI;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem ListProductsMI;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem systemAdministrationToolStripMenuItem;
        private ToolStripMenuItem registerSystemUserToolStripMenuItem;
        private ToolStripMenuItem viewAllSystemUsersToolStripMenuItem;
        private Panel MainPanel;
        private ToolStripMenuItem storageStagesToolStripMenuItem;
        private ToolStripMenuItem NewStorageMI;
        private ToolStripMenuItem AllStorageMI;
        private ToolStripMenuItem salesToolStripMenuItem;
        private ToolStripMenuItem SaleMI;
        private ToolStripMenuItem SalesHistoryMI;
    }
}