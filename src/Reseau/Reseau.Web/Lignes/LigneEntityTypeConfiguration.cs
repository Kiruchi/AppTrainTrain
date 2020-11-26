using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reseau.Web.Lignes
{
    public class LigneEntityTypeConfiguration : IEntityTypeConfiguration<Ligne>
    {
        public void Configure(EntityTypeBuilder<Ligne> builder)
        {
            builder.ToTable("Lignes");

            builder.HasKey(l => l.Id);
            
            builder.Property(l => l.GareDepartId).IsRequired();
            builder.HasOne(l => l.GareDepart)
                .WithMany()
                .HasForeignKey(l => l.GareDepartId);

            builder.Property(l => l.GareArriveeId).IsRequired();
            builder.HasOne(l => l.GareArrivee)
                .WithMany()
                .HasForeignKey(l => l.GareArriveeId);
            
            builder.Property(l => l.DureeTrajet).IsRequired();
        }
    }
}