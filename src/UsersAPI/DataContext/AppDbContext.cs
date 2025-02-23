using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.DataContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            this.Database.Migrate();
        }

    }
}
