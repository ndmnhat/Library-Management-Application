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
	public partial class frmQuanLySach : Form
	{
		public frmQuanLySach()
		{
			InitializeComponent();
		}
		string CurrentBookID = "";

        private async void frmQuanLySach_Load(object sender, EventArgs e)
        {
			this.txbNgayThem.Text = DateTime.Now.ToShortDateString();
			await ReloaddtGVSach();
		}

        private async void btnThem_Click(object sender, EventArgs e)
        {
			 bool isAdded = await SachBUS.ThemSach(new SachDTO(txbTenSach.Text, txbTacGia.Text, txbNamXuatBan.Text, txbTheLoai.Text, DateTime.Now, int.Parse(txbSoLuong.Text)));
			if (isAdded)
			{
				MessageBox.Show("Thêm sách thành công");
				await ReloaddtGVSach();
				ClearTxb();
			}
			else
				MessageBox.Show("Thêm sách thất bại");

        }
		private async Task ReloaddtGVSach()
        {
			var source = new BindingSource();
			source.DataSource = await SachBUS.TraCuuSach();
			dtGVSach.DataSource = source;
			dtGVSach.Columns[0].HeaderText = "Mã sách";
			dtGVSach.Columns[1].HeaderText = "Tên sách";
			dtGVSach.Columns[2].HeaderText = "Tác giả";
			dtGVSach.Columns[3].HeaderText = "Năm xuất bản";
			dtGVSach.Columns[4].HeaderText = "Thể loại";
			dtGVSach.Columns[5].HeaderText = "Ngày thêm";
			dtGVSach.Columns[6].HeaderText = "Số lượng";
		}

        private void dtGVSach_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
			CurrentBookID = dtGVSach.Rows[e.RowIndex].Cells[0].Value.ToString();
			txbTenSach.Text = dtGVSach.Rows[e.RowIndex].Cells[1].Value.ToString();
			txbTacGia.Text = dtGVSach.Rows[e.RowIndex].Cells[2].Value.ToString();
			txbNamXuatBan.Text = dtGVSach.Rows[e.RowIndex].Cells[3].Value.ToString();
			txbTheLoai.Text = dtGVSach.Rows[e.RowIndex].Cells[4].Value.ToString();
			txbNgayThem.Text = dtGVSach.Rows[e.RowIndex].Cells[5].Value.ToString();
			txbSoLuong.Text = dtGVSach.Rows[e.RowIndex].Cells[6].Value.ToString();
		}

        private void btnClear_Click(object sender, EventArgs e)
        {
			ClearTxb();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
			if (CurrentBookID != "")
			{
				bool isDeleted = await SachBUS.XoaSach(new SachDTO(CurrentBookID, txbTenSach.Text, txbTacGia.Text, txbNamXuatBan.Text, txbTheLoai.Text, DateTime.Now, int.Parse(txbSoLuong.Text)));
				if (isDeleted)
				{
					MessageBox.Show("Xoá sách thành công");
					await ReloaddtGVSach();
					ClearTxb();
				}
				else
					MessageBox.Show("Xoá sách thất bại");
			}
			else
				MessageBox.Show("Chưa chọn sách để xoá");
		}

        private async void btnSua_Click(object sender, EventArgs e)
        {
			if (CurrentBookID != "")
			{
				bool isEdited = await SachBUS.SuaSach(new SachDTO(CurrentBookID, txbTenSach.Text, txbTacGia.Text, txbNamXuatBan.Text, txbTheLoai.Text, DateTime.Now, int.Parse(txbSoLuong.Text)));
				if (isEdited)
				{
					MessageBox.Show("Sửa thông tin sách thành công");
					await ReloaddtGVSach();
					ClearTxb();
				}
				else
					MessageBox.Show("Sửa thông sách thất bại");
			}
			else
				MessageBox.Show("Chưa chọn sách để sửa thông tin");
		}
		private void ClearTxb()
        {
			CurrentBookID = "";
			txbNamXuatBan.Clear();
			txbNgayThem.Clear();
			txbSoLuong.Clear();
			txbTacGia.Clear();
			txbTenSach.Clear();
			txbTheLoai.Clear();
		}
    }
}
