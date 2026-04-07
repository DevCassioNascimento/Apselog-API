using Apselog.Domain.Enums;

namespace Apselog.Application.DTOs.Response.Entrega;

public class ListarEntregaResponse
{
    public Guid Id { get; set; }
    public required string Nome { get; set; }
    public required string Cidade { get; set; }
    public required string Estado { get; set; }
    public required int Cep { get; set; }
    public required string Bairro { get; set; }
    public required string Rua { get; set; }
    public required int Numero { get; set; }
    public required string Complemento { get; set; }
    public required string DataPedido { get; set; }
    public required string DataEntrega { get; set; }
    public required string Entregador { get; set; }
    public EntregaStatus Status { get; set; }
}
