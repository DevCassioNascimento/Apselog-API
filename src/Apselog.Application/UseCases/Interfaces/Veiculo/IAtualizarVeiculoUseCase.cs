using Apselog.Application.DTOs.Request.Veiculo;
using Apselog.Application.DTOs.Response.Veiculo;

namespace Apselog.Application.UseCases.Interfaces.Veiculo;

public interface IAtualizarVeiculoUseCase
{
    Task<AtualizarVeiculoResponse> ExecutarAsync(AtualizarVeiculoRequest request);
}
