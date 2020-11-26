using Microsoft.EntityFrameworkCore;
using Reseau.Web.Gares;
using Reseau.Web.Lignes;

namespace Reseau.Web.Db
{
    public class ReseauContext : DbContext
    {
        public ReseauContext(DbContextOptions<ReseauContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GareEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LigneEntityTypeConfiguration());
        }
    }
}