namespace Tray_minimizer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

		bool _disposing = false;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
			_disposing = true;
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
			this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
			this.AppContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.Separator = new System.Windows.Forms.ToolStripSeparator();
			this.quick = new System.Windows.Forms.ToolStripMenuItem();
			this.all = new System.Windows.Forms.ToolStripMenuItem();
			this.alltray = new System.Windows.Forms.ToolStripMenuItem();
			this.Exititem = new System.Windows.Forms.ToolStripMenuItem();
			this.Abouttoolstrip = new System.Windows.Forms.ToolStripMenuItem();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.AppContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// Tray
			// 
			this.Tray.ContextMenuStrip = this.AppContextMenu;
			this.Tray.Icon = global::Tray_minimizer.Properties.Resources.icon;
			this.Tray.Text = "Tray minimizer\r\nDouble-Click to reduce\r\n";
			this.Tray.Visible = true;
			this.Tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseDoubleClick);
			// 
			// AppContextMenu
			// 
			this.AppContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.AppContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Separator,
            this.quick,
            this.Exititem,
            this.Abouttoolstrip});
			this.AppContextMenu.Name = "AppContextMenu";
			this.AppContextMenu.ShowImageMargin = false;
			this.AppContextMenu.Size = new System.Drawing.Size(223, 112);
			this.AppContextMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.AppContextMenu_Closed);
			this.AppContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.AppContextMenu_Opening);
			// 
			// Separator
			// 
			this.Separator.Name = "Separator";
			this.Separator.Size = new System.Drawing.Size(219, 6);
			// 
			// quick
			// 
			this.quick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.quick.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.all,
            this.alltray});
			this.quick.Name = "quick";
			this.quick.Size = new System.Drawing.Size(222, 34);
			this.quick.Text = "Quick commands";
			// 
			// all
			// 
			this.all.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.all.Name = "all";
			this.all.Size = new System.Drawing.Size(188, 34);
			this.all.Text = "Show All";
			this.all.Click += new System.EventHandler(this.all_Click);
			// 
			// alltray
			// 
			this.alltray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.alltray.Name = "alltray";
			this.alltray.Size = new System.Drawing.Size(188, 34);
			this.alltray.Text = "All to tray";
			this.alltray.Click += new System.EventHandler(this.alltray_Click);
			// 
			// Exititem
			// 
			this.Exititem.Name = "Exititem";
			this.Exititem.Size = new System.Drawing.Size(222, 34);
			this.Exititem.Text = "Exit";
			this.Exititem.Click += new System.EventHandler(this.Exititem_Click);
			// 
			// Abouttoolstrip
			// 
			this.Abouttoolstrip.Name = "Abouttoolstrip";
			this.Abouttoolstrip.Size = new System.Drawing.Size(222, 34);
			this.Abouttoolstrip.Text = "About";
			this.Abouttoolstrip.Click += new System.EventHandler(this.Abouttoolstrip_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			// 
			// timer1
			// 
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(341, 322);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "Form1";
			this.Opacity = 0D;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "TrayMinimizer F1";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DoubleClick += new System.EventHandler(this.Form1_DoubleClick);
			this.AppContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.ContextMenuStrip AppContextMenu;
        private System.Windows.Forms.ToolStripMenuItem Exititem;
        private System.Windows.Forms.ToolStripSeparator Separator;
        private System.Windows.Forms.ToolStripMenuItem quick;
        private System.Windows.Forms.ToolStripMenuItem all;
        private System.Windows.Forms.ToolStripMenuItem alltray;
        private System.Windows.Forms.ToolStripMenuItem Abouttoolstrip;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Timer timer1;
	}
}

