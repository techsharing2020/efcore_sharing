using System;
using System.IO;
using System.Linq;
using Data.Contexts;
using Microsoft.Extensions.Configuration;

namespace ConfigureConnectionString
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var context = new NorthwindContext(config);
            var orders = context.Orders.ToList();
            orders.ForEach(o => Console.WriteLine(o.OrderDate));
        }
    }
}