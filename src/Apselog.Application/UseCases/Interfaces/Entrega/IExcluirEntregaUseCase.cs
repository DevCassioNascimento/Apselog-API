using Apselog.Application.DTOs.Request;
using Apselog.Application.DTOs.Response.Entrega;

namespace Apselog.Application.UseCases.Interfaces.Entrega;

public interface IExcluirEntregaUseCase
{
    Task<ExcluirEntregaResponse> ExecutarAsync(ExcluirEntregaRequest request);
}
