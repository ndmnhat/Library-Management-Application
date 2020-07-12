using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace LibManagementApi.Models
{
    public class Books
    {
        [Key]
        public Guid BookID { get; private set; }
        [Required]
        public string Bookname { get; set; }
        [Required]
        public string Author { get; set; }
        public string YearofPub { get; set; }
        public string Category { get; set; }
        public DateTime CreateAt { get; set; }
        public int Quantity { get; set; }
        public ICollection<BookBorrowings> BookBorrowings { get; set; }
    }
}