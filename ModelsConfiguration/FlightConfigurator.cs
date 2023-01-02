using FlightREST.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightREST.ModelsConfiguration
{
    public class FlightConfigurator : BaseEntityConfigurator<Models.Flight>
    {
        public override void Configure(EntityTypeBuilder<Models.Flight> flight)
        {
            base.Configure(flight);

            flight.ToTable(nameof(Models.Flight).ToSnakeCase())
                .HasKey(t => t.Id);

            flight.HasMany(f => f.Bookings)
                .WithOne(b => b.Flight)
                .HasForeignKey(b => b.FlightId);
        }
    }
}
