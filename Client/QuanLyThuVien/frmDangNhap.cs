using QuanLyThuVien.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
	public partial class frmDangNhap : Form
	{
		public frmDangNhap()
		{
			InitializeComponent();
		}

		private void frmDangNhap_Load(object sender, EventArgs e)
		{
			panel3.Visible = false;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			panel2.Visible = true;
			panel3.Visible = false;
			textBox3.Clear();
			textBox4.Clear();
			textBox5.Clear();
			textBox6.Clear();
			textBox7.Clear();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			panel2.Visible = false;
			panel3.Visible = true;
			txbUsername.Clear();
			txbPassword.Clear();
		}

		private async void buttonDangNhap_Click(object sender, EventArgs e)
		{
			if (await NguoiDungBUS.DangNhap(txbUsername.Text, txbPassword.Text))
			{
				DialogResult = DialogResult.OK;
				this.Close();
			}
		}
	}
}
