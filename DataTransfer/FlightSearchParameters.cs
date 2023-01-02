using System;

namespace FlightREST.DataTransfer
{
    public class FlightSearchParameters
    {
        public string Departure { get; set; }

        public string Arrival { get; set; }

        public DateTime? DepartureStart { get; set; }

        public DateTime? DepartureEnd { get; set;  }
    }
}
