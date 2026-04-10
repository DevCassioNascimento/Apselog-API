using Apselog.Application.DTOs.Request.ItemEntrega;
using Apselog.Application.DTOs.Response.ItemEntrega;

namespace Apselog.Application.UseCases.Interfaces.ItemEntrega;

public interface IExcluirItemEntregaUseCase
{
    Task<ExcluirItemEntregaResponse> ExecutarAsync(ExcluirItemEntregaRequest request);
}
