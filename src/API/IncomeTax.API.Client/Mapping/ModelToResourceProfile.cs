using AutoMapper;
using IncomeTax.API.Client.Resources;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Client.Mapping
{
    /// <summary>
    /// Mapeamento das models de domínio para classes de recurso da API.
    /// </summary>
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<BasicWage, BasicWageResource>();
            CreateMap<Taxpayer, TaxpayerResource>();
        }
    }
}