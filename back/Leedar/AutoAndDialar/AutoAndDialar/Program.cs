using Application;
using Application.Hubs;
using AutoAndDialar.Extensions;
using DialerSystem.Filter;
using Domain.Entities.Identity;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.FileProviders;
using Persistence.Seeds;
using Quartz;
using Quartz.Simpl;
using Serilog;
using Shared.Globalization;
using System.Globalization;
using static Org.BouncyCastle.Math.EC.ECCurve;

var builder = WebApplication.CreateBuilder(args);
// 
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// تهيئة Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();





// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(RequestAuthenticationFilter));
});
builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
              
           .AddDataAnnotationsLocalization();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Localization";
});
CultureInfo[] supportedCultures = new[]
               {
                    new CultureInfo("ar"),
                    new CultureInfo("en")
                };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
});
builder.Services.AddSession(options =>
{
   
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; 
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // مدة صلاحية الكوكيز
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.SlidingExpiration = true; // يمدد الصلاحية عند النشاط
});
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});
//test
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var safeConnStr = connectionString?.Replace(
    new System.Text.RegularExpressions.Regex(@"Password=.*?;", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
        .Match(connectionString ?? "").Value,
    "Password=******;"
);

Console.WriteLine($"[DEBUG] Connection string in use: {safeConnStr}");

builder.Services.AddRouting(o => o.LowercaseUrls = true);
builder.Services.AddHttpContextAccessor();
builder.Services.AddHealthChecks();
// services.AddMultiLingualSupport();
builder.Services.AddContextLayer(builder.Configuration);
builder.Services.AddSharedLayer(builder.Configuration);
builder.Services.AddIdentityLayer(builder.Configuration);

builder.Services.AddApplicationLayer(builder.Configuration);
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddQuartz(q =>
{
    q.UseJobFactory<MicrosoftDependencyInjectionJobFactory>();

    //var jobKey = new JobKey("GetAVAYA_POM_CallResultJob");
    //q.AddJob<GetAVAYA_POM_CallResultJob>(opts => opts.WithIdentity(jobKey));
    //q.AddTrigger(opts => opts
    //    .ForJob(jobKey)
    //    .WithIdentity("GetAVAYA_POM_CallResultJob-trigger")
    //    .WithCronSchedule("0 0/10 * * * ?"));
});

builder.Services.AddQuartzHostedService(opt => opt.WaitForJobsToComplete = true);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<Role>>();

    await DefaultUsers.SeedAsync(userManager, roleManager, context);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

    app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles")),
    RequestPath = "/StaticFiles"
});
var supportedLanguages = new[] { "en", "ar" };
var locOptions = new RequestLocalizationOptions().SetDefaultCulture("ar")
    .AddSupportedCultures(supportedLanguages)
    .AddSupportedUICultures(supportedLanguages);
app.UseRequestLocalization(locOptions);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.UseMvc();
app.UseGlobalization();
app.MapRazorPages();
// Area routes
app.MapAreaControllerRoute(
    name: "MyAreaCP",
    areaName: "CP",
    pattern: "CP/{controller=Home}/{action=Main}/{id?}");

app.MapAreaControllerRoute(
    name: "MyAreaUser",
    areaName: "User",
    pattern: "User/{controller=Home}/{action=Main}/{id?}");

app.MapAreaControllerRoute(
    name: "MyAreaDashboard",
    areaName: "Dashboard",
    pattern: "Dashboard/{controller=Home}/{action=Main}/{id?}");

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

// Razor pages
app.MapRazorPages();

// SignalR hub
app.MapHub<NotificationHub>("/NotificationHub");

app.Run();
