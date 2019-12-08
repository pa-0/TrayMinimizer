namespace About
{
	partial class AboutBox
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.logoPictureBox = new System.Windows.Forms.PictureBox();
			this.labelProductName = new System.Windows.Forms.Label();
			this.labelVersion = new System.Windows.Forms.Label();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.labelCompanyName = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.textBoxDescription = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.labelTitleFilter = new System.Windows.Forms.Label();
			this.labelFilter = new System.Windows.Forms.Label();
			this.tableLayoutPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.tableLayoutPanel.ColumnCount = 3;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.48626F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.70831F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.80543F));
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.linkLabel1, 0, 6);
			this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
			this.tableLayoutPanel.Controls.Add(this.okButton, 2, 6);
			this.tableLayoutPanel.Controls.Add(this.labelTitleFilter, 1, 5);
			this.tableLayoutPanel.Controls.Add(this.labelFilter, 2, 5);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(14, 14);
			this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 8;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.97191F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.97191F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.74719F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.91573F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.73221F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.661049F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel.Size = new System.Drawing.Size(624, 485);
			this.tableLayoutPanel.TabIndex = 0;
			// 
			// logoPictureBox
			// 
			this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
			this.logoPictureBox.Location = new System.Drawing.Point(4, 5);
			this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
			this.logoPictureBox.Size = new System.Drawing.Size(163, 416);
			this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			// 
			// labelProductName
			// 
			this.tableLayoutPanel.SetColumnSpan(this.labelProductName, 2);
			this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelProductName.Location = new System.Drawing.Point(180, 0);
			this.labelProductName.Margin = new System.Windows.Forms.Padding(9, 0, 4, 0);
			this.labelProductName.MaximumSize = new System.Drawing.Size(0, 26);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new System.Drawing.Size(440, 26);
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "Nom du produit";
			this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelProductName.Click += new System.EventHandler(this.labelProductName_Click);
			// 
			// labelVersion
			// 
			this.tableLayoutPanel.SetColumnSpan(this.labelVersion, 2);
			this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelVersion.Location = new System.Drawing.Point(180, 42);
			this.labelVersion.Margin = new System.Windows.Forms.Padding(9, 0, 4, 0);
			this.labelVersion.MaximumSize = new System.Drawing.Size(0, 26);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(440, 26);
			this.labelVersion.TabIndex = 0;
			this.labelVersion.Text = "Version";
			this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCopyright
			// 
			this.tableLayoutPanel.SetColumnSpan(this.labelCopyright, 2);
			this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCopyright.Location = new System.Drawing.Point(180, 84);
			this.labelCopyright.Margin = new System.Windows.Forms.Padding(9, 0, 4, 0);
			this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 26);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(440, 26);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "Copyright";
			this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelCompanyName
			// 
			this.tableLayoutPanel.SetColumnSpan(this.labelCompanyName, 2);
			this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelCompanyName.Location = new System.Drawing.Point(180, 147);
			this.labelCompanyName.Margin = new System.Windows.Forms.Padding(9, 0, 4, 0);
			this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 26);
			this.labelCompanyName.Name = "labelCompanyName";
			this.labelCompanyName.Size = new System.Drawing.Size(440, 21);
			this.labelCompanyName.TabIndex = 22;
			this.labelCompanyName.Text = "Nom de la société";
			this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.tableLayoutPanel.SetColumnSpan(this.linkLabel1, 2);
			this.linkLabel1.Location = new System.Drawing.Point(3, 426);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(185, 20);
			this.linkLabel1.TabIndex = 25;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "mailto:gloops@zailes.org";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// textBoxDescription
			// 
			this.tableLayoutPanel.SetColumnSpan(this.textBoxDescription, 2);
			this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxDescription.Location = new System.Drawing.Point(180, 173);
			this.textBoxDescription.Margin = new System.Windows.Forms.Padding(9, 5, 4, 5);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxDescription.Size = new System.Drawing.Size(440, 211);
			this.textBoxDescription.TabIndex = 23;
			this.textBoxDescription.TabStop = false;
			this.textBoxDescription.Text = "Description";
			// 
			// okButton
			// 
			this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.okButton.Location = new System.Drawing.Point(508, 450);
			this.okButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.okButton.Name = "okButton";
			this.tableLayoutPanel.SetRowSpan(this.okButton, 2);
			this.okButton.Size = new System.Drawing.Size(112, 30);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// labelTitleFilter
			// 
			this.labelTitleFilter.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelTitleFilter.AutoSize = true;
			this.labelTitleFilter.Location = new System.Drawing.Point(174, 397);
			this.labelTitleFilter.Name = "labelTitleFilter";
			this.labelTitleFilter.Size = new System.Drawing.Size(95, 20);
			this.labelTitleFilter.TabIndex = 26;
			this.labelTitleFilter.Text = "Filter string :";
			// 
			// labelFilter
			// 
			this.labelFilter.AutoSize = true;
			this.labelFilter.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelFilter.Location = new System.Drawing.Point(278, 389);
			this.labelFilter.Name = "labelFilter";
			this.labelFilter.Size = new System.Drawing.Size(31, 31);
			this.labelFilter.TabIndex = 27;
			this.labelFilter.Text = "_";
			// 
			// AboutBox
			// 
			this.AcceptButton = this.okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(652, 513);
			this.Controls.Add(this.tableLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(14);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AboutBox";
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label labelVersion;
		private System.Windows.Forms.Label labelCopyright;
		private System.Windows.Forms.Label labelCompanyName;
		private System.Windows.Forms.TextBox textBoxDescription;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label labelTitleFilter;
		private System.Windows.Forms.Label labelFilter;
	}
}
