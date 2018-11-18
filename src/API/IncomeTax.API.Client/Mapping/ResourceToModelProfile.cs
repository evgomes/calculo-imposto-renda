using System;
using AutoMapper;
using IncomeTax.API.Client.Resources;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Client.Mapping
{
    /// <summary>
    /// Mapeamentos das classes de recuro da API para models de domínio.
    /// </summary>
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<BasicWageResource, BasicWage>();
            CreateMap<SaveTaxpayerResource, Taxpayer>()
                .ForMember(src => src.CPF, opt => opt.MapFrom(src => Convert.ToInt64(src.CPF)));
        }
    }
}