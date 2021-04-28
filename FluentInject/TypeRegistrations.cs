using System;
using System.Collections.Generic;
using FluentInject.Exceptions;
using FluentInject.Models;

namespace FluentInject
{
    internal class TypeRegistrations : ITypeRegistrations
    {
        private static readonly Dictionary<Type, IServiceDescriptor> TypeMappings = new Dictionary<Type, IServiceDescriptor>();

        void ITypeRegistrations.Add(Type type, IServiceDescriptor serviceDescriptor)
        {
            TypeMappings.Add(type, serviceDescriptor);
        }

        IServiceDescriptor ITypeRegistrations.Get(Type type)
        {
            return TypeMappings.TryGetValue(type, out var serviceDescriptor) ?
                serviceDescriptor :
                throw new RegistrationNotFoundException($"No registration was found for type {type}. Did you call ContainerBuilder.Register<TIn, TOut>?");
        }
    }
}
