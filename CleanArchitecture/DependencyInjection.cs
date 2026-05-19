using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;

namespace CleanArchitecture.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            services.AddApplication()
                .AddInfrastructure();
            return services;
        }
    }
}
