using System.Collections.Generic;

namespace FlightREST.DataTransfer
{
    public class BookingCreateTransfer : BookingBaseTransfer
    {
        public long UserId { get; set; }

        public long FlightId { get; set; }

        public ICollection<TicketBaseTransfer> Tickets { get; set; }
    }
}
