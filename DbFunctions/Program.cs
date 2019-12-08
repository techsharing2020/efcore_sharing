using System;
using System.Linq;
using Data.Contexts;

namespace DbFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new NorthwindContext();
            var names = context.Customers.Select(c=> context.LEFT(c.ContactName, 5)).ToList();
            names.ForEach(Console.WriteLine);
            var result = context.Orders
                .Select(o => context.MySum(o.OrderId, o.EmployeeId.GetValueOrDefault()))
                .ToList();
            result.ForEach(Console.WriteLine);
        }
    }
}