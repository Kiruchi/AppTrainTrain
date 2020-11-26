using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reseau.Web.Db;
using Shared.Web;
using Shared.Web.Registration;

namespace Reseau.Web
{
    public class ContainerRegistration : BoundedContextRegistration
    {
        public ContainerRegistration(IServiceContainer serviceContainer)
            : base(serviceContainer)
        {
        }

        public override void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReseauContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Reseau")));
        }
    }
}