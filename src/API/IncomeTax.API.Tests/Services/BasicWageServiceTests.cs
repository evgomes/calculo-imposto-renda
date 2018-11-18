using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Domain.Services;
using IncomeTax.API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace IncomeTax.API.Tests.Services
{
    /// <summary>
    /// Testes do serviço de dados do salário mínimo.
    /// </summary>
    [TestClass]
    public class BasicWageServiceTests
    {
        private IBasicWageService _basicWageService;

        public BasicWageServiceTests()
        {
            var repositoryMock = new Mock<IBasicWageRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();

            repositoryMock.Setup(r => r.GetBasicWageDataAsync()).ReturnsAsync(new BasicWage { Id = 1, Value = 1000 });
            repositoryMock.Setup(r => r.RecordBasicWageDataAsync(It.IsAny<BasicWage>())).Returns<BasicWage>((basicWage) => Task.FromResult(basicWage));

            unitOfWorkMock.Setup(u => u.CompleteAsync()).Returns(Task.CompletedTask);

            _basicWageService = new BasicWageService(repositoryMock.Object, unitOfWorkMock.Object);
        }

        [TestMethod]
        public async Task Should_Return_Basic_Wage_Data()
        {
            var basicWage = await _basicWageService.GetBasicWageDataAsync();

            Assert.IsNotNull(basicWage);
            Assert.AreEqual(1000, basicWage.Value);
        }

        [TestMethod]
        public async Task Should_Record_Basic_Wage_Data()
        {
            var basicWage = new BasicWage { Id = 1, Value = 2000 };
            var result = await _basicWageService.RecordBasicWageDataAsync(basicWage);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(basicWage.Value, result.BasicWage.Value);
        }
    }
}