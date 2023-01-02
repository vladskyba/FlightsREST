using System.Collections.Generic;

namespace FlightREST.DataTransfer
{
    public class FlightReadTransfer : FlightBaseTransfer
    {
        public long Id { get; set; }

        public ICollection<FlightBasedBookingReadTransfer> Bookings { get; set; }
    }
}
