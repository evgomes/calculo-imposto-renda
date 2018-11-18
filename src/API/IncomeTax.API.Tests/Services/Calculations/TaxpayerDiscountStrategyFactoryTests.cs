using IncomeTax.API.Domain.Models;
using IncomeTax.API.Services.Calculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IncomeTax.API.Tests.Services.Calculations
{
    /// <summary>
    /// Testes da factory de estratégias de desconto.
    /// </summary>
    [TestClass]
    public class TaxpayerDiscountStrategyFactoryTests
    {
        [TestMethod]
        public void Should_Return_Dependents_Discount_Strategy_When_Taxpayer_Has_Dependents()
        {
            var taxpayer = new Taxpayer { NumberOfDependents = 2 };
            var strategy = TaxpayerDiscountStrategyFactory.GetDiscountStrategyFor(taxpayer);

            Assert.IsInstanceOfType(strategy, typeof(DependentsTaxpayerDiscountStrategy));
        }

        [TestMethod]
        public void Should_Return_No_Discount_Strategy_When_Taxpayer_Does_Not_Have_Dependents()
        {
            var taxpayer = new Taxpayer { NumberOfDependents = 0 };
            var strategy = TaxpayerDiscountStrategyFactory.GetDiscountStrategyFor(taxpayer);

            Assert.IsInstanceOfType(strategy, typeof(NoTaxpayerDiscountStrategy));
        }
    }
}