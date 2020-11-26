using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flotte.Web.Locomotives
{
    public class LocomotiveEntityTypeConfiguration : IEntityTypeConfiguration<Locomotive>
    {
        public void Configure(EntityTypeBuilder<Locomotive> builder)
        {
            builder.ToTable("Locomotives");

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Marque).IsRequired();
            builder.Property(l => l.Modele).IsRequired();
            builder.Property(l => l.TractionMax).IsRequired();
        }
    }
}