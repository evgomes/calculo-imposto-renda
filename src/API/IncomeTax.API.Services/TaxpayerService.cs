using System;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasicWageService _basicWageService;
        private readonly IIncomeTaxCalculatorService _incomeTaxCalculatorService;

        public TaxpayerService(
            ITaxpayerRepository taxpayerRepository,
            IUnitOfWork unitOfWork,
            IBasicWageService basicWageService,
            IIncomeTaxCalculatorService incomeTaxCalculatorService)
        {
            _taxpayerRepository = taxpayerRepository;
            _unitOfWork = unitOfWork;
            _basicWageService = basicWageService;
            _incomeTaxCalculatorService = incomeTaxCalculatorService;
        }

        public async Task<IEnumerable<Taxpayer>> ListAsync()
        {
            // Primeiro lista os dados de salário mínimo e dos contribuintes
            var basicWage = await _basicWageService.GetBasicWageDataAsync();
            var taxpayers = await _taxpayerRepository.ListAsync();

            // Agora calcula e preenche os dados de imposto de cada contribuinte.
            foreach (var taxpayer in taxpayers)
            {
                PopulateTaxData(taxpayer, basicWage);
            }

            // Agora ordena por ordem crescente do valor total de imposto a pagar e pelo nome de cada contribuinte.
            taxpayers = taxpayers.OrderBy(t => t.TotalIncomeTax).ThenBy(t => t.Name).ToList();

            return taxpayers;
        }

        public async Task<Taxpayer> GetByIdAsync(int id)
        {
            var taxpayer = await _taxpayerRepository.GetByIdAsync(id);

            if (taxpayer != null)
            {
                var basicWage = await _basicWageService.GetBasicWageDataAsync();
                PopulateTaxData(taxpayer, basicWage);
            }

            return taxpayer;
        }

        public async Task<TaxpayerResponse> CreateAsync(Taxpayer taxpayer)
        {
            var existingTaxpayerByCPF = await _taxpayerRepository.GetByCPFAsync(taxpayer.CPF);

            if (existingTaxpayerByCPF != null)
            {
                return TaxpayerResponse.CreateFail("Já existe um usuário na base com o CPF especificado.");
            }

            try
            {
                await _taxpayerRepository.AddAsync(taxpayer);
                await _unitOfWork.CompleteAsync();

                var basicWage = await _basicWageService.GetBasicWageDataAsync();
                PopulateTaxData(taxpayer, basicWage);

                return TaxpayerResponse.CreateSuccess(taxpayer);
            }
            catch (Exception ex)
            {
                return TaxpayerResponse.CreateFail(ex.Message);
            }
        }

        public async Task<TaxpayerResponse> UpdateAsync(int id, Taxpayer taxpayer)
        {
            try
            {
                var existingTaxpayer = await _taxpayerRepository.GetByIdAsync(id);

                if (existingTaxpayer == null)
                {
                    return TaxpayerResponse.CreateFail("Contribuinte não encontrado na base de dados para atualização.");
                }

                existingTaxpayer.Name = taxpayer.Name;
                existingTaxpayer.CPF = taxpayer.CPF;
                existingTaxpayer.MonthlyGrossIncome = taxpayer.MonthlyGrossIncome;
                existingTaxpayer.NumberOfDependents = taxpayer.NumberOfDependents;

                _taxpayerRepository.Update(existingTaxpayer);
                await _unitOfWork.CompleteAsync();

                var basicWage = await _basicWageService.GetBasicWageDataAsync();
                PopulateTaxData(existingTaxpayer, basicWage);

                return TaxpayerResponse.CreateSuccess(existingTaxpayer);
            }
            catch (Exception ex)
            {
                return TaxpayerResponse.CreateFail(ex.Message);
            }
        }

        public async Task<TaxpayerResponse> DeleteAsync(int id)
        {
            var existingTaxpayer = await _taxpayerRepository.GetByIdAsync(id);

            if (existingTaxpayer == null)
            {
                return TaxpayerResponse.CreateFail("Contribuinte não encontrado na base de dados para exclusão.");
            }

            try
            {
                _taxpayerRepository.Delete(existingTaxpayer);
                await _unitOfWork.CompleteAsync();

                var basicWage = await _basicWageService.GetBasicWageDataAsync();
                PopulateTaxData(existingTaxpayer, basicWage);

                return TaxpayerResponse.CreateSuccess(existingTaxpayer);
            }
            catch (Exception ex)
            {
                return TaxpayerResponse.CreateFail(ex.Message);
            }
        }

        private void PopulateTaxData(Taxpayer taxpayer, BasicWage basicWage)
        {
            var discountValue = _incomeTaxCalculatorService.CalculateIncomeTaxRateDiscountFor(taxpayer, basicWage);
            taxpayer.IncomeTaxRatePercentage = _incomeTaxCalculatorService.CalculateIncomeTaxRatePercentageFor(taxpayer, basicWage, discountValue);

            taxpayer.TotalIncomeTax = _incomeTaxCalculatorService.CalculateTotalIncomeTax(monthlyGrowthRate: taxpayer.MonthlyGrossIncome,
                taxRatePercentage: taxpayer.IncomeTaxRatePercentage,
                discount: discountValue);
        }
    }
}