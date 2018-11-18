using IncomeTax.API.Domain.Models;
using IncomeTax.API.Services.Calculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IncomeTax.API.Tests.Services.Calculations
{
    /// <summary>
    /// Testes da estratégia de cálculo nulo de desconto para contribuinte.
    /// </summary>
    [TestClass]
    public class NoTaxpayerDiscountStrategyTests
    {
        private NoTaxpayerDiscountStrategy _noTaxpayerDiscountStrategy = new NoTaxpayerDiscountStrategy();

        [TestMethod]
        public void Should_Not_Return_Discount_For_Taxpayer_That_Has_Dependents()
        {
            var taxpayer = new Taxpayer
            {
                MonthlyGrossIncome = 5000,
                NumberOfDependents = 5
            };

            var basicWage = new BasicWage
            {
                Value = 954M
            };

            var result = _noTaxpayerDiscountStrategy.CalculateDiscountFor(taxpayer, basicWage);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Should_Not_Return_Discount_For_Taxpayer_That_Does_Not_Have_Dependents()
        {
            var taxpayer = new Taxpayer
            {
                MonthlyGrossIncome = 5000,
                NumberOfDependents = 0
            };

            var basicWage = new BasicWage
            {
                Value = 954M
            };

            var result = _noTaxpayerDiscountStrategy.CalculateDiscountFor(taxpayer, basicWage);
            Assert.AreEqual(0, result);
        }
    }
}