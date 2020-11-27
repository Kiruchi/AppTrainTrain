using Shared.Core.Exceptions;

namespace Reservations.Hexagon.Exceptions
{
    public class VoyageSansTrainException : NotFoundException<int>
    {
        public VoyageSansTrainException(int id) : base(id)
        {
        }
    }
}