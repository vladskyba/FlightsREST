using System;
using System.Collections.Generic;

namespace FlightREST.Models
{
    public class Flight : BaseEntity
    {
        public string Arrival { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public string Departure { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public decimal Cost { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
