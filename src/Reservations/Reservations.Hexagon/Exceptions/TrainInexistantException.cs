using Shared.Core.Exceptions;

namespace Reservations.Hexagon.Exceptions
{
    public class VoyageSansTrainException : NotFoundException<IdVoyage>
    {
        public VoyageSansTrainException(IdVoyage id) : base(id)
        {
        }
    }
}