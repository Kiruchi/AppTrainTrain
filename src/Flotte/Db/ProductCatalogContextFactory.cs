using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Flotte.Web.Db
{
    public class ProductCatalogContextFactory : IDesignTimeDbContextFactory<FlotteContext>
    {
        public FlotteContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Flotte");
            var optionsBuilder = new DbContextOptionsBuilder<FlotteContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            return new FlotteContext(optionsBuilder.Options);
        }
    }
}