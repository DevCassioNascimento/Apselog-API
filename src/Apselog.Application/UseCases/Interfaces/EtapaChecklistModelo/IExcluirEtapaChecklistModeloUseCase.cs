using Apselog.Application.DTOs.Request.EtapaChecklistModelo;
using Apselog.Application.DTOs.Response.EtapaChecklistModelo;

namespace Apselog.Application.UseCases.Interfaces.EtapaChecklistModelo;

public interface IExcluirEtapaChecklistModeloUseCase
{
    Task<ExcluirEtapaChecklistModeloResponse> ExecutarAsync(ExcluirEtapaChecklistModeloRequest request);
}
