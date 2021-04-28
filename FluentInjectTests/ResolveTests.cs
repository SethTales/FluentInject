using FluentInject;
using FluentInject.Exceptions;
using NUnit.Framework;

namespace FluentInjectTests
{
    public class Tests
    {
        [Test]
        public void GivenAClassWithOnlyDefaultCtor_WhenResolved_ThenClassIsOfExpectedType()
        {
            var container = new ContainerBuilder()
                .Register<ISimplePocoInterface, SimplePoco>()
                .Build();

            var resolvedService = container.Resolve<ISimplePocoInterface>();

            Assert.AreEqual(typeof(SimplePoco), resolvedService.GetType());
        }


        [Test]
        public void NestedObjectDependencies()
        {
            var container = new ContainerBuilder()
                .Register<A, ClassA>()
                .Register<B, ClassB>()
                .Register<C, ClassC>()
                .Register<D, ClassD>()
                .Build();

            var resolvedService = container.Resolve<A>();

            Assert.AreEqual(typeof(ClassA), resolvedService.GetType());
        }

        [Test]
        public void GivenAnUnsupportedConstructorParameter_WhenTypeIsResolved_UnsupportedConstructorParameterExceptionIsThrown()
        {
            var container = new ContainerBuilder()
                .Register<D, ClassD>()
                .Register<E, ClassE>()
                .Build();

            Assert.Throws<UnsupportedConstructorParameterException>(() => container.Resolve<E>());
        }

        [Test]
        public void GivenAnTypeThatHasNotBeenRegistered_WhenTypeIsResolved_RegistrationNotFoundExceptionIsThrown()
        {
            var container = new ContainerBuilder()
                .Register<A, ClassA>()
                .Build();

            Assert.Throws<RegistrationNotFoundException>(() => container.Resolve<B>());
        }

    }

    public class SimplePoco : ISimplePocoInterface
    {

    }

    public interface ISimplePocoInterface
    {

    }

    public interface A { }
    public class ClassA : A
    {
        private readonly B _b;
        public ClassA(B b)
        {
            _b = b;
        }
    }

    public interface B { }
    public class ClassB : B
    {
        private readonly C _c;
        private readonly D _d;
        public ClassB(C c, D d)
        {
            _c = c;
            _d = d;
        }
    }

    public interface C { }
    public class ClassC : C { }

    public interface D { }
    public class ClassD : D { }

    public interface E { }
    public class ClassE : E
    {
        private readonly ClassD _classD;
        public ClassE(ClassD classD)
        {
            _classD = classD;
        }
    }
}