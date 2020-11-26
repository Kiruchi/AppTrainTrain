using Shared.Web;
using Shared.Web.Registration;
using Voyages.Hexagon.PrimaryPorts;
using Voyages.Hexagon.UseCases;
using Voyages.Infra;

namespace Voyages.Web
{
    public class ContainerRegistration : BoundedContextRegistration
    {
        public ContainerRegistration(IServiceContainer serviceContainer)
            : base(serviceContainer)
        {
        }

        public override void RegisterServices()
        {
            // ports primaires
            ServiceContainer.Register<IGetVoyageUseCase, GetVoyageUseCase>();
            
            // ports secondaires
            ServiceContainer.Register<IVoyageRepository, DummyVoyagesRepository>();
        }
    }
}