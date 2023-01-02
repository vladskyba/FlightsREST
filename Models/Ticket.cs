namespace FlightREST.Models
{
    public class Ticket : BaseEntity
    {
        public byte Line { get; set; }

        public byte Seat { get; set; }

        public long BookingId { get; set; }

        public Booking Booking { get; set; }
    }
}
