using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservations.Infra.Db.Models;

namespace Reservations.Infra.Db.Configurations
{
    public class DbReservationConfiguration : IEntityTypeConfiguration<DbReservation>
    {
        public void Configure(EntityTypeBuilder<DbReservation> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.IdVoyage).IsRequired();
            builder.Property(p => p.NumeroVoiture).IsRequired();

            builder
                .HasMany(r => r.Passagers)
                .WithOne()
                .HasForeignKey(p => p.ReservationId);
        }
    }
}