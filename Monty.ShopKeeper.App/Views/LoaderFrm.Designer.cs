namespace Monty.ShopKeeper.App.Views
{
    partial class LoaderFrm
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
            MessageLb = new Label();
            SuspendLayout();
            // 
            // MessageLb
            // 
            MessageLb.AutoSize = true;
            MessageLb.Location = new Point(12, 114);
            MessageLb.Name = "MessageLb";
            MessageLb.Size = new Size(72, 30);
            MessageLb.TabIndex = 0;
            MessageLb.Text = "label1";
            MessageLb.Click += MessageLb_Click;
            // 
            // LoaderFrm
            // 
            AutoScaleDimensions = new SizeF(13F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 251);
            Controls.Add(MessageLb);
            Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoaderFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "LoaderFrm";
            Load += LoaderFrm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label MessageLb;
    }
}