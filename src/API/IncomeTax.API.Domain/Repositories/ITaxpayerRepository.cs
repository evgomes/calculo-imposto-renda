using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Domain.Repositories
{
    /// <summary>
    /// Contrato do repositório de contribuintes.
    /// </summary>
    public interface ITaxpayerRepository
    {
        /// <summary>
        /// Lista todos os contribuintes da base de dados.
        /// </summary>
        /// <returns>Enumeração de contribuintes.</returns>
        Task<IEnumerable<Taxpayer>> ListAsync();

        /// <summary>
        /// Lista um contribuinte de acordo com o código.
        /// </summary>
        /// <param name="id">Código do contribuinte.</param>
        /// <returns>Dados do contribuinte.</returns>
        Task<Taxpayer> GetByIdAsync(int id);

        /// <summary>
        /// Lista um contribuinte de acordo com o CPF.
        /// </summary>
        /// <param name="id">CPF do contribuinte.</param>
        /// <returns>Dados do contribuinte.</returns>
        Task<Taxpayer> GetByCPFAsync(long CPF);

        /// <summary>
        /// Grava um contribuinte na base de dados.
        /// </summary>
        /// <param name="taxpayer">Dados do contribuinte.</param>
        /// <returns>Task.</returns>
        Task AddAsync(Taxpayer taxpayer);

        /// <summary>
        /// Atualiza um contribuinte na base de dados.
        /// </summary>
        /// <param name="taxpayer">Dados do contribuinte.</param>
        void Update(Taxpayer taxpayer);

        /// <summary>
        /// Excluir um contribuinte da base de dados.
        /// </summary>
        /// <param name="taxpayer">Dados do contribuinte.</param>
        /// <returns>Task.</returns>
        void Delete(Taxpayer taxpayer);
    }
}