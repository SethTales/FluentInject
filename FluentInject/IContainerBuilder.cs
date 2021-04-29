
using System;
using FluentInject.Models;

namespace FluentInject
{
    public interface IContainerBuilder
    {
        IContainerBuilder Register<TIn, TOut>(ServiceLifetime serviceLifetime = ServiceLifetime.Container);

        IContainerBuilder Register<TIn>(Func<object> activatorFunc, ServiceLifetime serviceLifetime = ServiceLifetime.Container);

        IContainer Build();
    }
}
