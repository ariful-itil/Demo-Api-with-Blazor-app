using Sms.Data;
using Sms.Models;
using Sms.Logger;
using Sms.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Sms.Services;
using Sms.Interfaces;

namespace Sms.Worker
{
    public class WorkerService : BackgroundService
    {
        private readonly ICustomLogger log;
        private readonly IServiceProvider provider;
        private readonly ISmsSender sender;
        private readonly IExpirationCheck ExpCheck;
        public WorkerService(ICustomLogger _log, IServiceProvider _provider)
        {
            log= _log;
            provider= _provider;
            var scope=provider.CreateScope();
            sender = scope.ServiceProvider.GetRequiredService<ISmsSender>();
            ExpCheck = scope.ServiceProvider.GetRequiredService<IExpirationCheck>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var Status = "";
                try
                {
                    Status = await sender.SmsSend();
                    //Console.WriteLine($"Message send: {Status}");
                    await ExpCheck.UpdatePaymentExpiration();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                await Task.Delay(100, stoppingToken);
            }
        }
    }
}