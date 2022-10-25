using Crime.Application.Crime.Messaging.Receive;
using Crime.Application.Crime.Messaging_Send;
using Crime.Application.Services;
using Crime.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Crime.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<ICrimeEventsService, CrimeEventsService>();
            services.AddTransient<ICrimeEventSender, CrimeEventSender>();
            services.AddHostedService<CrimeEventAssignmentResultReceiver>();
            return services;
        }
    }
}