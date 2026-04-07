using Apselog.Application.DTOs.Request.Veiculo;
using Apselog.Application.DTOs.Response.Veiculo;
using Apselog.Application.UseCases.Interfaces.Veiculo;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Veiculo;

public class CriarVeiculoUseCase : ICriarVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;
    private readonly IMotoristaRepository _motoristaRepository;

    public CriarVeiculoUseCase(
        IVeiculoRepository veiculoRepository,
        IMotoristaRepository motoristaRepository)
    {
        _veiculoRepository = veiculoRepository;
        _motoristaRepository = motoristaRepository;
    }

    public async Task<CriarVeiculoResponse> ExecutarAsync(CriarVeiculoRequest request)
    {
        ValidarRequest(request);

        var motorista = await _motoristaRepository.GetByIdAsync(request.MotoristaId);

        if (motorista is null)
        {
            throw new KeyNotFoundException("Motorista nao encontrado.");
        }

        var veiculoExistente = await _veiculoRepository.GetByPlacaAsync(request.Placa);

        if (veiculoExistente is not null)
        {
            throw new InvalidOperationException("Ja existe um veiculo cadastrado com esta placa.");
        }

        var veiculo = new Domain.Entities.Veiculo
        {
            Placa = request.Placa,
            Modelo = request.Modelo,
            Tipo = request.Tipo,
            Status = request.Status,
            MotoristaId = request.MotoristaId
        };

        await _veiculoRepository.AddAsync(veiculo);

        return new CriarVeiculoResponse
        {
            Id = veiculo.Id,
            Placa = veiculo.Placa,
            Modelo = veiculo.Modelo,
            Tipo = veiculo.Tipo,
            Status = veiculo.Status,
            MotoristaId = veiculo.MotoristaId
        };
    }

    private static void ValidarRequest(CriarVeiculoRequest request)
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
