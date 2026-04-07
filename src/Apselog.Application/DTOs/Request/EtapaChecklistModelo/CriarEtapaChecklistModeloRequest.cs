using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.EtapaChecklistModelo;

public class CriarEtapaChecklistModeloRequest
{
    public required string Codigo { get; set; }
    public required string Nome { get; set; }
    public string? Descricao { get; set; }
    public int Ordem { get; set; }
    public bool Obrigatoria { get; set; }
    public bool RequerAssinatura { get; set; }
    public TipoAssinante TipoAssinante { get; set; } = TipoAssinante.Nenhum;
    public bool Ativo { get; set; } = true;
}
