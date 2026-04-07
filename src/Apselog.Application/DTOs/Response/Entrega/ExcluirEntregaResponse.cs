namespace Apselog.Application.DTOs.Response.Entrega;

public class ExcluirEntregaResponse
{
    public Guid Id { get; set; }
    public bool Sucesso { get; set; }
    public required string Mensagem { get; set; }
}
