using AutoMapper;
using NauticaFreight.API.Models.Domain;
using NauticaFreight.API.Models.Dtos;

namespace NauticaFreight.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<AddCustomerDto, Customer>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
        }

        
    }
}
