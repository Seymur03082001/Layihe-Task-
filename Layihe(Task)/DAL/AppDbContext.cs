using Layihe_Task_.Models;
using Microsoft.EntityFrameworkCore;

namespace Layihe_Task_.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Post> Posts { get; set;}
        public DbSet<User> Users { get; set; }
    }
}
