using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Services.Calculations
{
    /// <summary>
    /// Serviço de cálculo das taxas do imposto de renda para contribuintes.
    /// </summary>
    public interface IIncomeTaxCalculatorService
    {
        /// <summary>
        /// Calcula o valor de desconto no imposto para um contribuinte do importo de renda, levando em conta o salário mínimo atual. 
        /// </summary>
        /// <param name="taxpayer">Contribuinte.</param>
        /// <param name="basicWage">Salário mínimo atual.</param>
        /// <returns>Valor de desconto.</returns>
        decimal CalculateIncomeTaxRateDiscountFor(Taxpayer taxpayer, BasicWage basicWage);

        /// <summary>
        /// Calcula a porcentagem da alíquota do imposto de renda para um contribuinte, levando em conta o salário mínimo atual e eventual
        /// desconto nas taxas do imposto.
        /// </summary>
        /// <param name="taxpayer">Contribuinte.</param>
        /// <param name="basicWage">Dados do salário mínimo.</param>
        /// <param name="discount">Desconto para o contribuinte.</param>
        /// <returns>Porcentagem.</returns>
         decimal CalculateIncomeTaxRatePercentageFor(Taxpayer taxpayer, BasicWage basicWage, decimal discount);

         /// <summary>
         /// Calcula o total de imposto de renda a ser pago, considerando o valor bruto mensal do salário e a porcentagem da alíquota 
         /// do imposto de renda, bem como eventuais descontos.
         /// </summary>
         /// <param name="monthlyGrowthRate">Salário bruto mensal.</param>
         /// <param name="taxRatePercentage">Porcentagem da alíquota do imposto.</param>
         /// <param name="discount">Valor de desconto.</param>
         /// <returns>Valor total a ser pago.</returns>
         decimal CalculateTotalIncomeTax(decimal monthlyGrowthRate, decimal taxRatePercentage, decimal discount);
    }
}