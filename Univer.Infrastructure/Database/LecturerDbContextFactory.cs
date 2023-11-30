using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Univer.Infrastructure.Database
{
    public class LecturerDbContextFactory : IDesignTimeDbContextFactory<LecturerDbContext>
    {
        public LecturerDbContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<LecturerDbContext>().UseSqlServer(connectionString);

            return new LecturerDbContext(optionsBuilder.Options);

        }
    }
}
