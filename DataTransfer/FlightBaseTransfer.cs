using System;

namespace FlightREST.DataTransfer
{
    public class FlightBaseTransfer
    {
        public string Arrival { get; set; }

        public string Departure { get; set; }

        public DateTime ArrivalDateTime { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public decimal Cost { get; set; }

        public bool IsActive { get; set; }
    }
}
