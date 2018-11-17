using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Repositories
{
    public interface IBasicWageRepository
    {
         Task<BasicWage> GetBasicWageDataAsync();
         Task<BasicWage> RecordBasicWageDataAsync(BasicWage basicWage);
    }
}