using System;
using System.Runtime.CompilerServices;
using FluentInject.Models;

[assembly: InternalsVisibleTo("FluentInjectTests")]
namespace FluentInject.Exceptions
{
    internal class UnsupportedConstructorParameterException : Exception
    {
        internal UnsupportedConstructorParameterException(string message) : base(message)
        {
        }

        internal static string GetSupportedConstructorParameters()
        {
            return string.Join(", ", Enum.GetNames(typeof(SupportedConstructorParameters)));
        }
    }
}
