using System.Threading.Tasks;
using AutoMapper;
using IncomeTax.API.Client.Resources;
using IncomeTax.API.Domain.Models;
using IncomeTax.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace IncomeTax.API.Client.Controllers
{
    /// <summary>
    /// Controller que expõe endpoints para atualizar o valor do salário mínimo.
    /// </summary>
    [Route("/api/[controller]")]
    public class BasicWageController : Controller
    {
        private readonly IBasicWageService _basicWageService;
        private readonly IMapper _mapper;

        public BasicWageController(IBasicWageService basicWageService, IMapper mapper)
        {
            _basicWageService = basicWageService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna os dados do salário mínimo atual.
        /// </summary>
        /// <returns>Recurso com os dados do salário mínimo atual.</returns>
        [HttpGet]
        public async Task<BasicWageResource> GetBasicWageDataAsync()
        {
            var basicWageData = await _basicWageService.GetBasicWageDataAsync();
            return _mapper.Map<BasicWage, BasicWageResource>(basicWageData);
        }

        /// <summary>
        /// Atualiza os dados do salário mínimo atual.
        /// </summary>
        /// <param name="basicWageResource">Dados do salário mínimo.</param>
        /// <returns>Dados atualizados do salário mínimo.</returns>
        [HttpPost]
        public async Task<IActionResult> RecordBasicWageDataAsync([FromBody] BasicWageResource basicWageResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basicWageData = _mapper.Map<BasicWageResource, BasicWage>(basicWageResource);

            var response = await _basicWageService.RecordBasicWageDataAsync(basicWageData);
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            var resource = _mapper.Map<BasicWage, BasicWageResource>(response.BasicWage);
            return Ok(resource);
        }
    }
}