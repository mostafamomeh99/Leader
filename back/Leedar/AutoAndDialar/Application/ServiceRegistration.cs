using Application.Common.Interfaces;
using Application.Features.Commons;
using Application.Features.Identity.User.Commands.Create;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            VirtualPathSetting virtualPathSetting = new();
            configuration.Bind("VirtualPathSetting", virtualPathSetting);
            services.AddSingleton(virtualPathSetting);

            // services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
           // services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IValidator<CreateNewUserCommand>, CreateNewUserCommandValidator>();
            services.AddTransient<IVirtualPathService, VirtualPathService>();
            services.AddTransient<IGeneralOperation, GeneralOperation>();
            
        }
    }
}
