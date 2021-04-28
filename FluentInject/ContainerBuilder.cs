using System;
using FluentInject.Models;

namespace FluentInject
{
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly ITypeRegistrations _typeRegistrations;
        
        public ContainerBuilder()
        {
            _typeRegistrations = new TypeRegistrations();
        }

        public IContainerBuilder Register<TIn, TOut>(ServiceLifetime serviceLifetime = ServiceLifetime.Container)
        {
            _typeRegistrations.Add(typeof(TIn), new ServiceDescriptor(typeof(TOut), serviceLifetime));
            return this;
        }

        public IContainerBuilder Register<TIn, TOut>(Func<TOut> activatorFunc, ServiceLifetime serviceLifetime = ServiceLifetime.Container)
        {
            throw new NotImplementedException();
        }

        public IContainer Build()
        {
            return new Container(_typeRegistrations);
        }
    }
}
