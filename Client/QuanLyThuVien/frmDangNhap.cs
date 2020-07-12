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
			panelDangKy.Visible = false;
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			lblTop.Text = "ĐĂNG NHẬP";
			panelDangNhap.Visible = true;
			panelDangKy.Visible = false;
			txbTenDK.Clear();
			txbEmailDK.Clear();
			txbUsernameDK.Clear();
			txbPasswordDK.Clear();
			txbVerifyPasswordDK.Clear();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			lblTop.Text = "ĐĂNG KÝ";
			panelDangNhap.Visible = false;
			panelDangKy.Visible = true;
			txbUsername.Clear();
			txbPassword.Clear();
		}

		private async void buttonDangNhap_Click(object sender, EventArgs e)
		{
			if (await NguoiDungBUS.DangNhap(new DTO.NguoiDungDTO(txbUsername.Text,txbPassword.Text)))
			{
				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

        private async void buttonDangKy_Click(object sender, EventArgs e)
        {
			if (txbPasswordDK.Text != txbVerifyPasswordDK.Text)
				MessageBox.Show("Nhập lại mật khẩu không chính xác");
			else if (await NguoiDungBUS.DangKy(new DTO.NguoiDungDTO(txbUsernameDK.Text, txbPasswordDK.Text, txbTenDK.Text, txbEmailDK.Text,"Member")))
			{
				MessageBox.Show("Đăng ký thành công");
			}
			else MessageBox.Show("Đăng ký thất bại");
			
		}
    }
}
