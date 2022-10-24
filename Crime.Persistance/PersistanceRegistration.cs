using Crime.Persistence.MongoConfiguration;
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
            return services;
        }
    }
}