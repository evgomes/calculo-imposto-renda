using IncomeTax.API.Domain.Models;
using IncomeTax.API.Services.Calculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IncomeTax.API.Tests.Services.Calculations
{
    /// <summary>
    /// Testes da estratégia de desconto por dependentes.
    /// </summary>
    [TestClass]
    public class DependentsTaxpayerDiscountStrategyTests
    {
        public DependentsTaxpayerDiscountStrategy _dependentsTaxpayerDiscountStrategy = new DependentsTaxpayerDiscountStrategy();

        [TestMethod]
        public void Should_Return_Five_Percent_Discount_For_Taxpayer_That_Has_Two_Dependents()
        {
            var basicWage = new BasicWage { Value = 1000M };
            var taxpayer = new Taxpayer { NumberOfDependents = 2 };

            var expectedDiscountValue = ((basicWage.Value * 5) / 100) * 2; // R$ 100 reais no total

            var result = _dependentsTaxpayerDiscountStrategy.CalculateDiscountFor(taxpayer, basicWage);

            Assert.AreEqual(expectedDiscountValue, result);
            Assert.AreEqual(100, result);
        }
    }
}