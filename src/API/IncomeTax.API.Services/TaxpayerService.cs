using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services;
using IncomeTax.API.Domain.Services.Communication.Taxpayers;

namespace IncomeTax.API.Services
{
    public class TaxpayerService : ITaxpayerService
    {
        public async Task<IEnumerable<Taxpayer>> ListAsync()
        {
            throw new System.NotImplementedException();
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