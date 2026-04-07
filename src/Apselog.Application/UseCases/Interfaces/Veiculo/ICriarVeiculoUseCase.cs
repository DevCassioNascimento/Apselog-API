using Apselog.Application.DTOs.Request.Veiculo;
using Apselog.Application.DTOs.Response.Veiculo;

namespace Apselog.Application.UseCases.Interfaces.Veiculo;

public interface ICriarVeiculoUseCase
{
    Task<CriarVeiculoResponse> ExecutarAsync(CriarVeiculoRequest request);
}
