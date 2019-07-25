using System.Threading;
using System.Threading.Tasks;
using EventHandler;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ConsumerHandler
{
    internal class ConsumerService : IHostedService
    {
        private readonly ILogger<ConsumerService> _logger;
        private readonly IApplicationLifetime _appLifetime;
        
        public ConsumerService(ILogger<ConsumerService> logger, IApplicationLifetime appLifetime)
        {
            _logger = logger;
            _appLifetime = appLifetime;
        }

        public void Processing()
        {
            for (int i = 1; i <= 10; i++)
            {
                var msg = $"Execute: {i}";
                _logger.LogInformation(msg);
                Events.Raise(new ReceivedMessage(msg));
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(OnStarted);
            _appLifetime.ApplicationStopping.Register(OnStopping);
            _appLifetime.ApplicationStopped.Register(OnStopped);
            
            _logger.LogInformation("Start Hosted Server");

            Processing();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop Hosted Server");
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            _logger.LogInformation("OnStarted has been called.");
        }

        private void OnStopping()
        {
            _logger.LogInformation("OnStopping has been called.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("OnStopped has been called.");
        }
    }
}