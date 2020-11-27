using Microsoft.EntityFrameworkCore;
using Reservations.Infra.Db.Configurations;

namespace Reservations.Infra.Db
{
    public class ReservationsContext : DbContext
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DbReservationConfiguration());
            modelBuilder.ApplyConfiguration(new DbPassagerConfiguration());
        }
    }
}