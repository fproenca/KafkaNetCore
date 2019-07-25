using EventHandler;
using Microsoft.Extensions.Logging;

namespace ConsumerHandler
{
    public class ReceivedMessagePersistOnDBHandler : IEventHandling<ReceivedMessage>
    {
        private readonly ILogger<ReceivedMessagePersistOnDBHandler> _logger;

        public ReceivedMessagePersistOnDBHandler(ILogger<ReceivedMessagePersistOnDBHandler> logger)
        {
            _logger = logger;
        }

        public void Handle(ReceivedMessage args)
        {
            _logger.LogInformation($"Message Handler, Message: {args.Message}, Event Date: {args.OccurredEvent}");
        }
    }
}
