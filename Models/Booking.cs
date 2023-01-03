using FlightREST.Enums;
using System.Collections.Generic;

namespace FlightREST.Models
{
    public class Booking : BaseEntity
    {
        public long UserId { get; set; }

        public string Email { get; set; }

        public User User { get; set; }

        public long FlightId { get; set; }

        public Flight Flight { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
