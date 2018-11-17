using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Communication.Taxpayers;

namespace IncomeTax.API.Domain.Services
{
    public interface ITaxpayerService
    {
        Task<IEnumerable<Taxpayer>> ListAsync();
        Task<Taxpayer> GetByIdAsync(int id);
        Task<TaxpayerResponse> CreateAsync(Taxpayer taxpayer);
        Task<TaxpayerResponse> UpdateAsync(int id, Taxpayer taxpayer);
        Task<TaxpayerResponse> DeleteAsync(int id);
    }
}