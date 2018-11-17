using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Calculations;

namespace IncomeTax.API.Services.Calculations
{
    /// <summary>
    /// Estratégia que não aplica desconto no valor da alíquota para um contribuinte.
    /// Utilizado quando o contribuinte não tem dependentes.
    /// </summary>
    public class NoTaxpayerDiscountStrategy : ITaxpayerDiscountStrategy
    {
        public decimal CalculateDiscountFor(Taxpayer taxpayer, BasicWage basicWage)
        {
            return 0;
        }
    }
}