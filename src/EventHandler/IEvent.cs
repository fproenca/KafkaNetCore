using System;

namespace EventHandler
{
    public interface IEvent
    {
        DateTime OccurredEvent { get; }
    }
}