namespace Apselog.Domain.Entities;

public class Motorista
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Nome { get; set; }
    public required string Email { get; set; }
    public required string SenhaHash { get; set; }
    public ICollection<Entrega> Entregas { get; set; } = [];
    public ICollection<Veiculo> Veiculos { get; set; } = [];
}
