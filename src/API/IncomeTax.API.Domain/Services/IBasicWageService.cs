using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Communication.BasicWageData;

namespace IncomeTax.API.Domain.Services
{
    /// <summary>
    /// Contrato do serviço de dados do salário mínimo.
    /// </summary>
    public interface IBasicWageService
    {
        /// <summary>
        /// Retorna os dados do salário mínimo atual.
        /// </summary>
        /// <returns>Dados do salário mínimo.</returns>
        Task<BasicWage> GetBasicWageDataAsync();

        /// <summary>
        /// Atualiza os dados do salário mínimo atual.
        /// </summary>
        /// <param name="basicWage">Dados do salário mínimo.</param>
        /// <returns>Dados atualizados.</returns>
        Task<BasicWageResponse> RecordBasicWageDataAsync(BasicWage basicWage);
    }
}