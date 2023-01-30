using BusinessObjects.DTO;
using EmployeeConsumerSignalRRecieverClient;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace EmployeeConsumerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //TODO :Signal Client not able to connect with the host. Host refusing the connection

            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = builder.Configuration;

            builder.Services.RegisterServices(configuration);

            var app = builder.Build();

            app.MapGet("/", () => "Employee Consumer SignalR Reciever Service Starting");

            app.Run();
        }
    }
}
