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

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<Variant>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<Category>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<Invoice>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
            builder.Entity<Cart>()
                .Property(e => e.Id)
                .HasDefaultValueSql("newsequentialid()");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(s => FileLogger.Log(s));
            
        }
    }
}
