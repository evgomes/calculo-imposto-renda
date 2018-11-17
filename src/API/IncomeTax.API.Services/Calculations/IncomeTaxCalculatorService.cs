using System;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services;
using IncomeTax.API.Domain.Services.Calculations;

namespace IncomeTax.API.Services.Calculations
{
    public class IncomeTaxCalculatorService : IIncomeTaxCalculatorService
    {
        /// Calcula o valor de desconto no imposto para um contribuinte do importo de renda, levando em conta o salário mínimo atual. 
        /// </summary>
        /// <param name="taxpayer">Contribuinte.</param>
        /// <param name="basicWage">Salário mínimo atual.</param>
        /// <returns>Valor de desconto.</returns>
        public decimal CalculateIncomeTaxRateDiscountFor(Taxpayer taxpayer, BasicWage basicWage)
        {
            if (taxpayer == null || basicWage == null)
                return 0;

            ITaxpayerDiscountStrategy discountStrategy = TaxpayerDiscountStrategyFactory.GetDiscountStrategyFor(taxpayer);
            decimal totalDiscount = discountStrategy.CalculateDiscountFor(taxpayer, basicWage);

            return totalDiscount;
        }

        /// <summary>
        /// Calcula a porcentagem da alíquota do imposto de renda para um contribuinte, levando em conta o salário mínimo atual e eventual
        /// desconto nas taxas do imposto.
        /// </summary>
        /// <param name="taxpayer">Contribuinte.</param>
        /// <param name="basicWage">Dados do salário mínimo.</param>
        /// <param name="discount">Desconto para o contribuinte.</param>
        /// <returns>Porcentagem.</returns>

        public decimal CalculateIncomeTaxRatePercentageFor(Taxpayer taxpayer, BasicWage basicWage, decimal discount)
        {
            // Primeiro calcula a renda líquida para saber a alíquota do imposto.
            // Renda líquida = salário bruto mensal - desconto
            decimal netIncome = taxpayer.MonthlyGrossIncome - discount;

            // Agora calcula a quantidade de salários mínimos que o contribuinte recebe, da seguinte forma:
            // Qtd. Salários = renda líqudia / valor do salário mínimo.
            var basicWageQuantity = netIncome / basicWage.Value;

            // Dependento da quantidade de salários, retorna a porcentagem da alíquota:
            return CalculateIncomeTaxRatePercentageFor(basicWageQuantity);
        }

        /// <summary>
        /// Calcula o total de imposto de renda a ser pago, considerando o valor bruto mensal do salário e a porcentagem da alíquota 
        /// do imposto de renda, bem como eventuais descontos.
        /// </summary>
        /// <param name="monthlyGrowthRate">Salário bruto mensal.</param>
        /// <param name="taxRatePercentage">Porcentagem da alíquota do imposto.</param>
        /// <returns>Valor total a ser pago.</returns>
        public decimal CalculateTotalIncomeTax(decimal monthlyGrowthRate, decimal taxRatePercentage, decimal discount)
        {
            return ((monthlyGrowthRate * taxRatePercentage) / 100) - discount;
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