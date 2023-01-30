using BusinessObjects.DTO;
using Microsoft.AspNetCore.SignalR.Client;

namespace EmployeeConsumerSignalRRecieverClient.BackgroundServices
{
    public class EmployeeConsumerBackgroundService : BackgroundService
    {
        #region Declaration

        private readonly string _employeeConsumerSignalRHubUrl;
        private readonly bool _listenToSignalRBroadCasting;
        private readonly HubConnection _hubConnection;

        #endregion Declaration

        #region Constructor

        public EmployeeConsumerBackgroundService(IConfiguration configuration) 
        {
            _employeeConsumerSignalRHubUrl = configuration.GetValue<string>("EmployeeConsumerSignalRHubUrl");

            _listenToSignalRBroadCasting = configuration.GetValue<bool>("ListenToSignalRBroadCasting");

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_employeeConsumerSignalRHubUrl).Build();
        }

        #endregion Constructor

        #region Protected Methods

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                if (_listenToSignalRBroadCasting)
                {
                    await _hubConnection.StartAsync();

                    _hubConnection.On<Employee>("ReceiveEmployeeData", (incominngMessage) =>
                    {
                        //Do something with incoming data
                        Console.WriteLine(incominngMessage);
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Protected Methods
    }
}
