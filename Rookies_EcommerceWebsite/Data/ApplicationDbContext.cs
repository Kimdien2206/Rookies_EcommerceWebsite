using Rookies_EcommerceWebsite.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceVariant> InvoiceVariants { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>()
                .Property(e => e.Images)
                .HasConversion(
                    t => string.Join(';', t),
                    t => t.Split(';', StringSplitOptions.RemoveEmptyEntries));
            builder.Entity<Product>()
                .HasQueryFilter(x => x.IsDeleted == false);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole()
                {
                    Name = "Admin"
                },
                new IdentityRole()
                {
                    Name = "User"
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(s => FileLogger.Log(s));
            
        }
    }
}
