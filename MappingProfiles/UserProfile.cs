using AutoMapper;
using FlightREST.DataTransfer;
using FlightREST.Models;

namespace FlightREST.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserBaseTransfer>()
                .ReverseMap();

            CreateMap<User, UserReadTransfer>()
                .ReverseMap();
        }
    }
}
