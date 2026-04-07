using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.Notificacao;

public class CriarNotificacaoRequest
{
    public Guid UsuarioId { get; set; }
    public Guid? EntregaId { get; set; }
    public NotificacaoTipo Tipo { get; set; }
    public required string Titulo { get; set; }
    public required string Mensagem { get; set; }
    public NotificacaoCanal Canal { get; set; } = NotificacaoCanal.InApp;
    public NotificacaoStatus Status { get; set; } = NotificacaoStatus.Pendente;
    public string? LidaEm { get; set; }
    public string? EnviadaEm { get; set; }
    public string? PayloadJson { get; set; }
}
