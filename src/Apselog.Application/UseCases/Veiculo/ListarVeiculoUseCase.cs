using Apselog.Application.DTOs.Request.Veiculo;
using Apselog.Application.DTOs.Response.Veiculo;
using Apselog.Application.UseCases.Interfaces.Veiculo;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Veiculo;

public class ListarVeiculoUseCase : IListarVeiculoUseCase
{
    private readonly IVeiculoRepository _veiculoRepository;

    public ListarVeiculoUseCase(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<IEnumerable<ListarVeiculoResponse>> ExecutarAsync(ListarVeiculoRequest request)
    {
        if (request.Page.HasValue && request.Page <= 0)
        {
            throw new ArgumentException("Page deve ser maior que zero.");
        }

        if (request.PageSize.HasValue && request.PageSize <= 0)
        {
            throw new ArgumentException("PageSize deve ser maior que zero.");
        }

        IEnumerable<Domain.Entities.Veiculo> query = await _veiculoRepository.GetAllAsync();

        if (request.Id.HasValue)
        {
            query = query.Where(veiculo => veiculo.Id == request.Id.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.Placa))
        {
            query = query.Where(veiculo =>
                veiculo.Placa.Contains(request.Placa, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.Modelo))
        {
            query = query.Where(veiculo =>
                veiculo.Modelo.Contains(request.Modelo, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.Tipo))
        {
            query = query.Where(veiculo =>
                veiculo.Tipo.Contains(request.Tipo, StringComparison.OrdinalIgnoreCase));
        }

        if (request.Status.HasValue)
        {
            query = query.Where(veiculo => veiculo.Status == request.Status.Value);
        }

        if (request.MotoristaId.HasValue)
        {
            query = query.Where(veiculo => veiculo.MotoristaId == request.MotoristaId.Value);
        }

        query = AplicarOrdenacao(query, request.OrdenarPor, request.Ascendente);

        if (request.Page.HasValue && request.PageSize.HasValue)
        {
            var skip = (request.Page.Value - 1) * request.PageSize.Value;
            query = query.Skip(skip).Take(request.PageSize.Value);
        }

        return query.Select(veiculo => new ListarVeiculoResponse
        {
            Id = veiculo.Id,
            Placa = veiculo.Placa,
            Modelo = veiculo.Modelo,
            Tipo = veiculo.Tipo,
            Status = veiculo.Status,
            MotoristaId = veiculo.MotoristaId
        });
    }

    private static IEnumerable<Domain.Entities.Veiculo> AplicarOrdenacao(
        IEnumerable<Domain.Entities.Veiculo> veiculos,
        string? ordenarPor,
        bool ascendente)
    {
        if (string.IsNullOrWhiteSpace(ordenarPor))
        {
            return ascendente
                ? veiculos.OrderBy(veiculo => veiculo.Placa)
                : veiculos.OrderByDescending(veiculo => veiculo.Placa);
        }

        return ordenarPor.Trim().ToLowerInvariant() switch
        {
            "id" => ascendente ? veiculos.OrderBy(veiculo => veiculo.Id) : veiculos.OrderByDescending(veiculo => veiculo.Id),
            "placa" => ascendente ? veiculos.OrderBy(veiculo => veiculo.Placa) : veiculos.OrderByDescending(veiculo => veiculo.Placa),
            "modelo" => ascendente ? veiculos.OrderBy(veiculo => veiculo.Modelo) : veiculos.OrderByDescending(veiculo => veiculo.Modelo),
            "tipo" => ascendente ? veiculos.OrderBy(veiculo => veiculo.Tipo) : veiculos.OrderByDescending(veiculo => veiculo.Tipo),
            "status" => ascendente ? veiculos.OrderBy(veiculo => veiculo.Status) : veiculos.OrderByDescending(veiculo => veiculo.Status),
            "motoristaid" => ascendente ? veiculos.OrderBy(veiculo => veiculo.MotoristaId) : veiculos.OrderByDescending(veiculo => veiculo.MotoristaId),
            _ => throw new ArgumentException("Campo de ordenacao invalido.")
        };
    }
}
