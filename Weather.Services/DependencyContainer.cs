using Microsoft.Extensions.DependencyInjection;
using Weather.Domain.Interfaces;
using Weather.Services.Services;

namespace Weather.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddServices(
           this IServiceCollection services)
        {
            services.AddScoped<ICheckNewsInformation, NewsService>();
            services.AddScoped<ICheckWeatherInformation, WeatherService>();
       

            return services;
        }
    }
}
