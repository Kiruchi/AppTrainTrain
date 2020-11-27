using Reservations.Hexagon.Exceptions;
using Shared.Core.DomainModeling;

namespace Reservations.Hexagon
{
    public class TauxOccupation : ComparableValueObject<decimal>
    {
        public TauxOccupation(decimal value) : base(value)
        {
            if (value < 0 || 100 < value)
                throw new TauxOccupationInvalideException();
        }
    }
}