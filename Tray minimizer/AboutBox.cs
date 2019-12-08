using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace About
{
	partial class AboutBox : Form
	{
		public string programname { get; set; }

		public AboutBox(string Title):base()
		{
			initialize();

			this.labelFilter.Text = Title;
		}

		public AboutBox()
		{
			initialize();
		}

		public string LabelFilter
		{
			set
			{
				labelFilter.Text = value;
			}
		}

		private void initialize()
		{
			InitializeComponent();
			this.Text = String.Format("À propos de {0}", AssemblyTitle);
			this.labelProductName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
			this.labelCopyright.Text = AssemblyCopyright;
			this.labelCompanyName.Text = AssemblyCompany;
			this.textBoxDescription.Text = AssemblyDescription;
			this.textBoxDescription.Text +=
				"Version 1 by Georgi Dalakishvili (2007)"
				+ Environment.NewLine
				+ "version 2 by Hubert Canevet (2019)"
				+ Environment.NewLine
				+ "allows use of several occurrences"
				+ Environment.NewLine
				+ "and filters windows with a character string in the command line."
				+ Environment.NewLine;

		}

		#region Accesseurs d'attribut de l'assembly

		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		private void labelProductName_Click(object sender, EventArgs e)
		{

		}

		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(linkLabel1.Text);
		}
	}
}
