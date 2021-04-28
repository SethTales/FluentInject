using System;

namespace FluentInject
{
    public interface IContainer
    {
        T Resolve<T>();
    }
}
