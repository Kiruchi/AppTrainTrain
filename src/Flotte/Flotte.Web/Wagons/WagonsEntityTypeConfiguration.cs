using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flotte.Web.Wagons
{
    public class WagonsEntityTypeConfiguration : IEntityTypeConfiguration<Wagon>
    {
        public void Configure(EntityTypeBuilder<Wagon> builder)
        {
            builder.ToTable("Wagons");
            
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Marque).IsRequired();
            builder.Property(w => w.Modele).IsRequired();
            builder.Property(w => w.Poids).IsRequired();
            builder.Property(w => w.Capacite).IsRequired();
        }
    }
}