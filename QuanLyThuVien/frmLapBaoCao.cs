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
	public partial class frmLapBaoCao : Form
	{
		public frmLapBaoCao()
		{
			InitializeComponent();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			panel3.Visible = true;
			panel4.Visible = false;
			textBox1.Clear();
			textBox2.Clear();
			dataGridView1.Rows.Clear() ;
		}

		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			panel3.Visible = false;
			panel4.Visible = true;
			textBox3.Clear();
			dataGridView2.Rows.Clear();
		}

		private void frmLapBaoCao_Load(object sender, EventArgs e)
		{
			panel4.Visible = false;
		}
	}
}
