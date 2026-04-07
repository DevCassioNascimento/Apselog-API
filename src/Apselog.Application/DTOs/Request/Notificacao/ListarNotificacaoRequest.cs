using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.Notificacao;

public class ListarNotificacaoRequest
{
    public Guid? Id { get; set; }
    public Guid? UsuarioId { get; set; }
    public Guid? EntregaId { get; set; }
    public NotificacaoTipo? Tipo { get; set; }
    public NotificacaoCanal? Canal { get; set; }
    public NotificacaoStatus? Status { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? OrdenarPor { get; set; }
    public bool Ascendente { get; set; } = true;
}
