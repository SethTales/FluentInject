using System;
using FluentInject.Exceptions;
using FluentInject.Models;

namespace FluentInject.Extensions
{
    internal static class TypeExtensions
    {
        internal static bool IsSupportedCtorParam(this Type self)
        {
            return self.IsInterface ? 
                true :
                throw new UnsupportedConstructorParameterException(
                    $"Type {self} is not supported as an injectable constructor parameter at this time. " +
                    $"Currently supported constructor parameter types are: {SupportedConstructorParameters.GetSupportedConstructorParameterTypes()}");
        }
    }
}
