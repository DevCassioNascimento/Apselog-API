using Apselog.Application.DTOs.Request;
using Apselog.Application.DTOs.Response.Entrega;
using Apselog.Application.UseCases.Interfaces.Entrega;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Entrega;

public class ExcluirEntregaUseCase : IExcluirEntregaUseCase
{
    private readonly IEntregaRepository _entregaRepository;

    public ExcluirEntregaUseCase(IEntregaRepository entregaRepository)
    {
        _entregaRepository = entregaRepository;
    }

    public async Task<ExcluirEntregaResponse> ExecutarAsync(ExcluirEntregaRequest request)
    {
        var entrega = await _entregaRepository.GetByIdAsync(request.Id);

        if (entrega is null)
        {
            throw new KeyNotFoundException("Entrega nao encontrada.");
        }

        await _entregaRepository.DeleteAsync(request.Id);

        return new ExcluirEntregaResponse
        {
            Id = request.Id,
            Sucesso = true,
            Mensagem = "Entrega excluida com sucesso."
        };
    }
}
