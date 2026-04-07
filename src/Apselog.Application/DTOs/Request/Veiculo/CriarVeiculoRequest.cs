using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Request.Veiculo;

public class CriarVeiculoRequest
{
    public required string Placa { get; set; }
    public required string Modelo { get; set; }
    public required string Tipo { get; set; }
    public VeiculoStatus Status { get; set; } = VeiculoStatus.Ativo;
    public Guid MotoristaId { get; set; }
}
