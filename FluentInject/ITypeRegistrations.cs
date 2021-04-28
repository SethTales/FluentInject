using System;
using FluentInject.Models;

namespace FluentInject
{
    internal interface ITypeRegistrations
    {
        void Add(Type type, IServiceDescriptor serviceDescriptor);
        IServiceDescriptor Get(Type type);
    }
}
