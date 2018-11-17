using System;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Calculations;

namespace IncomeTax.API.Services.Calculations
{
    public class IncomeTaxCalculatorService : IIncomeTaxCalculatorService
    {
        /// <summary>
        /// Calcula a porcentagem da alíquota do imposto de renda para um contribuinte, levando em conta o salário mínimo atual.
        /// </summary>
        /// <param name="taxpayer">Contribuinte</param>
        /// <param name="basicWage">Dados do salário mínimo</param>
        /// <returns>Porcentagem.</returns>
        public decimal CalculateIncomeTaxRatePercentageFor(Taxpayer taxpayer, BasicWage basicWage)
        {
            // Primeiro verifica se um contribuinte tem direito a algum desconto para cálculo da renda líquida. 
            ITaxpayerDiscountStrategy discountStrategy = TaxpayerDiscountStrategyFactory.GetDiscountStrategyFor(taxpayer);
            decimal totalDiscount = discountStrategy.CalculateDiscountFor(taxpayer, basicWage);

            // Agora calcula a renda líquida para saber a alíquota do imposto.
            decimal netIncome = taxpayer.MonthlyGrossIncome - totalDiscount;

            // Agora calcula a quantidade de salários mínimos que o contribuinte recebe, da seguinte forma:
            // Qtd. Salários = renda líqudia / valor do salário mínimo.
            var basicWageQuantity = netIncome / basicWage.Value;

            // Dependento da quantidade de salários, retorna a porcentagem da alíquota:
            return CalculateIncomeTaxRatePercentageFor(basicWageQuantity);
        }

        /// <summary>
        /// Calcula o total de imposto de renda a ser pago por um contribuinte, levando em conta o salário mínimo atual.
        /// </summary>
        /// <param name="taxpayer"></param>
        /// <param name="basicWage">Dados do salário mínimo</param>
        /// <returns>Valor total a ser pago.</returns>
        public decimal CalculateTotalIncomeTaxFor(Taxpayer taxpayer, BasicWage basicWage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna a porcentagem da alíquota do imposto de renda de acordo com a quantidade de salários mínimos que o contribuinte recebe.
        /// </summary>
        /// <param name="basicWageQuantity">Quantidade de salários mínimos.</param>
        /// <returns>Alíquota.</returns>
        private decimal CalculateIncomeTaxRatePercentageFor(decimal basicWageQuantity)
        {
            if (basicWageQuantity <= 2)
            {
                return 0; // Isento
            }
            else if (basicWageQuantity > 2 && basicWageQuantity <= 4)
            {
                return 7.5M; // 7,5%
            }
            else if (basicWageQuantity > 4 && basicWageQuantity <= 5)
            {
                return 15M; // 15%;
            }
            else if (basicWageQuantity > 5 && basicWageQuantity <= 7)
            {
                return 22.5M; // 22,5%
            }
            else
            {
                return 27.5M; // 27,5 %
            }
        }
    }
}