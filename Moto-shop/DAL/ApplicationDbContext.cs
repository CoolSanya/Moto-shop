using Microsoft.EntityFrameworkCore;
using Moto_shop.Models;

namespace Moto_shop.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u => { u.HasIndex(e => e.Email).IsUnique(); });
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
