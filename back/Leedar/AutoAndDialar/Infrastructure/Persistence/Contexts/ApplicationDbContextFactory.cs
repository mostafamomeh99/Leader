using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContextFactory()
        {
        }

        private IConfiguration configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            Console.WriteLine(">>> Connection String = " + (connectionString ?? "NULL"));

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>().EnableSensitiveDataLogging(true);

            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                builder.UseInMemoryDatabase("ApplicationDb");
            }
            else
            {
                builder.UseLazyLoadingProxies().UseSqlServer(
                   connectionString // configuration.GetConnectionString("DefaultConnection")
                    , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            }

            return new ApplicationDbContext(builder.Options);
        }
    }
}
