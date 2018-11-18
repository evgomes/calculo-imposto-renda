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

        public async Task<Taxpayer> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return await _context.Taxpayer.FirstOrDefaultAsync(taxpayer => taxpayer.Id == id);
        }

        public async Task<Taxpayer> GetByCPFAsync(long CPF)
        {
            return await _context.Taxpayer.FirstOrDefaultAsync(taxpayer => taxpayer.CPF == CPF);
        }

        public async Task AddAsync(Taxpayer taxpayer)
        {
            await _context.Taxpayer.AddAsync(taxpayer);
        }

        public void Update(Taxpayer taxpayer)
        {
            _context.Taxpayer.Update(taxpayer);
        }

        public void Delete(Taxpayer taxpayer)
        {
            _context.Taxpayer.Remove(taxpayer);
        }
    }
}