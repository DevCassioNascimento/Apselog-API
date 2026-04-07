using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.EventoEntrega;

public class ListarEventoEntregaRequest
{
    public Guid? Id { get; set; }
    public Guid? EntregaId { get; set; }
    public EventoEntregaTipo? TipoEvento { get; set; }
    public Guid? UsuarioId { get; set; }
    public Guid? EtapaChecklistEntregaId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? OrdenarPor { get; set; }
    public bool Ascendente { get; set; } = true;
}
