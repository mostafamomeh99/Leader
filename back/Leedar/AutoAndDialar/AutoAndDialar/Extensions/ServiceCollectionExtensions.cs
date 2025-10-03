using Application.Common.Interfaces;
using Application.Features.Commons;
using Application.Hubs;
using AutoAndDialar.POM;
using Domain.Entities.Identity;
using Infrastructure.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Services;
using Integration.LDAB;
using Integration.SMS;
using Localization;
using MailKit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Shared.Globalization;
using Shared.Interfaces;
using Shared.Interfaces.Services;
using Shared.Services;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AutoAndDialar.Extensions
{
    public static class ServiceCollectionExtensions
    {
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
            //services.AddTransient<Shared.Interfaces.Services.IMailService, MailService>();
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
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
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

        //    //EncryptionHelper encryptionHelper = new EncryptionHelper();
        //    //var DefaultConnection = encryptionHelper.Decrypt(configuration.GetConnectionString("DefaultConnection"));
        //    //var logsConnection = encryptionHelper.Decrypt(configuration.GetConnectionString("logsConnection"));

        //    //services.AddDbContext<ApplicationDbContext>(options =>
        //    //    options.UseSqlServer(
        //    //       DefaultConnection,
        //    //       b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        //    // services.AddDbContext<LogsDbContext>(options =>
        //    //options.UseSqlServer(
        //    //    logsConnection,
        //    //   b => b.MigrationsAssembly(typeof(LogsDbContext).Assembly.FullName)));

        //    // }






        //    using (var scope = services.BuildServiceProvider().CreateScope())
        //    {
        //        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //        var isHasSettingToUpdateMigration = false;
        //        if (configuration.GetValue<bool>("API_CONFIG:UpdateMigration"))
        //        {
        //            isHasSettingToUpdateMigration = true;
        //            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //            dbContext.Database.Migrate();
        //        }

        //        var settings = await context.AppSetting.ToListAsync();


        //        foreach (var setting in settings)
        //        {
        //            // Create a key in the format "SectionName:KeyName"
        //            var key = $"{setting.SectionName}:{setting.KeyName}";
        //            configuration[key] = setting.Value;
        //        }
        //        if (configuration.GetValue<bool>("API_CONFIG:UpdateMigration") && !isHasSettingToUpdateMigration)
        //        {
        //            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //            dbContext.Database.Migrate();
        //        }



        //    }


        //    services.BindAndRegister<MailSettings>(configuration, "MailSettings");
        //    services.BindAndRegister<SMSSettings>(configuration, "SMSSettings");
        //    services.BindAndRegister<GoogleRecaptcha>(configuration, "GoogleRecaptcha");
        //    services.BindAndRegister<OtpSettings>(configuration, "OtpSettings");
        //    services.BindAndRegister<CacheSettings>(configuration, "CacheSettings");
        //    services.BindAndRegister<JWTSettings>(configuration, "JWTSettings");
        //    services.BindAndRegister<ActiveDirectorySettings>(configuration, "ActiveDirectorySettings");
        //    services.BindAndRegister<VirtualPathSettingDto>(configuration, "VirtualPathSetting");






        //    services.AddTransient<IDateTimeService, DateTimeService>();
        //    services.AddTransient<IEmailService, EmailService>();
        //    services.AddSingleton<ISMSService, SMSService>();
        //    services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
        //    services.AddSingleton<IVirtualPathService, VirtualPathService>();
        //    services.AddSingleton<IConnectionStringResolver, DefaultConnectionStringResolver>();
        //    services.AddSingleton<IGoogleRecaptchaService, GoogleRecaptchaService>();



        //    await System.Threading.Tasks.Task.CompletedTask;
        //}
        public static void AddIdentityLayer(this IServiceCollection services, IConfiguration configuration)
        {
            HttpStatusCode status;
            string message;

            services.AddIdentity<User, Role>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;

                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                // set schema here
            })
                .AddCookie(config =>
                {

                    //config cookie
                });

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.RequireHttpsMetadata = false;
            //        o.SaveToken = true;
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            ValidIssuer = configuration["JWTSettings:Issuer"],
            //            ValidAudience = configuration["JWTSettings:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:AccessTokenSecret"]))
            //        };
            //        o.Events = new JwtBearerEvents()
            //        {
            //            OnAuthenticationFailed = context =>
            //            {
            //                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            //                {
            //                    message = SharedResource.TokenExpired;
            //                }
            //                else
            //                {
            //                    message = SharedResource.UnauthorizeMessage;
            //                }
            //                status = HttpStatusCode.Unauthorized;
            //                var result = JsonConvert.SerializeObject(new { error = message });
            //                context.Response.ContentType = "application/json";
            //                context.Response.StatusCode = (int)status;
            //                return context.Response.WriteAsync(result);
            //            },
            //            OnChallenge = context =>
            //            {
            //                message = SharedResource.UnauthorizeMessage;
            //                status = HttpStatusCode.Unauthorized;
            //                var result = JsonConvert.SerializeObject(new { error = message });
            //                context.Response.ContentType = "application/json";
            //                context.Response.StatusCode = (int)status;
            //                return context.Response.WriteAsync(result);
            //            },
            //            OnForbidden = context =>
            //            {
            //                message = SharedResource.Forbidden;
            //                status = HttpStatusCode.Forbidden;
            //                var result = JsonConvert.SerializeObject(new { error = message });
            //                context.Response.ContentType = "application/json";
            //                context.Response.StatusCode = (int)status;
            //                return context.Response.WriteAsync(result);
            //            },
            //        };
            //    });
        }

        public static void AddMultiLingualSupport(this IServiceCollection services)
        {
            #region Registering ResourcesPath

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            #endregion Registering ResourcesPath

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                     new CultureInfo("en"),
                     new CultureInfo("ar")};
                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }
        private static void BindAndRegister<T>(this IServiceCollection services, IConfiguration configuration, string sectionName) where T : class, new()
        {
            var settings = new T();
            configuration.Bind(sectionName, settings);
            services.AddSingleton(settings);
        }
        public static void UseMultiLingualFeature(this IApplicationBuilder app)
        {
            app.UseRequestLocalization(app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
        }
    }
}
