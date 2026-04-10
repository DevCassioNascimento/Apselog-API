using Apselog.Application.DTOs.Request.EventoEntrega;
using Apselog.Application.DTOs.Response.EventoEntrega;

namespace Apselog.Application.UseCases.Interfaces.EventoEntrega;

public interface IExcluirEventoEntregaUseCase
{
    Task<ExcluirEventoEntregaResponse> ExecutarAsync(ExcluirEventoEntregaRequest request);
}
