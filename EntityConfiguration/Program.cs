using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new NorthwindContext();
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
            // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetEntryAssembly());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(typeof(string), "ShipName"); 
        }
    }

    public class Order
    {
        public int OrderID { get; set; }
    }
}