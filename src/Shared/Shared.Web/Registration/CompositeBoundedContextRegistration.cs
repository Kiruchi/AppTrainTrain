using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Web.Registration
{
    public class CompositeBoundedContextRegistration : IBoundedContextRegistration
    {
        private readonly IBoundedContextRegistration[] _registrations;

        public CompositeBoundedContextRegistration(params IBoundedContextRegistration[] registrations)
        {
            _registrations = registrations;
        }
        
        public void RegisterServices()
        {
            foreach (var registration in _registrations) 
                registration.RegisterServices();
        }

        public void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            foreach (var hexagonRegistration in _registrations) 
                hexagonRegistration.RegisterDbContext(services, configuration);
        }
    }
}