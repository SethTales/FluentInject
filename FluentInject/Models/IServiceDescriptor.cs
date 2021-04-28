using System;

namespace FluentInject.Models
{
    public interface IServiceDescriptor
    {
        Type ImplementationType { get; }
        ServiceLifetime ServiceLifetime { get; }
    }
}
