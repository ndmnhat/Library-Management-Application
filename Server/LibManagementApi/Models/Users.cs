using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace LibManagementApi.Models
{
    public class Users
    {
        [Key]
        public Guid UserID { get; private set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<BookBorrowings> BookBorrowingForms { get; set; }
    }
}