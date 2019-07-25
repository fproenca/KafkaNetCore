namespace EventHandler
{
    public interface IEventHandling<T> where T : IEvent
    {
        void Handle(T args);
    }
}