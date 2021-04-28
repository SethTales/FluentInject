using System;

namespace FluentInject.Models
{
    internal class SupportedConstructorParameters
    {
        internal static string GetSupportedConstructorParameterTypes()
        {
            return string.Join(", ", Enum.GetNames(typeof(SupportedTypes)));
        }

        private enum SupportedTypes
        {
            Interface
        }

    }

}
