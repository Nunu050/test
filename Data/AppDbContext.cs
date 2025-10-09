using Microsoft.EntityFrameworkCore;
using PutApi.Models;

namespace PutApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

    }
}
