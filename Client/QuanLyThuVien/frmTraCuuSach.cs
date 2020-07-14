using QuanLyThuVien.BUS;
using QuanLyThuVien.DTO;
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
	public partial class frmTraCuuSach : Form
	{
		public frmTraCuuSach()
		{
			InitializeComponent();
		}
        private void TxbKeyword_LostFocus(object sender, System.EventArgs e)
        {
            if (txbKeyword.Text == "")
                txbKeyword.Text = "Nhập từ khoá cần tìm ...";
        }

        private void TxbKeyword_GotFocus(object sender, System.EventArgs e)
        {
            txbKeyword.Text = "";
        }

        private async void btnTracuu_Click(object sender, EventArgs e)
        {
			var source = new BindingSource();
			source.DataSource = await SachBUS.TraCuuSach(txbKeyword.Text);
			dtGVSach.DataSource = source;
			dtGVSach.Columns[0].HeaderText = "Mã sách";
			dtGVSach.Columns[1].HeaderText = "Tên sách";
			dtGVSach.Columns[2].HeaderText = "Tác giả";
			dtGVSach.Columns[3].HeaderText = "Năm xuất bản";
			dtGVSach.Columns[4].HeaderText = "Thể loại";
			dtGVSach.Columns[5].HeaderText = "Ngày thêm";
			dtGVSach.Columns[6].HeaderText = "Số lượng";
		}
    }
}
