namespace Voyages.Hexagon
{
    public class Voyage
    {
        public Voyage(int voyageId, Ligne ligne, Train train)
        {
            VoyageId = voyageId;
            Ligne = ligne;
            Train = train;
        }

        public int VoyageId { get; }

        public Ligne Ligne { get; }

        public Train Train { get; }
    }
}