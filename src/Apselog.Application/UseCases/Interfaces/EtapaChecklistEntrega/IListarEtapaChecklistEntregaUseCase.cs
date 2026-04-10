using Apselog.Application.DTOs.Request.EtapaChecklistEntrega;
using Apselog.Application.DTOs.Response.EtapaChecklistEntrega;

namespace Apselog.Application.UseCases.Interfaces.EtapaChecklistEntrega;

public interface IListarEtapaChecklistEntregaUseCase
{
    Task<IEnumerable<ListarEtapaChecklistEntregaResponse>> ExecutarAsync(ListarEtapaChecklistEntregaRequest request);
}
