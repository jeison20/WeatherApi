using Microsoft.Extensions.DependencyInjection;
using Weather.Domain.Services;

namespace Weather.Domain
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDomain(
         this IServiceCollection services)
        {

            services.AddScoped<CheckInformationService>();
            

            return services;
        }
    }
}
