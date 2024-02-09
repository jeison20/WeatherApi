using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.Application.Ports.Secundary;
using Weather.EFCore.DataContext;
using Weather.EFCore.Implements;

namespace Weather.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistence(
          this IServiceCollection services, IConfiguration configuration,
          string connectionStringName)
        {
            string? conn = configuration.GetConnectionString(connectionStringName);
            
            services.AddDbContext<WeatherContext>(options =>
                    options.UseSqlServer(conn));


            services.AddScoped<ICheckInformationSecundaryPort, CreateRecordSecundaryPort>();

            return services;
        }
    }
}
