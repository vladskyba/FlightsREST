using System.Collections.Generic;

namespace FlightREST.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Phone { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
