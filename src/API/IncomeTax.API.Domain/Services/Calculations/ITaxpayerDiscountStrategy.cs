using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Services.Calculations
{
    /// <summary>
    /// Estratégia de desconto na alíquota do imposto de renda para contribuintes.
    /// </summary>
    public interface ITaxpayerDiscountStrategy
    {
        /// <summary>
        /// Calcula o desconto na alíquota para um contribuinte de acordo com o salário mínimo atual.
        /// </summary>
        /// <param name="taxpayer">Contribuinte.</param>
        /// <param name="basicWage">Dados do salário mínimo.</param>
        /// <returns>Desconto calculado para o contribuinte.</returns>
         decimal CalculateDiscountFor(Taxpayer taxpayer, BasicWage basicWage);
    }
}