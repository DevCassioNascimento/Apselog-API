using Apselog.Application.DTOs.Request.EtapaChecklistEntrega;
using Apselog.Application.DTOs.Response.EtapaChecklistEntrega;

namespace Apselog.Application.UseCases.Interfaces.EtapaChecklistEntrega;

public interface IExcluirEtapaChecklistEntregaUseCase
{
    Task<ExcluirEtapaChecklistEntregaResponse> ExecutarAsync(ExcluirEtapaChecklistEntregaRequest request);
}
