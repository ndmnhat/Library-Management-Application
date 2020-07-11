using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibManagementApi.Models
{
    public class BookBorrowings
    {
        [Key]
        public Guid BookBorrowingID { get; private set; }
        [Required]
        public Users User { get; set; }
        [Required]
        public Books Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public BookReturnings BookReturning { get; set; }
    }
}