using System;
using System.Collections.Generic;

namespace IoC
{
    public interface IContainer
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}