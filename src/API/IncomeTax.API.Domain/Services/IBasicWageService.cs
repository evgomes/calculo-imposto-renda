using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Communication.BasicWageData;

namespace IncomeTax.API.Domain.Services
{
    public interface IBasicWageService
    {
        Task<BasicWage> GetBasicWageDataAsync();
        Task<BasicWageResponse> RecordBasicWageDataAsync(BasicWage basicWage);
    }
}