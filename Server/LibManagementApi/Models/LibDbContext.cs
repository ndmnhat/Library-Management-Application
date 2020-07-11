using Microsoft.EntityFrameworkCore;

namespace LibManagementApi.Models
{
    public class LibDbContext : DbContext
    {
        public LibDbContext(DbContextOptions<LibDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}