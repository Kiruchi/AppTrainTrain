using Flotte.Web.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Web;
using Shared.Web.Registration;

namespace Flotte.Web
{
    public class ContainerRegistration : BoundedContextRegistration
    {
        public ContainerRegistration(IServiceContainer serviceContainer)
            : base(serviceContainer)
        {
        }

        public override void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FlotteContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Flotte")));
        }
    }
}