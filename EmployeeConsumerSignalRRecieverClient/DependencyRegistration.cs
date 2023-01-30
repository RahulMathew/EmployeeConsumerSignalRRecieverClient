using EmployeeConsumerSignalRRecieverClient.BackgroundServices;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeConsumerSignalRRecieverClient
{
    public static class DependencyRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSignalR();

            services.AddHostedService<EmployeeConsumerBackgroundService>();

            return services;
        }
    }
}
