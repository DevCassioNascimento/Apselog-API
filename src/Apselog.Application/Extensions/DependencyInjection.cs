using Microsoft.Extensions.DependencyInjection;

namespace Apselog.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}
