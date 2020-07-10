using Microsoft.EntityFrameworkCore;

namespace LibManagementApi.Models
{
    public class LibContext : DbContext
    {
        public LibContext(DbContextOptions<LibContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}