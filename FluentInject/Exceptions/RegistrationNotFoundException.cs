using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FluentInjectTests")]
namespace FluentInject.Exceptions
{
    internal class RegistrationNotFoundException : Exception
    {
        internal RegistrationNotFoundException(string message) : base(message)
        {
        }
    }
}
