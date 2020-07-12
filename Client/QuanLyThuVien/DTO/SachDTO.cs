using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVien.DTO
{
    class SachDTO
    {
        public string BookID    { get; set; }
        public string Bookname  { get; set; }
        public string Author    { get; set; }
        public string YearofPub { get; set; }
        public string Category  { get; set; }
        public DateTime CreateAt { get; set; }
        public int Quantity { get; set; }
        public SachDTO()
        {

        }
        public SachDTO(string BookID, string Bookname, string Author, string YearofPub, string Category, DateTime CreateAt, int Quantity)
        {
            this.BookID = BookID;
            this.Bookname = Bookname;
            this.Author = Author;
            this.YearofPub = YearofPub;
            this.Category = Category;
            this.CreateAt = CreateAt;
            this.Quantity = Quantity;
        }
        public SachDTO(string Bookname, string Author, string YearofPub, string Category, DateTime CreateAt, int Quantity)
        {
            this.Bookname = Bookname;
            this.Author = Author;
            this.YearofPub = YearofPub;
            this.Category = Category;
            this.CreateAt = CreateAt;
            this.Quantity = Quantity;
        }
    }
}
