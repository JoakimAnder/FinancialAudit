using Microsoft.Extensions.DependencyInjection;

namespace FinancialAudit.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
