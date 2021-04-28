using System;
using System.Linq;
using System.Reflection;
using FluentInject.Extensions;
using FluentInject.Models;

namespace FluentInject
{
    public class Container : IContainer
    {
        private readonly ITypeRegistrations _typeRegistrations;

        internal Container(ITypeRegistrations typeRegistrations)
        {
            _typeRegistrations = typeRegistrations;
        }

        public T Resolve<T>()
        {
            var implementationDescriptor = _typeRegistrations.Get(typeof(T));
            var rootNode = new Node<IServiceDescriptor>
            {
                Data = implementationDescriptor
            };
            BuildDependencyTree(implementationDescriptor, rootNode);
            ActivateDependencies(rootNode);
            return (T) rootNode.ActivatedObject;
        }

        private void BuildDependencyTree(IServiceDescriptor serviceDescriptor, Node<IServiceDescriptor> rootNode)
        {
            var ctor = GetConstructorInfo(serviceDescriptor);

            foreach (var param in ctor.GetParameters())
            {
                var type = param.ParameterType;
                if (type.IsSupportedCtorParam())
                {
                    var node =
                        new Node<IServiceDescriptor>
                        {
                            ParentNode = rootNode,
                            Data = _typeRegistrations.Get(type)
                        };
                    rootNode.ChildNodes.Add(node);

                    BuildDependencyTree(_typeRegistrations.Get(type), node);
                }
            }
        }

        private static void ActivateDependencies(Node<IServiceDescriptor> rootNode)
        {
            foreach (var node in rootNode.ChildNodes)
            {
                ActivateDependencies(node);
            }

            var ctor = GetConstructorInfo(rootNode.Data);

            rootNode.ActivatedObject = rootNode.ActivatedDependencies.Any()
                ? ctor.Invoke(rootNode.ActivatedDependencies.ToArray())
                : ctor.Invoke(null);

            rootNode.ParentNode?.ActivatedDependencies.Add(rootNode.ActivatedObject);
        }

        private static ConstructorInfo GetConstructorInfo(IServiceDescriptor serviceDescriptor)
        {
            var ctor =
                serviceDescriptor.ImplementationType.GetConstructors().FirstOrDefault() ??
                serviceDescriptor.ImplementationType.GetConstructor(Type.EmptyTypes);

            if (ctor == null)
            {
                throw new ArgumentException(
                    $"No constructor was found for type {serviceDescriptor.ImplementationType}");
            }

            return ctor;
        }
    }
}
