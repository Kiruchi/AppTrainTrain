using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Reservations.Infra.Db
{

    public class ReservationContextFactory : IDesignTimeDbContextFactory<ReservationsContext>
    {
        public ReservationsContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "../../Application.Web"
                    ))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Reservations");
            var optionsBuilder = new DbContextOptionsBuilder<ReservationsContext>();
            optionsBuilder.UseSqlServer(connectionString);
        
            return new ReservationsContext(optionsBuilder.Options);
        }
    }
}