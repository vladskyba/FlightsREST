using System.Collections.Generic;

namespace FlightREST.DataTransfer
{
    public class BookingReadTransfer : BookingBaseTransfer
    {
        public long Id { get; set; }

        public FlightBaseTransfer Flight { get; set; }

        public ICollection<TicketBaseTransfer> Tickets { get; set; }
    }
}
