using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Services.Calculations
{
    /// <summary>
    /// Serviço de cálculo das taxas do imposto de renda para contribuintes.
    /// </summary>
    public interface IIncomeTaxCalculatorService
    {
        /// <summary>
        /// Calcula a porcentagem da alíquota do imposto de renda para um contribuinte, levando em conta o salário mínimo atual.
        /// </summary>
        /// <param name="taxpayer">Contribuinte</param>
        /// <param name="basicWage">Dados do salário mínimo</param>
        /// <returns>Porcentagem.</returns>
         decimal CalculateIncomeTaxRatePercentageFor(Taxpayer taxpayer, BasicWage basicWage);

         /// <summary>
         /// Calcula o total de imposto de renda a ser pago por um contribuinte, levando em conta o salário mínimo atual.
         /// </summary>
         /// <param name="taxpayer"></param>
         /// <param name="basicWage">Dados do salário mínimo</param>
         /// <returns>Valor total a ser pago.</returns>
         decimal CalculateTotalIncomeTaxFor(Taxpayer taxpayer, BasicWage basicWage);
    }
}