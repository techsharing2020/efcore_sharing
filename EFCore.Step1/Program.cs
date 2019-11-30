using System;
using System.Linq;

namespace EFCore.Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            var northwind = new Northwind();
            var customerses = northwind.Customers.ToList();
            foreach (var customerse in customerses)
            {
                
            }

            Console.Read();
        }
    }
}