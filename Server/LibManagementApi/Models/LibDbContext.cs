using Microsoft.EntityFrameworkCore;
using LibManagementApi.Models;

namespace LibManagementApi.Models
{
    public class LibDbContext : DbContext
    {
        public LibDbContext(DbContextOptions<LibDbContext> options)
            : base(options)
        {
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<LibManagementApi.Models.Books> Books { get; set; }
        public DbSet<LibManagementApi.Models.BookBorrowings> BookBorrowings { get; set; }
        public DbSet<LibManagementApi.Models.BookReturnings> BookReturnings { get; set; }
    }
}