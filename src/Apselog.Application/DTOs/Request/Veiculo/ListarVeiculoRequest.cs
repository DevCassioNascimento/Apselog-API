using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.Veiculo;

public class ListarVeiculoRequest
{
    public Guid? Id { get; set; }
    public string? Placa { get; set; }
    public string? Modelo { get; set; }
    public string? Tipo { get; set; }
    public VeiculoStatus? Status { get; set; }
    public Guid? MotoristaId { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
    public string? OrdenarPor { get; set; }
    public bool Ascendente { get; set; } = true;
}
