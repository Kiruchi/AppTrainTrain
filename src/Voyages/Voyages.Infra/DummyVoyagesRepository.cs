using System;
using System.Threading.Tasks;
using Voyages.Hexagon;
using Voyages.Hexagon.UseCases;

namespace Voyages.Infra
{
    public class DummyVoyagesRepository : IVoyageRepository
    {
        public async Task<Voyage> GetVoyageAsync(int voyageId)
        {
            await Task.CompletedTask;

            var ligne =
                new Ligne(
                    12,
                    new Gare(11, "Gare Nord (Nantes)"),
                    new Gare(13, "Gare Montparnasse (Paris)"),
                    new TimeSpan(2, 08, 00));

            var train =
                new Train(
                    Guid.NewGuid(), 
                    Guid.NewGuid(), 
                    new []
                    {
                        new Voiture(12, Guid.NewGuid(), 100), 
                        new Voiture(13, Guid.NewGuid(), 200), 
                    });
            
            return new Voyage(voyageId, ligne, train);
        }
    }
}