using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShadowProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new NorthwindContext();
            var orders = context.Orders.ToList();
            var shipNames = context.Orders.Select(o => EF.Property<string>(o, "ShipName")).ToList();
            shipNames.ForEach(Console.WriteLine);
        }
    }

    public class NorthwindContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=P@ssw0rd;Initial Catalog=Northwind");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(typeof(string), "ShipName");
        }
    }

    public class Order
    {
        public int OrderID { get; set; }
    }
}