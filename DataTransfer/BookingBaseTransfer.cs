using FlightREST.Enums;

namespace FlightREST.DataTransfer
{
    public class BookingBaseTransfer
    {
        public BookingStatus BookingStatus { get; set; }

        public string Email { get; set; }
    }
}
