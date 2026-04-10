using Apselog.Application.DTOs.Request.Notificacao;
using Apselog.Application.DTOs.Response.Notificacao;

namespace Apselog.Application.UseCases.Interfaces.Notificacao;

public interface IAtualizarNotificacaoUseCase
{
    Task<AtualizarNotificacaoResponse> ExecutarAsync(AtualizarNotificacaoRequest request);
}
