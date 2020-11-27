using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservations.Infra.Db.Models;

namespace Reservations.Infra.Db.Configurations
{
    public class DbPassagerConfiguration : IEntityTypeConfiguration<DbPassager>
    {
        public void Configure(EntityTypeBuilder<DbPassager> builder)
        {
            builder.ToTable("Passagers");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nom).IsRequired();
            builder.Property(p => p.Prenom).IsRequired();
            builder.Property(p => p.DateDeNaissance).IsRequired();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}