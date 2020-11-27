using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservations.Hexagon;
using Reservations.Hexagon.SecondaryPorts;
using Reservations.Infra.Db;
using Reservations.Infra.Db.Models;

namespace Reservations.Infra
{
    public class DummyTrainRepository : ITrainRepository
    {
        private readonly ReservationsContext _dbContext;

        public DummyTrainRepository(ReservationsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Train> GetTrainDuVoyageAsync(IdVoyage idVoyage)
        {
            var reservations =
                await _dbContext.Set<DbReservation>()
                    .Include(r => r.Passagers)
                    .Where(r => r.IdVoyage == (int)idVoyage)
                    .ToListAsync();

            var nbReservationsVoiture12 =
                reservations
                    .Where(r => r.NumeroVoiture == 12)
                    .SelectMany(r => r.Passagers)
                    .Count();
            var nbReservationsVoiture13 =
                reservations
                    .Where(r => r.NumeroVoiture == 13)
                    .SelectMany(r => r.Passagers)
                    .Count();
            
            return new Train(
                idVoyage,
                new []
                {
                    new Voiture(new NumeroVoiture(12), 100, nbReservationsVoiture12), 
                    new Voiture(new NumeroVoiture(13), 100, nbReservationsVoiture13), 
                });
        }
    }
}