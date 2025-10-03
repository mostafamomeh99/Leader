using APIHelper.POM;
using Application.Common.Interfaces;
using Application.Features.Commons;
using Application.Hubs;
using Infrastructure.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Services;
using Integration.Email;
using Integration.LDAB;
using Integration.SMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shared.Interfaces.Services;
using Shared.Services;
using Shared.Settings;

namespace APIHelper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "APIHelper",
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer",
                //    BearerFormat = "JWT",
                //    Description = "Input your Bearer token in this format - Bearer {your token here} to access this API",
                //});
                //c.AddSecurityRequirement(new OpenApiSecurityRequirement
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer",
                //            },
                //            Scheme = "Bearer",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,
                //        }, new List<string>()
                //    },
                //});
            });
        }
        public static void AddSharedLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            //if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseInMemoryDatabase("ApplicationDb"));
            //}
            //else
            //{
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseLazyLoadingProxies().UseSqlServer(
            //      //nabila
            //      //configuration.GetConnectionString("DefaultConnection"),
            //      connectionString,
            //       b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            //}
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
            // configuration.
            MailSettings mailSettings = new();
            configuration.Bind("MailSettings", mailSettings);
            services.AddSingleton(mailSettings);

            REDFWSSettings redfWSSettings = new();
            configuration.Bind("REDFWSSettings", redfWSSettings);
            services.AddSingleton(redfWSSettings);

            //NHCApiSettings nhcApiSettings = new();
            //configuration.Bind("NHCApiSettings", nhcApiSettings);
            //services.AddSingleton(nhcApiSettings);

            LDABSettings ldabSettings = new();
            configuration.Bind("LDABSettings", ldabSettings);
            services.AddSingleton(ldabSettings);

            AVAYAPOMSettings avayaPOMSettings = new();
            configuration.Bind("AVAYAPOMSettings", avayaPOMSettings);
            services.AddSingleton(avayaPOMSettings);

            //REDFSMSSettings redfSMSSettings = new();
            //configuration.Bind("REDFSMSSettings", redfSMSSettings);
            //services.AddSingleton(redfSMSSettings);

            VirtualPathSetting virtualPathSetting = new();
            configuration.Bind("VirtualPathSetting", virtualPathSetting);
            services.AddSingleton(virtualPathSetting);

            REDFAPISettings rEDFAPISettings = new();
            configuration.Bind("REDFAPISettings", rEDFAPISettings);
            services.AddSingleton(rEDFAPISettings);
            //JWTSettings jWTSettings = new JWTSettings();
            //configuration.Bind("JWTSettings", jWTSettings);
            //services.AddSingleton(jWTSettings);

            //ActiveDirectorySettings activeDirectorySettings = new ActiveDirectorySettings();
            //configuration.Bind("ActiveDirectorySettings", activeDirectorySettings);
            //services.AddSingleton(activeDirectorySettings);

            //services.AddTransient<IDateTimeService, DateTimeService>();
            //services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();


            services.AddTransient<IVirtualPathService, VirtualPathService>();
            services.AddTransient<IDateTimeService, DateTimeService>();

            services.AddTransient<IContextCurrentUserService, ContextCurrentUserService>();
            services.AddTransient<IGeneralOperation, GeneralOperation>();
            services.AddTransient<Shared.Interfaces.Services.IMailService, MailService>();
            services.AddTransient<ISMSService, SMSService>();
            services.AddTransient<ILDABService, LDABService>();
            // services.AddTransient<IREDFWS, Integration.REDF.REDFWS>();
            services.AddTransient<IPOMService, POMService>();
            // services.AddTransient<IREDFSMSService, Integration.REDF.REDFSMSService>();
            services.AddTransient<INotificationHubService, NotificationHub>();

            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            //services.AddTransient<ILookups, Lookups>();
            //services.AddTransient<ITickets, Tickets>();
            //services.AddTransient<ISender, Sender>();

        }
        public static void AddContextLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();


            builder.UseLazyLoadingProxies().UseSqlServer(
             //  configuration.GetConnectionString("DefaultConnection"),
             connectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName).EnableRetryOnFailure());

            var context = new ApplicationDbContext(builder.Options);
            bool appSettingTableExists = context.Database.ExecuteSqlRaw(@"
        IF EXISTS (
            SELECT 1 
            FROM INFORMATION_SCHEMA.TABLES 
            WHERE TABLE_SCHEMA = 'Lookup' AND TABLE_NAME = 'AppSetting'
        )
        SELECT 1
        ELSE
        SELECT 0
    ") == 1;

            if (appSettingTableExists)
            {
                var settings = context.AppSetting.ToList();
                var data = new Dictionary<string, string>();

                foreach (var setting in settings)
                {
                    // Create a key in the format "SectionName:KeyName"
                    var key = $"{setting.SectionName}:{setting.KeyName}";
                    configuration[key] = setting.Value;
                }
            }
        }
        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
