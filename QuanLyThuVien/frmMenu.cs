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
	public partial class frmMenu : Form
	{
		public frmMenu()
		{
			InitializeComponent();
		}
		
		private void frmMenu_Load(object sender, EventArgs e)
		{
			frmDangNhap frmDangNhap = new frmDangNhap();
			frmDangNhap.ShowDialog();
			if (frmDangNhap.DialogResult != DialogResult.OK)
				this.Close();
			panel4.Visible = false;
		}

		Form activeform = null;
		private void OpenForm(Form form)
		{
			if (activeform != null)
				activeform.Close();
			activeform = form;
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			childpanelMenu.Controls.Add(form);
			childpanelMenu.Tag = form;
			form.BringToFront();
			form.Show();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (panel4.Visible)
			{
				panel4.Visible = false;
			}
			else panel4.Visible = true;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			OpenForm(new frmTraCuuSach());
		}

		private void button2_Click(object sender, EventArgs e)
		{
			OpenForm(new frmQuanLySach());
		}

		private void button7_Click(object sender, EventArgs e)
		{
			OpenForm(new frmDangKyMuon());

		}

		private void button5_Click(object sender, EventArgs e)
		{
			OpenForm(new frmLapBaoCao());
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OpenForm(new frmLapPhieuTra());
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OpenForm(new frmLapPhieuMuon());
		}
	}
}
