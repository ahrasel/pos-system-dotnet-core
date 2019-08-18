using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PosSustemUIU.Models;

namespace PosSustemUIU.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating (builder);

            builder.Entity<ProductCategory> ()
                .HasIndex (u => u.Name)
                .IsUnique ();

            builder.Entity<ProductCategory> ()
                .HasOne (u => u.ApplicationUser)
                .WithMany (c => c.ProductCategories)
                .OnDelete (DeleteBehavior.Cascade);
            //product

            builder.Entity<Product> ()
                .HasIndex (p => new { p.Name, p.Code })
                .IsUnique ();

            // builder.Entity<Product> ()
            //     .HasOne (u => u.ApplicationUser)
            //     .WithMany (c => c.Products)
            //     .OnDelete (DeleteBehavior.Cascade);

            builder.Entity<Product> ()
                .HasOne (u => u.ProductCategory)
                .WithMany (c => c.Products)
                .OnDelete (DeleteBehavior.Cascade);

            builder.Entity<Product> ()
                .HasOne (u => u.Supplier)
                .WithMany (c => c.Products)
                .OnDelete (DeleteBehavior.Cascade);

            builder.Entity<Product> ()
                .HasOne (u => u.Brand)
                .WithMany (c => c.Products)
                .OnDelete (DeleteBehavior.Cascade);

            //area
            builder.Entity<Area> ()
                .HasIndex (u => u.Name)
                .IsUnique ();

            //supplier
            builder.Entity<Supplier> ()
                .HasIndex (u => new { u.Name, u.Email, u.MainContact, u.Code })
                .IsUnique ();

            //brand
            builder.Entity<Brand> ()
                .HasIndex (u => new { u.Name, u.Code })
                .IsUnique ();

            //Customer
            builder.Entity<Customer> ()
                .HasIndex (p => new { p.Email, p.PhoneNumber })
                .IsUnique ();

            builder.Entity<Customer> ()
                .HasOne (u => u.Area)
                .WithMany (c => c.Customers)
                .OnDelete (DeleteBehavior.Cascade);

        }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}