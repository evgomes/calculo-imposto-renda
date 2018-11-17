using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Calculations;

namespace IncomeTax.API.Services.Calculations
{
    /// <summary>
    /// Estratégia de cálculo de desconto para o imposto de renda que desconta 5% do valor do salário mínimo vezes a quantidade de 
    /// dependentes de um contribuinte. 
    /// </summary>
    public class DependentsTaxpayerDiscountStrategy : ITaxpayerDiscountStrategy
    {
        public decimal CalculateDiscountFor(Taxpayer taxpayer, BasicWage basicWage)
        {
            // Primeiro calcula o desconto de 5% em cima do salário mínimo
            var basicWageDiscountPercentage = (basicWage.Value * 5) / 100;

            // Então retorna o valor do desconto vezes a quantidade de dependentes
            // de um contribuinte.
            return taxpayer.NumberOfDependents * basicWageDiscountPercentage;
        }
    }
}