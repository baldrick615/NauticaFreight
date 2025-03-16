using AutoMapper;
using NauticaFreight.API.Models.Domain;
using NauticaFreight.API.Models.Dtos;

namespace NauticaFreight.API.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Source -> Target
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, AddCustomerDto>().ReverseMap();
    }
    
}