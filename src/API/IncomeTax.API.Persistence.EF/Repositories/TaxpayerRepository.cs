using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Persistence.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IncomeTax.API.Persistence.EF.Repositories
{
    public class TaxpayerRepository : ITaxpayerRepository
    {
        private readonly AppDbContext _context;

        public TaxpayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Taxpayer>> ListAsync()
        {
            return await _context.Taxpayer.AsNoTracking().ToListAsync();
        }
    }
}