using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Persistence.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IncomeTax.API.Persistence.EF.Repositories
{
    public class BasicWageRepository : IBasicWageRepository
    {
        private readonly AppDbContext _context;

        public BasicWageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BasicWage> GetBasicWageDataAsync()
        {
            return await _context.BasicWage.FirstOrDefaultAsync();
        }

        public async Task<BasicWage> RecordBasicWageDataAsync(BasicWage basicWage)
        {
            var basicWageData = await GetBasicWageDataAsync();
            
            if(basicWageData == null)
            {
                await _context.BasicWage.AddAsync(basicWage);
                return basicWage;
            }

            basicWageData.Value = basicWage.Value;
            _context.BasicWage.Update(basicWageData);

            return basicWageData;
        }
    }
}