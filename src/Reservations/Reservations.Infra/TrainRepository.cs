using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservations.Hexagon;
using Reservations.Hexagon.SecondaryPorts;
using Reservations.Infra.Db;
using Reservations.Infra.Db.Models;
using Voyages.Hexagon.PrimaryPorts;

namespace Reservations.Infra
{
    public class TrainRepository : ITrainRepository
    {
        private readonly ReservationsContext _dbContext;
        private readonly IGetVoyageUseCase _voyageUseCase;

        public TrainRepository(
            ReservationsContext dbContext,
            IGetVoyageUseCase voyageUseCase)
        {
            _dbContext = dbContext;
            _voyageUseCase = voyageUseCase;
        }

        public async Task<Train> GetTrainDuVoyageAsync(IdVoyage idVoyage)
        {
            var reservations =
                await _dbContext.Set<DbReservation>()
                    .Include(r => r.Passagers)
                    .Where(r => r.IdVoyage == (int)idVoyage)
                    .ToListAsync();

            var voyage = await _voyageUseCase.GetVoyageAsync((int)idVoyage);
            if (voyage == null)
                return null;

            return new Train(
                idVoyage,
                voyage.Train.Voitures
                    .Select(v =>
                        new Voiture(
                            new NumeroVoiture(v.Numero),
                            v.Capacite,
                            GetNbReservations(reservations, v.Numero)))
                    .ToList());
        }
        
        private static int GetNbReservations(IReadOnlyCollection<DbReservation> reservations, int numeroVoiture) =>
            reservations
                .Where(r => r.NumeroVoiture == numeroVoiture)
                .SelectMany(r => r.Passagers)
                .Count();
    }
}