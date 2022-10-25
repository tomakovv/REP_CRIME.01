using LawEnforcement.Application.Interfaces;
using LawEnforcement.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LawEnforcement.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ILawEnforcementTeamService, LawEnforcementTeamService>();
            return services;
        }
    }
}