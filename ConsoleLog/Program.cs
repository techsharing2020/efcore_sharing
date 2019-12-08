using System;
using System.Linq;
using Data.Contexts;

namespace ConsoleLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new NorthwindContext();
            var orders = context.Orders.ToList();

            Console.Read();
        }
    }
}