using Rookies_EcommerceWebsite.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceVariant> InvoiceVariants { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public ApplicationDbContext() { }

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
            builder.Entity<Category>()
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
