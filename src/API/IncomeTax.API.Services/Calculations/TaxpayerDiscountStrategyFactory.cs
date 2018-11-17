using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Calculations;

namespace IncomeTax.API.Services.Calculations
{
    /// <summary>
    /// Retorna a estratégia de descontos a sem empregada para um contribuinte.
    /// </summary>
    public static class TaxpayerDiscountStrategyFactory
    {
        public static ITaxpayerDiscountStrategy GetDiscountStrategyFor(Taxpayer taxpayer)
        {
            // Caso o contribuinte tenha dependentes, tem direito a um desconto de 5% do valor do salário mínimo para cada dependente.
            if (taxpayer.NumberOfDependents > 0)
            {
                return new DependentsTaxpayerDiscountStrategy();
            }

            // Caso o contribuinte não tenha dependentes, não tem direito a desconto.
            return new NoTaxpayerDiscountStrategy();
        }
    }
}