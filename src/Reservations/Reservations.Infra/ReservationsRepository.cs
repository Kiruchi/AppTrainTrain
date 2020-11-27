using System.Threading.Tasks;
using Reservations.Hexagon;
using Reservations.Hexagon.SecondaryPorts;
using Reservations.Infra.Db;
using Reservations.Infra.Db.Models;

namespace Reservations.Infra
{
    public class ReservationsRepository : IReservationRepository
    {
        private readonly ReservationsContext _dbContext;

        public ReservationsRepository(ReservationsContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task SaveAsync(Reservation reservation)
        {
            var dbReservation = DbReservation.FromDomain(reservation);

            await _dbContext.Set<DbReservation>().AddAsync(dbReservation);
            await _dbContext.SaveChangesAsync();
        }
    }
}