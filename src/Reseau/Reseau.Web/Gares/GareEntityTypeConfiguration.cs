using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Reseau.Web.Gares
{
    public class GareEntityTypeConfiguration : IEntityTypeConfiguration<Gare>
    {
        public void Configure(EntityTypeBuilder<Gare> builder)
        {
            builder.ToTable("Gares");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Nom).IsRequired();
            builder.Property(g => g.NumeroRue).IsRequired(false);
            builder.Property(g => g.Rue).IsRequired();
            builder.Property(g => g.CodePostal).IsRequired();
            builder.Property(g => g.Ville).IsRequired();
        }
    }
}