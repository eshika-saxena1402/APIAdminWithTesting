using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApperalStoreAPI.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(c => c.Category)
                .WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
              .HasOne(v=>v.Vendor)
              .WithMany(p => p.Products)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
             .HasOne(b=>b.Brand)
             .WithMany(p => p.Products)
             .OnDelete(DeleteBehavior.Cascade);   

            modelBuilder.Entity<Order>()
            .HasOne(c=>c.Customer)
            .WithMany(o => o.Orders)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderProduct>(build =>
            {
                build.HasKey(t => new { t.OrderId, t.ProductId });
            });
      
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandName)
                .HasColumnName("BrandName")
                .HasMaxLength(8)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName)
                .HasColumnName("CategoryName")
                .HasMaxLength(10)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerName)
                .HasColumnName("CustomerName")
                .HasMaxLength(6)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderAmount)
                .HasColumnName("OrderAmount")
                .HasMaxLength(6)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName)
                .HasColumnName("ProductName")
                .HasMaxLength(6)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.VendorName)
                .HasColumnName("VendorName")
                .HasMaxLength(6)
                .IsUnicode(false);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
 }

