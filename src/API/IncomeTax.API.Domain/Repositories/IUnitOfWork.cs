using System.Threading.Tasks;

namespace IncomeTax.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}