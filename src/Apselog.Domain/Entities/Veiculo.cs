using Apselog.Domain.Enums;

namespace Apselog.Domain.Entities;


public class Veiculo
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Placa { get; set; }
    public required string Modelo { get; set; }
    public required string Tipo { get; set; }
    public VeiculoStatus Status { get; set; } = VeiculoStatus.Ativo;
    public Guid MotoristaId { get; set; }
    public Motorista Motorista { get; set; } = null!;
}
