using Apselog.Application.DTOs.Request.Veiculo;
using Apselog.Application.DTOs.Response.Veiculo;
using Apselog.Application.UseCases.Interfaces.Veiculo;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Veiculo;

public class AtualizarVeiculoUseCase : IAtualizarVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMotoristaRepository _motoristaRepository;

    public AtualizarVeiculoUseCase(
        IVeiculoRepository veiculoRepository,
        IMotoristaRepository motoristaRepository)
    {
        _veiculoRepository = veiculoRepository;
        _motoristaRepository = motoristaRepository;
    }

    public async Task<AtualizarVeiculoResponse> ExecutarAsync(AtualizarVeiculoRequest request)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);

        if (veiculo is null)
        {
            throw new KeyNotFoundException("Veiculo nao encontrado.");
        }

        ValidarRequest(request);

        var motorista = await _motoristaRepository.GetByIdAsync(request.MotoristaId);

        if (motorista is null)
        {
            throw new KeyNotFoundException("Motorista nao encontrado.");
        }

        var veiculoComMesmaPlaca = await _veiculoRepository.GetByPlacaAsync(request.Placa);

        if (veiculoComMesmaPlaca is not null && veiculoComMesmaPlaca.Id != request.Id)
        {
            throw new InvalidOperationException("Ja existe um veiculo cadastrado com esta placa.");
        }

        veiculo.Placa = request.Placa;
        veiculo.Modelo = request.Modelo;
        veiculo.Tipo = request.Tipo;
        veiculo.Status = request.Status;
        veiculo.MotoristaId = request.MotoristaId;

        await _veiculoRepository.UpdateAsync(veiculo);

        return new AtualizarVeiculoResponse
        {
            Id = veiculo.Id,
            Placa = veiculo.Placa,
            Modelo = veiculo.Modelo,
            Tipo = veiculo.Tipo,
            Status = veiculo.Status,
            MotoristaId = veiculo.MotoristaId
        };
    }

    private static void ValidarRequest(AtualizarVeiculoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Placa))
        {
            throw new ArgumentException("A placa do veiculo e obrigatoria.");
        }

        if (string.IsNullOrWhiteSpace(request.Modelo))
        {
            throw new ArgumentException("O modelo do veiculo e obrigatorio.");
        }

        if (string.IsNullOrWhiteSpace(request.Tipo))
        {
            throw new ArgumentException("O tipo do veiculo e obrigatorio.");
        }

        if (request.MotoristaId == Guid.Empty)
        {
            throw new ArgumentException("O MotoristaId do veiculo e obrigatorio.");
        }
    }
}
