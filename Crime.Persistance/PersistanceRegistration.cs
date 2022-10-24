using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crime.Persistance
{
    public static class PersistanceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var Context = new DiaryContext(new MongoDBConfig(configuration));
            var repo = new SavePointsRepository(diaryContext);
            services.AddSingleton<ISavePointsRepository>(repo);
            return services;
        }
    }
}