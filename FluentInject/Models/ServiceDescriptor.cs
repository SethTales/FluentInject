using System;

namespace FluentInject.Models
{
    public class ServiceDescriptor : IServiceDescriptor
    {
        public ServiceDescriptor(Type implementationType, ServiceLifetime serviceLifetime)
        {
            ImplementationType = implementationType;
            ServiceLifetime = serviceLifetime;
        }
        
        public ServiceDescriptor(ServiceLifetime serviceLifetime, Func<object> activatorFunc)
        {
            ServiceLifetime = serviceLifetime;
            ActivatorFunc = activatorFunc;
        }

        public Type ImplementationType { get; }
        public ServiceLifetime ServiceLifetime { get; }
        public Func<object> ActivatorFunc { get; }
    }
}
