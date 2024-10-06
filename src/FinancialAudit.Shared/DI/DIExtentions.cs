using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FinancialAudit.Shared.DI;
public static class DIExtentions
{
    public static IServiceCollection AddAttributedServices(this IServiceCollection services, Assembly assembly)
    {
        var classes = assembly.GetExportedTypes();
        foreach (var c in classes)
        {
            AddIfSingleton(services, c);
            AddIfScoped(services, c);
            AddIfTransient(services, c);
        }

        return services;
    }

    private static void AddIfSingleton(IServiceCollection services, Type c)
    {
        var att = c.GetCustomAttribute<SingletonAttribute>();
        if (att is null)
            return;

        services.AddSingleton(att.AsType, c);
    }

    private static void AddIfScoped(IServiceCollection services, Type c)
    {
        var att = c.GetCustomAttribute<ScopedAttribute>();
        if (att is null)
            return;

        services.AddScoped(att.AsType, c);
    }

    private static void AddIfTransient(IServiceCollection services, Type c)
    {
        var att = c.GetCustomAttribute<TransientAttribute>();
        if (att is null)
            return;

        services.AddTransient(att.AsType, c);
    }

}
