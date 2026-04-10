using Apselog.Application.DTOs.Request.Endereco;
using Apselog.Application.DTOs.Response.Endereco;

namespace Apselog.Application.UseCases.Interfaces.Endereco;

public interface ICriarEnderecoUseCase
{
    Task<CriarEnderecoResponse> ExecutarAsync(CriarEnderecoRequest request);
}
