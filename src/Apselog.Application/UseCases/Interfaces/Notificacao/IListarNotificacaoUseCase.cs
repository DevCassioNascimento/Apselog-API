using Apselog.Application.DTOs.Request.Notificacao;
using Apselog.Application.DTOs.Response.Notificacao;

namespace Apselog.Application.UseCases.Interfaces.Notificacao;

public interface IListarNotificacaoUseCase
{
    Task<IEnumerable<ListarNotificacaoResponse>> ExecutarAsync(ListarNotificacaoRequest request);
}
