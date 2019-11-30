using System;
using System.Linq;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MultiContexts
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SouthwindDbContext();
            context.Database.EnsureCreated();
            
            Console.WriteLine(context.Orders.Count());
        }
    }

    public class SouthwindDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=P@ssw0rd;Initial Catalog=Southwind");
        }
    }

    public class Order
    {
        public int Id { get; set; }

        public string OrderName { get; set; }

        public decimal Amount { get; set; }
    }
}