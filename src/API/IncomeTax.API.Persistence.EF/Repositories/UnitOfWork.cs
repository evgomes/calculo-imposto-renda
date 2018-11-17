using System.Threading.Tasks;
using IncomeTax.API.Domain.Repositories;
using IncomeTax.API.Persistence.EF.Contexts;

namespace IncomeTax.API.Persistence.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}