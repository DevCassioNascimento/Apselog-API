using Apselog.Application.DTOs.Request;
using Apselog.Application.DTOs.Response.Entrega;
using Apselog.Application.UseCases.Interfaces.Entrega;
using Apselog.Domain.Entities;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Entrega;

public class ListarEntregaUseCase : IListarEntregaUseCase
{
    private readonly IEntregaRepository _entregaRepository;

    public ListarEntregaUseCase(IEntregaRepository entregaRepository)
    {
        _entregaRepository = entregaRepository;
    }

    public async Task<IEnumerable<ListarEntregaResponse>> ExecutarAsync(ListarEntregaRequest request)
    {
        if (request.Page.HasValue && request.Page <= 0)
        {
            throw new ArgumentException("Page deve ser maior que zero.");
        }

        if (request.PageSize.HasValue && request.PageSize <= 0)
        {
            throw new ArgumentException("PageSize deve ser maior que zero.");
        }

        IEnumerable<Domain.Entities.Entrega> query = await _entregaRepository.GetAllAsync();

        if (request.Id.HasValue)
        {
            query = query.Where(entrega => entrega.Id == request.Id.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.Nome))
        {
            query = query.Where(entrega =>
                entrega.Nome.Contains(request.Nome, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.Cidade))
        {
            query = query.Where(entrega =>
                entrega.Cidade.Contains(request.Cidade, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(request.Entregador))
        {
            query = query.Where(entrega =>
                entrega.Entregador.Contains(request.Entregador, StringComparison.OrdinalIgnoreCase));
        }

        if (request.Status.HasValue)
        {
            query = query.Where(entrega => entrega.Status == request.Status.Value);
        }

        query = AplicarOrdenacao(query, request.OrdenarPor, request.Ascendente);

        if (request.Page.HasValue && request.PageSize.HasValue)
        {
            var skip = (request.Page.Value - 1) * request.PageSize.Value;
            query = query.Skip(skip).Take(request.PageSize.Value);
        }

        return query.Select(entrega => new ListarEntregaResponse
        {
            Id = entrega.Id,
            Nome = entrega.Nome,
            Cidade = entrega.Cidade,
            Estado = entrega.Estado,
            Cep = entrega.Cep,
            Bairro = entrega.Bairro,
            Rua = entrega.Rua,
            Numero = entrega.Numero,
            Complemento = entrega.Complemento,
            DataPedido = entrega.DataPedido,
            DataEntrega = entrega.DataEntrega,
            Entregador = entrega.Entregador,
            Status = entrega.Status
        });
    }

    private static IEnumerable<Domain.Entities.Entrega> AplicarOrdenacao(
        IEnumerable<Domain.Entities.Entrega> entregas,
        string? ordenarPor,
        bool ascendente)
    {
        if (string.IsNullOrWhiteSpace(ordenarPor))
        {
            return ascendente
                ? entregas.OrderBy(entrega => entrega.Nome)
                : entregas.OrderByDescending(entrega => entrega.Nome);
        }

        return ordenarPor.Trim().ToLowerInvariant() switch
        {
            "id" => ascendente ? entregas.OrderBy(entrega => entrega.Id) : entregas.OrderByDescending(entrega => entrega.Id),
            "nome" => ascendente ? entregas.OrderBy(entrega => entrega.Nome) : entregas.OrderByDescending(entrega => entrega.Nome),
            "cidade" => ascendente ? entregas.OrderBy(entrega => entrega.Cidade) : entregas.OrderByDescending(entrega => entrega.Cidade),
            "estado" => ascendente ? entregas.OrderBy(entrega => entrega.Estado) : entregas.OrderByDescending(entrega => entrega.Estado),
            "cep" => ascendente ? entregas.OrderBy(entrega => entrega.Cep) : entregas.OrderByDescending(entrega => entrega.Cep),
            "bairro" => ascendente ? entregas.OrderBy(entrega => entrega.Bairro) : entregas.OrderByDescending(entrega => entrega.Bairro),
            "rua" => ascendente ? entregas.OrderBy(entrega => entrega.Rua) : entregas.OrderByDescending(entrega => entrega.Rua),
            "numero" => ascendente ? entregas.OrderBy(entrega => entrega.Numero) : entregas.OrderByDescending(entrega => entrega.Numero),
            "datapedido" => ascendente ? entregas.OrderBy(entrega => entrega.DataPedido) : entregas.OrderByDescending(entrega => entrega.DataPedido),
            "dataentrega" => ascendente ? entregas.OrderBy(entrega => entrega.DataEntrega) : entregas.OrderByDescending(entrega => entrega.DataEntrega),
            "entregador" => ascendente ? entregas.OrderBy(entrega => entrega.Entregador) : entregas.OrderByDescending(entrega => entrega.Entregador),
            "status" => ascendente ? entregas.OrderBy(entrega => entrega.Status) : entregas.OrderByDescending(entrega => entrega.Status),
            _ => throw new ArgumentException("Campo de ordenacao invalido.")
        };
    }
}
