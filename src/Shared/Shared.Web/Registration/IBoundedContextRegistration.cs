using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Web.Registration
{
    public interface IBoundedContextRegistration
    {
        void RegisterServices();

        void RegisterDbContext(IServiceCollection services, IConfiguration configuration);
    }
}