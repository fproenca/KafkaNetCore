using IoC;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using EventHandler;

namespace ConsumerHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureServices(config => 
                {
                    config.AddTransient<IEventHandling<ReceivedMessage>, ReceivedMessagePersistOnDBHandler>();
                    config.AddHostedService<ConsumerService>();
                    Events.Container = new Container(config.BuildServiceProvider());

                    //Events.Raise(new ReceivedMessage("teste"));

                    //new ReceivedMessagePersistOnDBHandler(config.BuildServiceProvider().GetService<ILogger<ReceivedMessagePersistOnDBHandler>>());

                    //config.AddTransient(typeof(ReceivedMessagePersistOnDBHandler));

                    //var a = config.BuildServiceProvider().GetService<ReceivedMessagePersistOnDBHandler>();

                    //a.Handle(new ReceivedMessage("msg"));

                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddConsole();
                })
                .Build();

            host.Run();
        }
    }
}
