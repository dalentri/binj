using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace Binj.Cli.Support;

public sealed class TypeRegistrar : ITypeRegistrar
{
    private readonly IServiceProvider _provider;

    // Update constructor to take IServiceProvider
    public TypeRegistrar(IServiceProvider provider) => _provider = provider;

    public ITypeResolver Build() => new TypeResolver(_provider);

    // These can stay empty because the host already registered everything
    public void Register(Type service, Type implementation) { }

    public void RegisterInstance(Type service, object implementation) { }

    public void RegisterLazy(Type service, Func<object> factory) { }
}

public sealed class TypeResolver : ITypeResolver
{
    private readonly IServiceProvider _provider;

    public TypeResolver(IServiceProvider provider) => _provider = provider;

    public object? Resolve(Type? type)
    {
        if (type == null)
            return null;

        // Try to get it from the DI container first
        // If it's not there, manually instantiate it and inject dependencies
        return _provider.GetService(type) ?? ActivatorUtilities.CreateInstance(_provider, type);
    }
}
