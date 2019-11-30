using System;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GenerateDbScript
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new NorthwindContext();
            var createScript = context.Database.GenerateCreateScript();
            
            Console.WriteLine(createScript);
        }
    }
}