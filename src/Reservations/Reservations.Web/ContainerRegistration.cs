using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Web;
using Shared.Web.Registration;

namespace Reservations.Web
{
    public class ContainerRegistration : BoundedContextRegistration
    {
        public ContainerRegistration(IContainer container)
            : base(container)
        {
        }
    }
}