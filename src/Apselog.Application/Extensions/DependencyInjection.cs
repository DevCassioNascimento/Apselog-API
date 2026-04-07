using Microsoft.Extensions.DependencyInjection;
using Apselog.Application.UseCases.Entrega;
using Apselog.Application.UseCases;
using Apselog.Application.UseCases.Interfaces;
using Apselog.Application.UseCases.Interfaces.Entrega;

namespace Apselog.Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICriarUserUseCase, CriarUserUseCase>();
        services.AddScoped<IAtualizarUserUseCase, AtualizarUserUseCase>();
        services.AddScoped<IDeletarUserUseCase, DeletarUserUseCase>();
        services.AddScoped<ICriarEntregaUseCase, CriarEntregaUseCase>();
        services.AddScoped<IAtualizarEntregaUseCase, AtualizarEntregaUseCase>();
        services.AddScoped<IListarEntregaUseCase, ListarEntregaUseCase>();
        services.AddScoped<IExcluirEntregaUseCase, ExcluirEntregaUseCase>();

        return services;
    }
}
