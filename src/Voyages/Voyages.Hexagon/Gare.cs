namespace Voyages.Hexagon
{
    public class Gare
    {
        public Gare(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public int Id { get; }
        public string Nom { get; }
    }
}