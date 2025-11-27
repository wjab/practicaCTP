using Inyection_dependency_example.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Inyection_dependency_example.Implementation
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BookDB> BookDB { get; set; }

        public DbSet<CategoryDB> CategoryDB { get; set; }

        public DbSet<BookStoreDB> BookStoreDB { get; set; }

        public DbSet<ProductDB> ProductDB { get; set; }

        public DbSet<BookShelfDB> BookShelfDB { get; set; }

        public DbSet<OrderDB> Orders { get; set; }

        public DbSet<OrderItemDB> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships if needed

            base.OnModelCreating(modelBuilder);
        }


    }
}
