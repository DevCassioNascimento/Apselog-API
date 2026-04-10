using Apselog.Application.DTOs.Request.EtapaChecklistModelo;
using Apselog.Application.DTOs.Response.EtapaChecklistModelo;

namespace Apselog.Application.UseCases.Interfaces.EtapaChecklistModelo;

public interface ICriarEtapaChecklistModeloUseCase
{
    Task<CriarEtapaChecklistModeloResponse> ExecutarAsync(CriarEtapaChecklistModeloRequest request);
}
