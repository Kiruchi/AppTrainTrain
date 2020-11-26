using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Web.Registration
{
    public abstract class BoundedContextRegistration : IBoundedContextRegistration
    {
        protected IContainer Container { get; }

        protected BoundedContextRegistration(IContainer container)
        {
            Container = container;
        }

        public virtual void RegisterServices()
        {
        }

        public virtual void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}