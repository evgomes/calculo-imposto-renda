using System.Linq;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Persistence.EF.Contexts;

namespace IncomeTax.API.Persistence.EF
{
    /// <summary>
    /// EF Core already supports database seeding throught overriding "OnModelCreating", but I prefer to keep this functionality separated from
    /// the DbContext because I can use dependency injection in this class if needed.
    /// </summary>
    public static class DatabaseSeed
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if(context.BasicWage.Count() == 0)
            {
                var basicWage = new BasicWage { Value = 954M };

                context.BasicWage.Add(basicWage);
                context.SaveChanges();
            }
        }
    }
}