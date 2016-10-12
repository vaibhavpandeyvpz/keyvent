namespace Keyvent
{
    partial class KeyventForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyventForm));
            this.ShortcutLabel = new System.Windows.Forms.Label();
            this.KeyventTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayIconMenuExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearTimer = new System.Windows.Forms.Timer(this.components);
            this.TrayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShortcutLabel
            // 
            this.ShortcutLabel.BackColor = System.Drawing.Color.Black;
            this.ShortcutLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ShortcutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShortcutLabel.ForeColor = System.Drawing.Color.White;
            this.ShortcutLabel.Location = new System.Drawing.Point(0, 0);
            this.ShortcutLabel.Name = "ShortcutLabel";
            this.ShortcutLabel.Size = new System.Drawing.Size(192, 96);
            this.ShortcutLabel.TabIndex = 1;
            this.ShortcutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KeyventTrayIcon
            // 
            this.KeyventTrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.KeyventTrayIcon.BalloonTipText = "Keyvent";
            this.KeyventTrayIcon.BalloonTipTitle = "Keyvent is monitoring shortcut keys. To exit, check system tray.";
            this.KeyventTrayIcon.ContextMenuStrip = this.TrayMenuStrip;
            this.KeyventTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("KeyventTrayIcon.Icon")));
            this.KeyventTrayIcon.Visible = true;
            // 
            // TrayMenuStrip
            // 
            this.TrayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrayIconMenuExitItem});
            this.TrayMenuStrip.Name = "TrayIconMenuStrip";
            this.TrayMenuStrip.Size = new System.Drawing.Size(153, 48);
            // 
            // TrayIconMenuExitItem
            // 
            this.TrayIconMenuExitItem.Name = "TrayIconMenuExitItem";
            this.TrayIconMenuExitItem.Size = new System.Drawing.Size(152, 22);
            this.TrayIconMenuExitItem.Text = "Exit";
            this.TrayIconMenuExitItem.Click += new System.EventHandler(this.TrayMenuExitItem_Click);
            // 
            // ClearTimer
            // 
            this.ClearTimer.Enabled = true;
            this.ClearTimer.Tick += new System.EventHandler(this.ClearTimer_Tick);
            // 
            // KeyventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(192, 96);
            this.ControlBox = false;
            this.Controls.Add(this.ShortcutLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(192, 96);
            this.Name = "KeyventForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KeyventForm_FormClosing);
            this.Load += new System.EventHandler(this.KeyventForm_Load);
            this.Shown += new System.EventHandler(this.KeyventToastForm_Shown);
            this.TrayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label ShortcutLabel;
        private System.Windows.Forms.NotifyIcon KeyventTrayIcon;
        private System.Windows.Forms.Timer ClearTimer;
        private System.Windows.Forms.ContextMenuStrip TrayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem TrayIconMenuExitItem;
    }
}