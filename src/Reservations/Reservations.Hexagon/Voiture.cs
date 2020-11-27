namespace Reservations.Hexagon
{
    public class Voiture
    {
        public int Numero { get; }
        public int Capacite { get; }
        public int PlacesOccupees { get; }
        public Voiture(int numero, int capacite)
        {
            Numero = numero;
            Capacite = capacite;
        }
    }
}