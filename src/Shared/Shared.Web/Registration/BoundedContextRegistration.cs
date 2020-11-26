using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Web.Registration
{
    public abstract class BoundedContextRegistration : IBoundedContextRegistration
    {
        protected IServiceContainer ServiceContainer { get; }

        protected BoundedContextRegistration(IServiceContainer serviceContainer)
        {
            ServiceContainer = serviceContainer;
        }

        public virtual void RegisterServices()
        {
        }

        public virtual void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}