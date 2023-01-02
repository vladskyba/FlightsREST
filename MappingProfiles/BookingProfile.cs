using AutoMapper;
using FlightREST.DataTransfer;
using FlightREST.Models;

namespace FlightREST.MappingProfiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingBaseTransfer>()
                .ReverseMap();

            CreateMap<Booking, BookingCreateTransfer>()
                .ReverseMap();

            CreateMap<Booking, BookingReadTransfer>()
                .ReverseMap();

            CreateMap<Ticket, TicketBaseTransfer>()
                .ReverseMap();

            CreateMap<Booking, FlightBasedBookingReadTransfer>()
                .ReverseMap();
        }
    }
}
