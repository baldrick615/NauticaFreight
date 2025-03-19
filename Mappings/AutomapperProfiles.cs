using AutoMapper;
using NauticaFreight.API.Models.Domain;
using NauticaFreight.API.Models.Dtos;

namespace NauticaFreight.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            // Customer Mapping
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, AddCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

            // Port Mapping
            CreateMap<Port, PortDto>().ReverseMap();
            CreateMap<Port, AddPortDto>().ReverseMap();
            CreateMap<Port, UpdatePortDto>().ReverseMap();
        }

        
    }
}
