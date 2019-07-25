using EventHandler;
using System;

namespace ConsumerHandler
{
    public class ReceivedMessage : IEvent
    {

        public DateTime OccurredEvent { get; }

        public string Message { get; }

        public ReceivedMessage(string message)
        {
            OccurredEvent = DateTime.Now;
            Message = message;
        }
    }
}
