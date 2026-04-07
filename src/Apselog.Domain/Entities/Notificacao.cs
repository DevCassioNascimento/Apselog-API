using Apselog.Domain.Enums;

namespace Apselog.Domain.Entities;

public class Notificacao
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UsuarioId { get; set; }
    public User Usuario { get; set; } = null!;
    public Guid? EntregaId { get; set; }
    public Entrega? Entrega { get; set; }
    public NotificacaoTipo Tipo { get; set; }
    public required string Titulo { get; set; }
    public required string Mensagem { get; set; }
    public NotificacaoCanal Canal { get; set; } = NotificacaoCanal.InApp;
    public NotificacaoStatus Status { get; set; } = NotificacaoStatus.Pendente;
    public string? LidaEm { get; set; }
    public string? EnviadaEm { get; set; }
    public string? PayloadJson { get; set; }
}
