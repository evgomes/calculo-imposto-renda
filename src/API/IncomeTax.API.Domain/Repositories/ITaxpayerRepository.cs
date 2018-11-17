using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Repositories
{
    public interface ITaxpayerRepository
    {
         Task<IEnumerable<Taxpayer>> ListAsync();
    }
}