using Apselog.Application.DTOs.Request.EventoEntrega;
using Apselog.Application.DTOs.Response.EventoEntrega;

namespace Apselog.Application.UseCases.Interfaces.EventoEntrega;

public interface IAtualizarEventoEntregaUseCase
{
    Task<AtualizarEventoEntregaResponse> ExecutarAsync(AtualizarEventoEntregaRequest request);
}
