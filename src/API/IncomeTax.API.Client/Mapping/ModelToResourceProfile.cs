using AutoMapper;
using IncomeTax.API.Client.Resources;
using IncomeTax.API.Domain.Models;

namespace IncomeTax.API.Client.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<BasicWageResource, BasicWage>();
        }
    }
}