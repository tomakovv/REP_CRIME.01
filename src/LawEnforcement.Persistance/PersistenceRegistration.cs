using LawEnforcement.Application.Interfaces;
using LawEnforcement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LawEnforcement.Persistence
{
    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LawEnforcementContext>(options =>
            options.UseSqlServer(configuration["LawEnforcementConnectionString"]), ServiceLifetime.Transient, ServiceLifetime.Transient);
            services.AddTransient<ILawEnforcementTeamRepository, LawEnforcementTeamRepository>();
            return services;
        }
    }
}