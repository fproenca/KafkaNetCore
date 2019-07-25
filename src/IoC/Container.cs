using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace IoC
{
    public class Container : IContainer
    {
        private readonly IServiceProvider _serviceProvider;

        public Container(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
    }
}
