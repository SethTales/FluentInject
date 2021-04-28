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

        public Type ImplementationType { get; }
        public ServiceLifetime ServiceLifetime { get; }
    }
}
