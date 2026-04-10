using Apselog.Application.DTOs.Request.Endereco;
using Apselog.Application.DTOs.Response.Endereco;

namespace Apselog.Application.UseCases.Interfaces.Endereco;

public interface IAtualizarEnderecoUseCase
{
    Task<AtualizarEnderecoResponse> ExecutarAsync(AtualizarEnderecoRequest request);
}
