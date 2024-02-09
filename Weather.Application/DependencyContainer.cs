using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Application.Ports.Primary;
using Weather.Application.UseCases;

namespace Weather.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplication(
          this IServiceCollection services)
        {

            services.AddScoped<ICheckInformationPrimaryPort, CheckInformationApplication>();


            return services;
        }
    }
}
