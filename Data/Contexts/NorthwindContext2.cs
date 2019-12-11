using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Contexts
{
    public partial class NorthwindContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>().HasQueryFilter(c => c.CompanyName == "Alfreds Futterkiste");

            modelBuilder.HasDbFunction(GetType().GetMethod("LEFT"))
                .HasTranslation(args =>
                    SqlFunctionExpression.Create("Left",
                        args,
                        typeof(string),
                        new StringTypeMapping("nvarchar")));
        }
    }
}