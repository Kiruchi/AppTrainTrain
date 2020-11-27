using System;
using System.Threading.Tasks;
using Reservations.Hexagon;
using Reservations.Hexagon.SecondaryPorts;

namespace Reservations.Infra
{
    public class DummyReservationNotifieur : IReservationNotifieur
    {
        public async Task NotifierReservationValideeAsync(Reservation reservation)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Reservation validée");
        }
    }
}