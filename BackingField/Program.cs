using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BackingField
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SouthwindDbContext();
            var order = context.Orders.FirstOrDefault();

            Console.Read();
        }
    }
    
    public class SouthwindDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=P@ssw0rd;Initial Catalog=Southwind");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().Property(o => o.OrderName).HasField("_orderName");
        }
    }
    
    public class Order
    {
        public int Id { get; set; }

        private string _orderName;

        public string OrderName => _orderName;

        public decimal Amount { get; set; }
    }
}