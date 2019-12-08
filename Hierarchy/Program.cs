using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hierarchy
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyContext = new CompanyContext();
            companyContext.Database.EnsureCreated();
            companyContext.Employees.Add(new Employee {Name = "Test1"});
            companyContext.Managers.Add(new Manager() {Name = "Tim", Title = "QQ"});
            companyContext.SaveChanges();

            Console.Read();
        }
    }

    public class CompanyContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Manager> Managers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=P@ssw0rd;Initial Catalog=Company");
        }
    }

    public class Manager : Employee
    {
        public string Title { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}