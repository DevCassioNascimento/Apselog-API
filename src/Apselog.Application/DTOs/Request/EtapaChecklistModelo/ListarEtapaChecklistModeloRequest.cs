using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.EtapaChecklistModelo;

public class ListarEtapaChecklistModeloRequest
{
    public Guid? Id { get; set; }
    public string? Codigo { get; set; }
    public string? Nome { get; set; }
    public TipoAssinante? TipoAssinante { get; set; }
    public bool? Obrigatoria { get; set; }
    public bool? RequerAssinatura { get; set; }
    public bool? Ativo { get; set; }
    public int? Ordem { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? OrdenarPor { get; set; }
    public bool Ascendente { get; set; } = true;
}
