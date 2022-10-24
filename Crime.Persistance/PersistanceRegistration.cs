using Crime.Persistence.MongoConfiguration;
using Crime.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crime.Persistence
{
    public static class PersistanceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new ServerConfig();
            configuration.Bind(config);
            var crimeContext = new CrimeContext(config.MongoDB);
            var repo = new CrimeEventsRepository(crimeContext);
            services.AddSingleton<CrimeEventsRepository>(repo);
            return services;
        }
    }
}