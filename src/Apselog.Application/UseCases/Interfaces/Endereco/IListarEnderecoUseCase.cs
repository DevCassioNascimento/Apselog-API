using Apselog.Application.DTOs.Request.Endereco;
using Apselog.Application.DTOs.Response.Endereco;

namespace Apselog.Application.UseCases.Interfaces.Endereco;

public interface IListarEnderecoUseCase
{
    Task<IEnumerable<ListarEnderecoResponse>> ExecutarAsync(ListarEnderecoRequest request);
}
