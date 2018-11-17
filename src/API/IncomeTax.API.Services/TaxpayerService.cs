using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Domain.Services;
using IncomeTax.API.Domain.Services.Calculations;
using IncomeTax.API.Domain.Services.Communication.Taxpayers;

namespace IncomeTax.API.Services
{
    public class TaxpayerService : ITaxpayerService
    {
        private readonly ITaxpayerRepository _taxpayerRepository;
        private readonly IBasicWageService _basicWageService;
        private readonly IIncomeTaxCalculatorService _incomeTaxCalculatorService;

        public TaxpayerService(ITaxpayerRepository taxpayerRepository, IBasicWageService basicWageService, IIncomeTaxCalculatorService incomeTaxCalculatorService)
        {
            _taxpayerRepository = taxpayerRepository;
            _basicWageService = basicWageService;
            _incomeTaxCalculatorService = incomeTaxCalculatorService;
        }

        public async Task<IEnumerable<Taxpayer>> ListAsync()
        {
            // Primeiro lista os dados de salário mínimo e dos contribuintes
            var basicWage = await _basicWageService.GetBasicWageDataAsync();
            var taxpayers = await _taxpayerRepository.ListAsync();

            decimal discountValue = 0;

            // Agora calcula e preenche os dados de imposto de cada contribuinte.
            foreach(var taxpayer in taxpayers)
            {
                discountValue = _incomeTaxCalculatorService.CalculateIncomeTaxRateDiscountFor(taxpayer, basicWage);
                taxpayer.IncomeTaxRatePercentage = _incomeTaxCalculatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discountValue);
                
                taxpayer.TotalIncomeTax = _incomeTaxCalculatorService.CalculateTotalIncomeTax(monthlyGrowthRate: taxpayer.MonthlyGrossIncome, 
                                                                                              taxRatePercentage: taxpayer.IncomeTaxRatePercentage, 
                                                                                              discount: discountValue);
            }

            // Agora ordena por ordem crescente do valor total de imposto a pagar e pelo nome de cada contribuinte.
            taxpayers = taxpayers.OrderBy(t => t.TotalIncomeTax).ThenBy(t => t.Name).ToList();

            return taxpayers;
        }

        public async Task<Taxpayer> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TaxpayerResponse> CreateAsync(Taxpayer taxpayer)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TaxpayerResponse> UpdateAsync(int id, Taxpayer taxpayer)
        {
            throw new System.NotImplementedException();
        }

        public async Task<TaxpayerResponse> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}