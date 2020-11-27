using Reservations.Hexagon.PrimaryPorts;
using Reservations.Hexagon.SecondaryPorts;
using Reservations.Hexagon.UseCases;
using Reservations.Infra;
using Shared.Web;
using Shared.Web.Registration;

namespace Reservations.Web
{
    public class ContainerRegistration : BoundedContextRegistration
    {
        public ContainerRegistration(IServiceContainer serviceContainer)
            : base(serviceContainer)
        {
        }

        public override void RegisterServices()
        {
            // Ports primaires
            ServiceContainer.Register<IReservationUseCase, ReservationUseCase>();
            
            // Ports secondaires
            ServiceContainer.Register<ITrainRepository, DummyTrainRepository>();
            ServiceContainer.Register<IReservationRepository, DummyReservationRepository>();
            ServiceContainer.Register<IReservationNotifieur, DummyReservationNotifieur>();
        }
    }
}