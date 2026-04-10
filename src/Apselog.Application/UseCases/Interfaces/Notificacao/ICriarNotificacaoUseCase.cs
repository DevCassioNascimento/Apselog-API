using Apselog.Application.DTOs.Request.Notificacao;
using Apselog.Application.DTOs.Response.Notificacao;

namespace Apselog.Application.UseCases.Interfaces.Notificacao;

public interface ICriarNotificacaoUseCase
{
    Task<CriarNotificacaoResponse> ExecutarAsync(CriarNotificacaoRequest request);
}
