using System.Threading.Tasks;
using Reservations.Hexagon;
using Reservations.Hexagon.SecondaryPorts;

namespace Reservations.Infra
{
    public class DummyTrainRepository : ITrainRepository
    {
        public async Task<Train> GetTrainDuVoyageAsync(IdVoyage idVoyage)
        {
            await Task.CompletedTask;
            return new Train(
                idVoyage,
                new []
                {
                    new Voiture(new NumeroVoiture(12), 100), 
                    new Voiture(new NumeroVoiture(13), 100, 50), 
                });
        }

        public async Task SaveAsync(Train train)
        {
            await Task.CompletedTask;
        }
    }
}