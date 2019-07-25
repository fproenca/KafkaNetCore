using IoC;

namespace EventHandler
{
    public static class Events
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IEvent
        {
            if (Container != null)
            {
                foreach (var handle in Container.GetServices(typeof(IEventHandling<T>)))
                    ((IEventHandling<T>)handle).Handle(args);
            }
        }
    }
}
