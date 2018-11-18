using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Domain.Services;
using IncomeTax.API.Domain.Services.Calculations;
using IncomeTax.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IncomeTax.API.Tests.Services
{
    /// <summary>
    /// Testes do serviço de contribuintes. 
    /// </summary>
    [TestClass]
    public class TaxpayerServiceTests
    {
        private ITaxpayerService _taxpayerService;

        public TaxpayerServiceTests()
        {
            var taxpayerRepositoryMock = new Mock<ITaxpayerRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var basicWageServiceMock = new Mock<IBasicWageService>();
            var incomeTaxCalculatorServiceMock = new Mock<IIncomeTaxCalculatorService>();

            taxpayerRepositoryMock.Setup(b => b.ListAsync()).ReturnsAsync(new List<Taxpayer>()
            {
                new Taxpayer { Id = 1, Name = "Test 1", CPF = 11122233344, MonthlyGrossIncome = 2000 },
                new Taxpayer { Id = 2, Name = "Test 2", CPF = 11122233355, MonthlyGrossIncome = 3000 },
            });

            taxpayerRepositoryMock.Setup(b => b.GetByIdAsync(1)).ReturnsAsync(new Taxpayer { Id = 1, Name = "Nome", NumberOfDependents = 0, MonthlyGrossIncome = 2000, CPF = 22222222222 });
            taxpayerRepositoryMock.Setup(b => b.GetByIdAsync(2)).Returns(Task.FromResult<Taxpayer>(null));
            taxpayerRepositoryMock.Setup(b => b.GetByCPFAsync(11111111111)).ReturnsAsync(new Taxpayer { Id = 1, NumberOfDependents = 0, MonthlyGrossIncome = 2000, CPF = 11111111111 });
            taxpayerRepositoryMock.Setup(b => b.GetByCPFAsync(22222222222)).Returns(Task.FromResult<Taxpayer>(null));

            unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);

            basicWageServiceMock.Setup(b => b.GetBasicWageDataAsync()).ReturnsAsync(new BasicWage { Id = 1, Value = 1000 });

            incomeTaxCalculatorServiceMock.Setup(i => i.CalculateIncomeTaxRateDiscountFor(It.IsAny<Taxpayer>(), It.IsAny<BasicWage>()))
                .Returns(0);

            incomeTaxCalculatorServiceMock.Setup(i => i.CalculateIncomeTaxRatePercentageFor(It.IsAny<Taxpayer>(), It.IsAny<BasicWage>(), It.IsAny<decimal>()))
                .Returns(5);

            incomeTaxCalculatorServiceMock.Setup(i => i.CalculateTotalIncomeTax(It.IsAny<decimal>(), It.IsAny<decimal>(), It.IsAny<decimal>()))
                .Returns<decimal, decimal, decimal>((monthlyGrowthRate, taxRatePercentage, discount) => ((monthlyGrowthRate * taxRatePercentage) / 100) - discount);

            _taxpayerService = new TaxpayerService(
                taxpayerRepositoryMock.Object,
                unitOfWorkMock.Object,
                basicWageServiceMock.Object,
                incomeTaxCalculatorServiceMock.Object);
        }

        [TestMethod]
        public async Task Shold_List_All_Taxpayers_Populating_All_Fields_By_Total_Income_Tax_And_Name_In_Ascending_Order()
        {
            var taxpayers = await _taxpayerService.ListAsync();
            var list = taxpayers.ToList();

            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0].IncomeTaxRatePercentage != 0);
            Assert.IsTrue(list[0].TotalIncomeTax < list[1].TotalIncomeTax);
        }

        [TestMethod]
        public async Task Should_Return_Existing_Taxpayer_From_Repository()
        {
            var taxpayer = await _taxpayerService.GetByIdAsync(1);

            Assert.IsNotNull(taxpayer);
            Assert.AreEqual(1, taxpayer.Id);
        }

        [TestMethod]
        public async Task Should_Not_Return_Non_Existing_Taxpayer_From_Repository()
        {
            var taxpayer = await _taxpayerService.GetByIdAsync(2);

            Assert.IsNull(taxpayer);
        }

        [TestMethod]
        public async Task Should_Not_Create_Taxpayer_When_CPF_Is_Already_In_Use()
        {
            var taxpayer = new Taxpayer { Id = 1, NumberOfDependents = 0, MonthlyGrossIncome = 2000, CPF = 11111111111 };

            var result = await _taxpayerService.CreateAsync(taxpayer);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Já existe um usuário na base com o CPF especificado.", result.Message);
        }

        [TestMethod]
        public async Task Should_Create_Taxpayer_When_CPF_Is_Not_In_Use_And_Data_Is_Valid()
        {
            var taxpayer = new Taxpayer { NumberOfDependents = 0, MonthlyGrossIncome = 2000, CPF = 22222222222 };

            var result = await _taxpayerService.CreateAsync(taxpayer);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(taxpayer.CPF, result.Taxpayer.CPF);
        }

        [TestMethod]
        public async Task Should_Not_Update_Taxpayer_When_They_Are_Not_In_The_Database()
        {
            var taxpayer = new Taxpayer { Name = "Updated", NumberOfDependents = 0, MonthlyGrossIncome = 2000, CPF = 22222222222 };

            var result = await _taxpayerService.UpdateAsync(2, taxpayer);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Contribuinte não encontrado na base de dados para atualização.", result.Message);
        }

        [TestMethod]
        public async Task Should_Update_Taxpayer_When_They_Are_In_The_Database_And_Valid_Data_Is_Provided()
        {
            var taxpayer = new Taxpayer { Name = "Updated", NumberOfDependents = 0, MonthlyGrossIncome = 2000, CPF = 22222222222 };

            var result = await _taxpayerService.UpdateAsync(1, taxpayer);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(taxpayer.Name, result.Taxpayer.Name);
        }

        [TestMethod]
        public async Task Should_Not_Delete_Taxpayer_When_They_Are_Not_In_The_Database()
        {
            var result = await _taxpayerService.DeleteAsync(2);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Contribuinte não encontrado na base de dados para exclusão.", result.Message);
        }

        [TestMethod]
        public async Task Should_Delete_Taxpayer_When_They_Are_In_The_Database()
        {
            var result = await _taxpayerService.DeleteAsync(1);

            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Taxpayer);
            Assert.AreEqual(1, result.Taxpayer.Id);
        }
    }
}