using AutoMapper;
using FlightREST.DataTransfer;

namespace FlightREST.MappingProfiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Models.Flight, FlightBaseTransfer>()
                .ReverseMap();

            CreateMap<Models.Flight, FlightReadTransfer>()
                .ReverseMap();
        }
    }
}
