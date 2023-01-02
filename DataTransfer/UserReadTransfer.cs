using FlightREST.Models;
using System.Collections.Generic;

namespace FlightREST.DataTransfer
{
    public class UserReadTransfer : UserBaseTransfer
    {
        public long Id { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
