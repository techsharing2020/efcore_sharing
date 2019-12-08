using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ShoppingMallContext();
            context.Database.EnsureCreated();
            context.Products.Add(new Product
            {
                ProductName = "Iphone",
                Type = ProductType.CellPhone
            });

            context.SaveChanges();

            Console.Read();
        }
    }

    public class ShoppingMallContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=P@ssw0rd;Initial Catalog=ShoppingMall");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Type)
                .HasConversion(p => (int) p, 
                    v => (ProductType) v);
        }
    }
    
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public ProductType Type { get; set; }
    }

    public enum ProductType
    {
       Computer = 1,
       
       CellPhone,
    }
}