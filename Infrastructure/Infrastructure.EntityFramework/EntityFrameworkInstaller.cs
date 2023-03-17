using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFramework
{
    public static class EntityFrameworkInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<DatabaseContext>(optionsBuilder
                => optionsBuilder
                    //.UseLazyLoadingProxies() // lazy loading
                    .UseSqlite(connectionString));
                    //.UseSqlServer(connectionString));

                    services.AddHealthChecks()
                        .AddDbContextCheck<DatabaseContext>();

            return services;
        }
    }
}