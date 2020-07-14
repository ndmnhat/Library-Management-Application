using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibManagementApi.Models
{
    public class BookReturnings
    {
        [Key]
        public Guid BookReturningID { get; private set; }
        public Guid BookBorrowingID { get; set; }
        [Required]
        public BookBorrowings BookBorrowing { get; set; }
        [Required]
        public DateTime ActualReturnDate { get; set; }

    }
}