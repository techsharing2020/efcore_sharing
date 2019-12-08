using System;
using System.Linq;

namespace Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            var northwindContext = new Data.Contexts.NorthwindContext();
            var customerses = northwindContext.Customers.ToList();
            Console.WriteLine(customerses.Count);
            Console.Read();
        }
    }

    
}