using FlightREST.Models;
using FlightREST.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightREST.ModelsConfiguration
{
    public class TicketConfigurator : BaseEntityConfigurator<Ticket>
    {
        public override void Configure(EntityTypeBuilder<Ticket> ticket)
        {
            base.Configure(ticket);

            ticket.ToTable(nameof(Ticket).ToSnakeCase())
                .HasKey(t => t.Id);

            ticket.HasOne(t => t.Booking)
                .WithMany(b => b.Tickets)
                .HasForeignKey(t => t.BookingId);
        }
    }
}
