namespace Apselog.Application.DTOs.Response.Motorista;

public class ExcluirMotoristaResponse
{
    public Guid Id { get; set; }
    public bool Sucesso { get; set; }
    public required string Mensagem { get; set; }
}
