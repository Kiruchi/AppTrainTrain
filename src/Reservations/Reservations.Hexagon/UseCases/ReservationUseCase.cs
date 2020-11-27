using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservations.Hexagon.Exceptions;
using Reservations.Hexagon.PrimaryPorts;
using Reservations.Hexagon.SecondaryPorts;
using Shared.Core.Exceptions;

namespace Reservations.Hexagon.UseCases
{
    public class ReservationUseCase : IReservationUseCase
    {
        private static readonly TauxOccupation SeuilCapacite = new TauxOccupation(70);
        
        private readonly ITrainRepository _trainRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IReservationNotifieur _notifieur;

        public ReservationUseCase(
            ITrainRepository trainTrainRepository,
            IReservationRepository reservationRepository,
            IReservationNotifieur notifieur)
        {
            _trainRepository = trainTrainRepository;
            _reservationRepository = reservationRepository;
            _notifieur = notifieur;
        }
        
        public async Task ReserverAsync(IdVoyage idVoyage, IReadOnlyCollection<Passager> passagers)
        {
            var train = await _trainRepository.GetTrainDuVoyageAsync(idVoyage);
            if (train == null)
                throw new VoyageSansTrainException(idVoyage);
            
            if (!train.PeutReserver(passagers.Count, SeuilCapacite))
                throw new TrainPleinException();

            var reservation = train.Reserver(passagers, SeuilCapacite);
            
            // Refacto : Save en une seule fois
            await _trainRepository.SaveAsync(train);
            await _reservationRepository.SaveAsync(reservation);

            await _notifieur.NotifierReservationValideeAsync(reservation);
        }
    }
}