using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Calculations;
using IncomeTax.API.Services.Calculations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IncomeTax.API.Tests.Services.Calculations
{
    /// <summary>
    /// Testes do serviço de cálculos de taxas referentes ao imposto de renda.
    /// </summary>
    [TestClass]
    public class IncomeTaxCalculatorServiceTests
    {
        private IIncomeTaxCalculatorService _incomeTaxCalulcatorService = new IncomeTaxCalculatorService();

        [TestMethod]
        public void Should_Calculate_Income_Tax_Rate_Discount_For_Taxpayer_Without_Dependents()
        {
            var taxpayer = new Taxpayer { NumberOfDependents = 0 };
            var basicWage = new BasicWage { Value = 1000 };

            var discount = _incomeTaxCalulcatorService.CalculateIncomeTaxRateDiscountFor(taxpayer, basicWage);

            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        public void Should_Calculate_Income_Tax_Rate_Discount_For_Taxpayer_With_Dependents()
        {
            var taxpayer = new Taxpayer { NumberOfDependents = 1 };
            var basicWage = new BasicWage { Value = 1000 };

            var discount = _incomeTaxCalulcatorService.CalculateIncomeTaxRateDiscountFor(taxpayer, basicWage);

            Assert.AreEqual(50, discount);
        }

        [TestMethod]
        public void Should_Return_Zero_As_Discount_For_Null_Taxpayer_Or_Basic_Wage()
        {
            Taxpayer taxpayer = null;
            BasicWage basicWage = null;

            var discount = _incomeTaxCalulcatorService.CalculateIncomeTaxRateDiscountFor(taxpayer, basicWage);

            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        public void Should_Return_0_As_Percentage_For_Taxpayer_That_Receives_Up_To_2_Basic_Wages()
        {
            var taxpayer = new Taxpayer { MonthlyGrossIncome = 1000 };
            var basicWage = new BasicWage { Value = 1000 };

            var percentage = _incomeTaxCalulcatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discount : 0);

            Assert.AreEqual(0, percentage);
        }

        [TestMethod]
        public void Should_Return_7_5_As_Percentage_For_Taxpayer_That_Receives_Up_To_4_Basic_Wages()
        {
            var taxpayer = new Taxpayer { MonthlyGrossIncome = 3000 };
            var basicWage = new BasicWage { Value = 1000 };

            var percentage = _incomeTaxCalulcatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discount : 0);

            Assert.AreEqual(7.5M, percentage);
        }

        [TestMethod]
        public void Should_Return_15_As_Percentage_For_Taxpayer_That_Receives_Up_To_5_Basic_Wages()
        {
            var taxpayer = new Taxpayer { MonthlyGrossIncome = 5000 };
            var basicWage = new BasicWage { Value = 1000 };

            var percentage = _incomeTaxCalulcatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discount : 0);

            Assert.AreEqual(15M, percentage);
        }

        [TestMethod]
        public void Should_Return_22_5_As_Percentage_For_Taxpayer_That_Receives_Up_To_7_Basic_Wages()
        {
            var taxpayer = new Taxpayer { MonthlyGrossIncome = 7000 };
            var basicWage = new BasicWage { Value = 1000 };

            var percentage = _incomeTaxCalulcatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discount : 0);

            Assert.AreEqual(22.5M, percentage);
        }

        [TestMethod]
        public void Should_Return_27_5_As_Percentage_For_Taxpayer_That_Receives_Up_To_7_Basic_Wages()
        {
            var taxpayer = new Taxpayer { MonthlyGrossIncome = 10000 };
            var basicWage = new BasicWage { Value = 1000 };

            var percentage = _incomeTaxCalulcatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discount : 0);

            Assert.AreEqual(27.5M, percentage);
        }

        [TestMethod]
        public void Should_Return_0_As_Percentage_For_Taxpayer_That_Receives_Up_To_4_Basic_Wages_But_Has_Enough_Discount()
        {
            var taxpayer = new Taxpayer { MonthlyGrossIncome = 2050 };
            var basicWage = new BasicWage { Value = 1000 };

            var percentage = _incomeTaxCalulcatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discount : 50);

            Assert.AreEqual(0, percentage);
        }

        [TestMethod]
        public void Should_Calculate_Total_Income_Tax_To_Pay_Without_Discount()
        {
            decimal result = _incomeTaxCalulcatorService.CalculateTotalIncomeTax(
                monthlyGrowthRate: 3000M,
                taxRatePercentage: 7.5M,
                discount: 0);

            Assert.AreEqual(225, result);
        }

        [TestMethod]
        public void Should_Calculate_Total_Income_Tax_To_Pay_With_Discount()
        {
            decimal result = _incomeTaxCalulcatorService.CalculateTotalIncomeTax(
                monthlyGrowthRate: 3000M,
                taxRatePercentage: 7.5M,
                discount: 100);

            Assert.AreEqual(125, result);
        }
    }
}