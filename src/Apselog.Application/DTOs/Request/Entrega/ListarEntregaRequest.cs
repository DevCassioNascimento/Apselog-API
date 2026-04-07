using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request;

public class ListarEntregaRequest
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public string? Cidade { get; set; }
    public string? Entregador { get; set; }
    public EntregaStatus? Status { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? OrdenarPor { get; set; }
    public bool Ascendente { get; set; } = true;
}
