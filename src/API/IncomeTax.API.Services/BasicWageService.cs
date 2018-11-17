using System;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Domain.Services;
using IncomeTax.API.Domain.Services.Communication.BasicWageData;

namespace IncomeTax.API.Services
{
    public class BasicWageService : IBasicWageService
    {
        private readonly IBasicWageRepository _basicWageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BasicWageService(IBasicWageRepository basicWageRepository, IUnitOfWork unitOfWork)
        {
            _basicWageRepository = basicWageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BasicWage> GetBasicWageDataAsync() => await _basicWageRepository.GetBasicWageDataAsync();

        public async Task<BasicWageResponse> RecordBasicWageDataAsync(BasicWage basicWage)
        {
            try
            {
                var updatedBasicWage = await _basicWageRepository.RecordBasicWageDataAsync(basicWage);
                await _unitOfWork.CompleteAsync();
                
                return BasicWageResponse.CreateSuccess(updatedBasicWage);
            }
            catch (Exception ex)
            {
                return BasicWageResponse.CreateFail(ex.Message);
            }
        }
    }
}