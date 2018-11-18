using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services.Communication.Taxpayers;

namespace IncomeTax.API.Domain.Services
{
    /// <summary>
    /// Contrato do serviço de contribuintes.
    /// </summary>
    public interface ITaxpayerService
    {
        /// <summary>
        /// Lista os contribuintes cadastrados na base, populando dados de alíquota do imposto do contribuinte e valor a ser pago.await
        /// A listagem é feita em ordem crescente por valores a ser pagos e nomes dos contribuintes.
        /// </summary>
        /// <returns>Enumeração de contribuintes.</returns>
        Task<IEnumerable<Taxpayer>> ListAsync();

        /// <summary>
        /// Lista um contribuinte por códio.
        /// </summary>
        /// <param name="id">Código do contribuinte.</param>
        /// <returns>Dados do contribuinte.</returns>
        Task<Taxpayer> GetByIdAsync(int id);

        /// <summary>
        /// Grava um contribuinte na base de dados.
        /// </summary>
        /// <param name="taxpayer">Dados do contribuinte.</param>
        /// <returns>Resposta da requisição.</returns>
        Task<TaxpayerResponse> CreateAsync(Taxpayer taxpayer);

        /// <summary>
        /// Atualiza os dados de um contribuinte na base de dados.
        /// </summary>
        /// <param name="id">Código do contribuinte.</param>
        /// <param name="taxpayer">Dados do contribuinte.</param>
        /// <returns>Resposta da requisição.</returns>        
        Task<TaxpayerResponse> UpdateAsync(int id, Taxpayer taxpayer);

        /// <summary>
        /// Exclui os dados de um contribuinte da base de dados.
        /// </summary>
        /// <param name="id">Código do contribuinte.</param>
        /// <returns>Resposta da requisição.</returns>      
        Task<TaxpayerResponse> DeleteAsync(int id);
    }
}