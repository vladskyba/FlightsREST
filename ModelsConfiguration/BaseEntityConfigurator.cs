using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FlightREST.Models;
using FlightREST.ModelsConfiguration;

namespace FlightREST.ModelsConfigurations
{
    public class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnName($"{typeof(TEntity).Name.ToSnakeCase()}_id")
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
