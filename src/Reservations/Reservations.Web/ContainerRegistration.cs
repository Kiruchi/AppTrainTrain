using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservations.Hexagon.PrimaryPorts;
using Reservations.Hexagon.SecondaryPorts;
using Reservations.Hexagon.UseCases;
using Reservations.Infra;
using Reservations.Infra.Db;
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
            ServiceContainer.Register<IReservationRepository, ReservationsRepository>();
            ServiceContainer.Register<IReservationNotifieur, DummyReservationNotifieur>();
        }

        public override void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReservationsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Reservations")));
        }
    }
}