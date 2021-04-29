# FluentInject
## About the Project

FluentInject is a small dependency injection framework for .NET. The goals of this project are to learn about how DI frameworks work, and implement a limited subset of a DI framework such as AutoFac or IServiceProvider.

## Features

- registrations of interfaces mapped to classes
- injecting interfaces as constructor parameters
- injecting other types using an activator func
- yes, this is a very limited feature set - more to come in the future

## Future Plans

- allow the resolution of a class without a corresponding interface. This is useful if you have a DTO that only has properties that you want to be able to resolve without defining an interface
- implement service scoping
- allow loading of types from assemblies
- allow FluentInject to substitue for IServiceProvider for ASP.NET Core web applications

## Usage

Given the following interfaces and classes:
```
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
{}
```

Create a new container builder, register your dependencies, and call `Build()` to return an instance of `IContainer`:

```
 var container = ContainerBuilder
                .New()
                .Register<A, ClassA>()
                .Register<B, ClassB>()
                .Build();
```

Or provide an activator func:

```
var container = ContainerBuilder
                .New()
                .Register<A>(() => new A(new B()))
                .Build();
```

Then to resolve the type you want, simply call the `IContainer.Resolve<T>` method:

```
var resolvedService = container.Resolve<A>();
```

## License

The MIT License (MIT)
Copyright 2021 Seth Taylor

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
