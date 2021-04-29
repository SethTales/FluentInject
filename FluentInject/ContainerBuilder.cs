using System;
using FluentInject.Models;

namespace FluentInject
{
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly ITypeRegistrations _typeRegistrations;
        
        private ContainerBuilder()
        {
            _typeRegistrations = new TypeRegistrations();
        }

        public static IContainerBuilder New()
        {
            return new ContainerBuilder();
        }

        public IContainerBuilder Register<TIn, TOut>(ServiceLifetime serviceLifetime = ServiceLifetime.Container)
        {
            _typeRegistrations.Add(typeof(TIn), new ServiceDescriptor(typeof(TOut), serviceLifetime));
            return this;
        }

        public IContainerBuilder Register<TIn>(Func<object> activatorFunc, ServiceLifetime serviceLifetime = ServiceLifetime.Container)
        {
            _typeRegistrations.Add(typeof(TIn), new ServiceDescriptor(serviceLifetime, activatorFunc));
            return this;
        }

        public IContainer Build()
        {
            return new Container(_typeRegistrations);
        }
    }
}
