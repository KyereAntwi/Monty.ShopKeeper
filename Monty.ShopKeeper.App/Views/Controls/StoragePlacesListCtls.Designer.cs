namespace Monty.ShopKeeper.App.Views.Controls
{
    partial class StoragePlacesListCtls
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
            panel2 = new Panel();
            StorageLb = new ListBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            DeleteMI = new ToolStripMenuItem();
            addAProductToThisStorageToolStripMenuItem = new ToolStripMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Controls.Add(label1);
            panel1.ForeColor = SystemColors.ButtonHighlight;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(735, 49);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(14, 11);
            label1.Name = "label1";
            label1.Size = new Size(181, 25);
            label1.TabIndex = 0;
            label1.Text = "List of storge places";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(StorageLb);
            panel2.Location = new Point(3, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(735, 680);
            panel2.TabIndex = 1;
            // 
            // StorageLb
            // 
            StorageLb.ContextMenuStrip = contextMenuStrip1;
            StorageLb.Dock = DockStyle.Fill;
            StorageLb.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StorageLb.FormattingEnabled = true;
            StorageLb.Location = new Point(0, 0);
            StorageLb.Name = "StorageLb";
            StorageLb.Size = new Size(735, 680);
            StorageLb.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { DeleteMI, addAProductToThisStorageToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(294, 78);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // DeleteMI
            // 
            DeleteMI.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteMI.Name = "DeleteMI";
            DeleteMI.Size = new Size(185, 26);
            DeleteMI.Text = "Delete storage";
            DeleteMI.Click += DeleteMI_Click;
            // 
            // addAProductToThisStorageToolStripMenuItem
            // 
            addAProductToThisStorageToolStripMenuItem.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addAProductToThisStorageToolStripMenuItem.Name = "addAProductToThisStorageToolStripMenuItem";
            addAProductToThisStorageToolStripMenuItem.Size = new Size(293, 26);
            addAProductToThisStorageToolStripMenuItem.Text = "Add a product to this storage";
            // 
            // StoragePlacesListCtls
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "StoragePlacesListCtls";
            Size = new Size(741, 741);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private ListBox StorageLb;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem DeleteMI;
        private ToolStripMenuItem addAProductToThisStorageToolStripMenuItem;
    }
}
