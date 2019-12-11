using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Migrate
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet ef migrations add 'add address' -p Migrate  
            // dotnet ef database update '20191208080149_age' -p Migrate   
            var context = new TestContext();
            var students = context.Students.ToList();
        }
    }

    public class TestContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;Password=P@ssw0rd;Initial Catalog=Test");
        }
    }

    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }
    }
}