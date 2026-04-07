using Apselog.Application.DTOs.Request.Veiculo;
using Apselog.Application.DTOs.Response.Veiculo;

namespace Apselog.Application.UseCases.Interfaces.Veiculo;

public interface IExcluirVeiculoUseCase
{
    Task<ExcluirVeiculoResponse> ExecutarAsync(ExcluirVeiculoRequest request);
}
