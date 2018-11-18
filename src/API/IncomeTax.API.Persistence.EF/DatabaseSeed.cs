using System.Collections.Generic;
using System.Linq;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Persistence.EF.Contexts;

namespace IncomeTax.API.Persistence.EF
{
    /// <summary>
    /// O EF Core suporta seed de dados através do método "OnModelCreating", porém prefiro manter essa funcionalidade separada para permitir utilizar
    /// injeção de dependência de serviços nessa classe caso necessário.
    /// 
    /// Exemplo de API onde utilizei essa funcionalidade: https://github.com/evgomes/jwt-api/blob/master/src/Persistence/DatabaseSeed.cs
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

            if(context.Taxpayer.Count() == 0)
            {
                var taxpayers = new List<Taxpayer>
                {
                    new Taxpayer
                    {
                        Name = "Evandro Gayer Gomes",
                        CPF = 12345678911,
                        MonthlyGrossIncome = 6000,
                        NumberOfDependents = 0,
                    },

                    new Taxpayer
                    {
                        Name = "Todo User 2",
                        CPF = 12332112332,
                        MonthlyGrossIncome = 3500,
                        NumberOfDependents = 0,
                    },


                    new Taxpayer
                    {
                        Name = "Todo User 1",
                        CPF = 11122233311,
                        MonthlyGrossIncome = 7600,
                        NumberOfDependents = 2,
                    },

                    new Taxpayer
                    {
                        Name = "Todo User 3",
                        CPF = 99988877766,
                        MonthlyGrossIncome = 7600,
                        NumberOfDependents = 0,
                    },
                };

                foreach(var taxpayer in taxpayers)
                {
                    context.Taxpayer.Add(taxpayer);
                }

                context.SaveChanges();
            }
        }
    }
}