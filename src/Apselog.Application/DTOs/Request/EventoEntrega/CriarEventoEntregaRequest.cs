using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.EventoEntrega;

public class CriarEventoEntregaRequest
{
    public Guid EntregaId { get; set; }
    public EventoEntregaTipo TipoEvento { get; set; }
    public required string Descricao { get; set; }
    public Guid? UsuarioId { get; set; }
    public Guid? EtapaChecklistEntregaId { get; set; }
    public required string DataEvento { get; set; }
    public string? MetadataJson { get; set; }
}
