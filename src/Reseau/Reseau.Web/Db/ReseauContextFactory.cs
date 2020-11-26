using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Reseau.Web.Db
{
    public class ReseauContextFactory : IDesignTimeDbContextFactory<ReseauContext>
    {
        public ReseauContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(
                    Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "../../Application.Web"
                    ))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("Reseau");
            
            var optionsBuilder = new DbContextOptionsBuilder<ReseauContext>();
            optionsBuilder.UseSqlServer(connectionString);
            
            return new ReseauContext(optionsBuilder.Options);
        }
    }
}