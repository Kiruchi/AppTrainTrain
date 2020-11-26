using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservations.Hexagon.PrimaryPorts;
using Reservations.Hexagon.SecondaryPorts;
using Shared.Core.Exceptions;

namespace Reservations.Hexagon.UseCases
{
    public class ReservationUseCase : IReservationUseCase
    {
        private const decimal SeuilCapacite = 0.7m;
        
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
        
        public async Task ReserverAsync(int idVoyage, IReadOnlyCollection<Passager> passagers)
        {
            var train = await _trainRepository.GetTrainDuVoyageAsync(idVoyage);
            if (train == null)
                throw new NotFoundException<int>(idVoyage);

            var voitureAvecDeLaPlace =
                train.Voitures
                    .FirstOrDefault(v => PeutReserverPlacesSansDepasserSeuil(v, passagers.Count));
            
            if (voitureAvecDeLaPlace == null)
                throw new ArgumentException("train plein");

            voitureAvecDeLaPlace.PlacesOccupees += passagers.Count;
            await _trainRepository.SaveAsync(train);

            var reservation =
                new Reservation
                {
                    IdVoyage = idVoyage,
                    Passagers = passagers,
                    NumeroVoiture = voitureAvecDeLaPlace.Numero
                };
            await _reservationRepository.SaveAsync(reservation);

            await _notifieur.NotifierReservationValideeAsync(reservation);
        }

        private static bool PeutReserverPlacesSansDepasserSeuil(Voiture voiture, int nbPassagers) =>
            voiture.PlacesOccupees + nbPassagers < voiture.Capacite * SeuilCapacite;
    }
}