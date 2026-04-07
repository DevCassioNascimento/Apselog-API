using Apselog.Application.DTOs.Request.Veiculo;
using Apselog.Application.DTOs.Response.Veiculo;
using Apselog.Application.UseCases.Interfaces.Veiculo;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Veiculo;

public class ExcluirVeiculoUseCase : IExcluirVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;

    public ExcluirVeiculoUseCase(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<ExcluirVeiculoResponse> ExecutarAsync(ExcluirVeiculoRequest request)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);

        if (veiculo is null)
        {
            throw new KeyNotFoundException("Veiculo nao encontrado.");
        }

        await _veiculoRepository.DeleteAsync(request.Id);

        return new ExcluirVeiculoResponse
        {
            Id = request.Id,
            Sucesso = true,
            Mensagem = "Veiculo excluido com sucesso."
        };
    }
}
