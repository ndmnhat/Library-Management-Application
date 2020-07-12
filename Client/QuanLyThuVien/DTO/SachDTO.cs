using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class SachDTO
    {
        public string BookID { get; set; }
        public string Bookname { get; set; }
        public string Author { get; set; }
        public string YearofPub { get; set; }
        public string Category { get; set; }
        public DateTime CreateAt { get; set; }
        public int Quantity { get; set; }
        public SachDTO()
        {

        }
    }
}
