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

        [HttpGet]
        public async Task<IEnumerable<TaxpayerResource>> ListAsync()
        {
            var taxpayers = await _taxpayerService.ListAsync();
            var taxpayersResources = _mapper.Map<IEnumerable<Taxpayer>, IEnumerable<TaxpayerResource>>(taxpayers);

            return taxpayersResources;
        }

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

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SaveTaxpayerResource saveTaxpayerResource)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, SaveTaxpayerResource saveTaxpayerResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingTaxpayer = await _taxpayerService.GetByIdAsync(id);

            if (existingTaxpayer == null)
            {
                return NotFound();
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingTaxpayer = await _taxpayerService.GetByIdAsync(id);

            if (existingTaxpayer == null)
            {
                return NotFound();
            }

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