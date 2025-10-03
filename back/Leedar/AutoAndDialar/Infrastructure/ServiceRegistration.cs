
using Domain.Entities.Identity;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Settings;
using System;
using System.Net;

namespace Infrastructure
{
    public static class ServiceRegistration
    {
        public static  void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //nabila
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(
                  //nabila
                   //configuration.GetConnectionString("DefaultConnection"),
                  connectionString,
                   b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName).EnableRetryOnFailure()));
            }
            //nabila
            //using (var scope = services.BuildServiceProvider().CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //    var settings = await context.AppSetting.ToListAsync();


            //    foreach (var setting in settings)
            //    {
            //        // Create a key in the format "SectionName:KeyName"
            //        var key = $"{setting.SectionName}:{setting.KeyName}";
            //        configuration[key] = setting.Value;
            //    }
            //}
            //NHCApiSettings nhcApiSettings = new();
            //configuration.Bind("NHCApiSettings", nhcApiSettings);
            //services.AddSingleton(nhcApiSettings);

            //end
            //services.AddTransient<IRefreshTokenService, RefreshTokenService>();

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }
        //public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        //{
        //    HttpStatusCode status;
        //    string message;

        //    services.AddIdentity<User, Role>(options =>
        //    {
        //        options.SignIn.RequireConfirmedAccount = true;

        //        options.Password.RequireNonAlphanumeric = false;
        //        options.Password.RequireDigit = true;
        //        options.Password.RequiredLength = 8;
        //        options.Password.RequireNonAlphanumeric = false;
        //        options.Password.RequireUppercase = false;
        //        options.Password.RequireLowercase = false;

        //    }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();
        //}
        }
}
