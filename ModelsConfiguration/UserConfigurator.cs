using FlightREST.Models;
using FlightREST.ModelsConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightREST.ModelsConfiguration
{
    public class UserConfigurator : BaseEntityConfigurator<User>
    {
        public override void Configure(EntityTypeBuilder<User> user)
        {
            base.Configure(user);

            user.ToTable(nameof(User).ToSnakeCase())
                .HasKey(t => t.Id);

            user.HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            //user.HasMany(u => u.Tickets)
            //    .WithOne(t => t.User)
            //    .HasForeignKey(t => t.UserId);
        }
    }
}
