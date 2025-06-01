using AutoMapper;
using NauticaFreight.API.Customers;
using NauticaFreight.API.Ports;
using NauticaFreight.API.Trips;
using NauticaFreight.API.Vessels;

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

            // Vessel Mapping
            CreateMap<Vessel, VesselDto>().ReverseMap();
            CreateMap<Vessel, AddVesselDto>().ReverseMap();
            CreateMap<Vessel, UpdateVesselDto>().ReverseMap();

            // Trip Mapping
            CreateMap<Trip, TripDto>().ReverseMap();
            CreateMap<Trip, AddTripDto>().ReverseMap();
            CreateMap<Trip, UpdateTripDto>().ReverseMap();
            CreateMap<TripDto, AddTripDto>().ReverseMap();

        }


    }
}
