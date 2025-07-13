using Microsoft.EntityFrameworkCore;

namespace Task1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Books> Books { get; set; } 
    }
}
