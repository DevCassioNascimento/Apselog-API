using Apselog.Application.DTOs.Request.Notificacao;
using Apselog.Application.DTOs.Response.Notificacao;

namespace Apselog.Application.UseCases.Interfaces.Notificacao;

public interface IExcluirNotificacaoUseCase
{
    Task<ExcluirNotificacaoResponse> ExecutarAsync(ExcluirNotificacaoRequest request);
}
