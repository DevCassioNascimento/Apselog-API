using Apselog.Application.DTOs.Request;
using Apselog.Application.DTOs.Response.Entrega;

namespace Apselog.Application.UseCases.Interfaces.Entrega;

public interface IAtualizarEntregaUseCase
{
    Task<AtualizarEntregaResponse> ExecutarAsync(AtualizarEntregaRequest request);
}
