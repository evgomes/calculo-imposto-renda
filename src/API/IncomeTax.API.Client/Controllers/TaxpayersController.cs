using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IncomeTax.API.Client.Resources;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncomeTax.API.Client.Controllers
{
    /// <summary>
    /// Controller que expõe endpoints para criar, ler, atualizar e excluir contribuintes do imposto de renda.
    /// </summary>
    [Route("/api/[controller]/")]
    public class TaxpayersController : Controller
    {
        private readonly ITaxpayerService _taxpayerService;
        private readonly IMapper _mapper;

        public TaxpayersController(ITaxpayerService taxpayerService, IMapper mapper)
        {
            _taxpayerService = taxpayerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna os dados de todos os contribuintes do imposto de renda cadastrados na base de dados.
        /// </summary>
        /// <returns>Enumeração de dados dos contribuintes.</returns>
        [HttpGet]
        public async Task<IEnumerable<TaxpayerResource>> ListAsync()
        {
            var taxpayers = await _taxpayerService.ListAsync();
            var taxpayersResources = _mapper.Map<IEnumerable<Taxpayer>, IEnumerable<TaxpayerResource>>(taxpayers);

            return taxpayersResources;
        }

        /// <summary>
        /// Retorna um contribuinte do imposto de renda por ID.
        /// </summary>
        /// <param name="id">ID do contribuinte.</param>
        /// <returns>Dados do contribuinte.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var taxpayer = await _taxpayerService.GetByIdAsync(id);

            if (taxpayer == null)
            {
                return NotFound();
            }

            var taxpayerResource = _mapper.Map<Taxpayer, TaxpayerResource>(taxpayer);
            return Ok(taxpayerResource);
        }

        /// <summary>
        /// Cria um contribuinte e grava na base de dados.
        /// </summary>
        /// <param name="saveTaxpayerResource">Dados para criação do contribuinte.</param>
        /// <returns>Dados do contribuinte cadastrado.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveTaxpayerResource saveTaxpayerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taxpayer = _mapper.Map<SaveTaxpayerResource, Taxpayer>(saveTaxpayerResource);

            var response = await _taxpayerService.CreateAsync(taxpayer);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var resource = _mapper.Map<Taxpayer, TaxpayerResource>(response.Taxpayer);
            return Ok(resource);
        }

        /// <summary>
        /// Atualiza os dados de um contribuinte.
        /// </summary>
        /// <param name="id">Código do contribuinte.</param>
        /// <param name="saveTaxpayerResource">Dados do contribuinte para atualização.</param>
        /// <returns>Dados atualizados do contribuinte.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveTaxpayerResource saveTaxpayerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taxpayer = _mapper.Map<SaveTaxpayerResource, Taxpayer>(saveTaxpayerResource);
            var response = await _taxpayerService.UpdateAsync(id, taxpayer);

            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var resource = _mapper.Map<Taxpayer, TaxpayerResource>(response.Taxpayer);
            return Ok(resource);
        }

        /// <summary>
        /// Exclui os dados de um contribuinte.
        /// </summary>
        /// <param name="id">Código do contribuinte.</param>
        /// <returns>Dados excluídos do contribuinte.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _taxpayerService.DeleteAsync(id);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var resource = _mapper.Map<Taxpayer, TaxpayerResource>(response.Taxpayer);
            return Ok(resource);
        }
    }
}