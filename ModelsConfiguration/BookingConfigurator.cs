using FlightREST.Models;
using FlightREST.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightREST.ModelsConfiguration
{
    public class BookingConfigurator : BaseEntityConfigurator<Booking>
    {
        public override void Configure(EntityTypeBuilder<Booking> booking)
        {
            base.Configure(booking);

            booking.ToTable(nameof(Booking).ToSnakeCase())
                .HasKey(t => t.Id);

            booking.HasOne(b => b.Flight)
                .WithMany(f => f.Bookings)
                .HasForeignKey(b => b.FlightId);

            booking.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);
        }
    }
}
