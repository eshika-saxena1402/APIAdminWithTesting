using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreApparelProjectAPI2.Models;

namespace coreApparelProjectAPI2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String ConString = "Data Source= TRD-502; Initial Catalog=OnlineApparelStoreDb; Integrated Security=True;";
            optionsBuilder.UseSqlServer(ConString);
        }
     

    }
}
