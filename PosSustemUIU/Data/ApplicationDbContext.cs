using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PosSustemUIU.Models;

namespace PosSustemUIU.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductCategory>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder.Entity<ProductCategory>()
                .HasOne(u => u.ApplicationUser)
                .WithMany(c => c.ProductCategories)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Product>()
                .HasIndex(p => new { p.Name, p.Code })
                .IsUnique();

            builder.Entity<Product>()
                .HasOne(u => u.ApplicationUser)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Product>()
                .HasOne(u => u.ProductCategory)
                .WithMany(c => c.Products)
                .OnDelete(DeleteBehavior.SetNull);

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
