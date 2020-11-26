using Flotte.Web.Locomotives;
using Flotte.Web.Wagons;
using Microsoft.EntityFrameworkCore;

namespace Flotte.Web.Db
{
    public class FlotteContext : DbContext
    {
        public FlotteContext(DbContextOptions<FlotteContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocomotiveEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WagonsEntityTypeConfiguration());
        }
    }
}