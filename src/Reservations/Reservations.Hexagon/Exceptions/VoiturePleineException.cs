using Shared.Core.Exceptions;

namespace Reservations.Hexagon.Exceptions
{
    public class VoiturePleineException : DomainException
    {
        public VoiturePleineException(NumeroVoiture numeroVoiture)
        {
            NumeroVoiture = numeroVoiture;
        }

        public NumeroVoiture NumeroVoiture { get; }
    }
}