using Shared.Web;
using Shared.Web.Registration;

namespace Application.Web
{
    public static class BoundedContexts
    {
        public static IBoundedContextRegistration RegisterAllBoundedContexts(IServiceContainer serviceContainer) =>
            new CompositeBoundedContextRegistration(
                new Flotte.Web.ContainerRegistration(serviceContainer),
                new Reseau.Web.ContainerRegistration(serviceContainer),
                new Reservations.Web.ContainerRegistration(serviceContainer));
    }
}