using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Repositories
{
    /// <summary>
    /// Contrato do repositório de salário mínimo. 
    /// </summary>
    public interface IBasicWageRepository
    {
        /// <summary>
        /// Retorna os dados do salário mínimo atual da base de dados.
        /// </summary>
        /// <returns>Dados do salário mínimo.</returns>
        Task<BasicWage> GetBasicWageDataAsync();

        /// <summary>
        /// Atualiza os dados do salário mínimo atual.
        /// </summary>
        /// <param name="basicWage">Dados do salário mínimo.</param>
        /// <returns>Dados atualizados.</returns>
        Task<BasicWage> RecordBasicWageDataAsync(BasicWage basicWage);
    }
}