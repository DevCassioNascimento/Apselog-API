using Apselog.Application.DTOs.Request.EtapaChecklistModelo;
using Apselog.Application.DTOs.Response.EtapaChecklistModelo;

namespace Apselog.Application.UseCases.Interfaces.EtapaChecklistModelo;

public interface IListarEtapaChecklistModeloUseCase
{
    Task<IEnumerable<ListarEtapaChecklistModeloResponse>> ExecutarAsync(ListarEtapaChecklistModeloRequest request);
}
