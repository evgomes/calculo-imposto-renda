using AutoMapper;
using IncomeTax.API.Client.Resources;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Client.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<BasicWage, BasicWageResource>();
        }
    }
}