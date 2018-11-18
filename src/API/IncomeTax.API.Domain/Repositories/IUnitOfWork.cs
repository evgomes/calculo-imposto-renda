using System.Threading.Tasks;

namespace IncomeTax.API.Domain.Repositories
{
    /// <summary>
    /// Unidade de trabalho para controlar transações na base de dados.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Completa uma transação.
        /// </summary>
        /// <returns>Task.</returns>
        Task CompleteAsync();
    }
}