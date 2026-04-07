using Apselog.Application.DTOs.Request;
using Apselog.Application.DTOs.Response.Entrega;
using Apselog.Application.UseCases.Interfaces.Entrega;
using Apselog.Domain.Entities;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Entrega;

public class CriarEntregaUseCase : ICriarEntregaUseCase
{
    private readonly IEntregaRepository _entregaRepository;

    public CriarEntregaUseCase(IEntregaRepository entregaRepository)
    {
        _entregaRepository = entregaRepository;
    }

    public async Task<CriarEntregaResponse> ExecutarAsync(CriarEntregaRequest request)
    {
        ValidarRequest(request);

        var entrega = new Domain.Entities.Entrega
        {
            Nome = request.Nome,
            Cidade = request.Cidade,
            Estado = request.Estado,
            Cep = request.Cep,
            Bairro = request.Bairro,
            Rua = request.Rua,
            Numero = request.Numero,
            Complemento = request.Complemento,
            DataPedido = request.DataPedido,
            DataEntrega = request.DataEntrega,
            Entregador = request.Entregador,
            Status = request.Status
        };

        await _entregaRepository.AddAsync(entrega);

        return new CriarEntregaResponse
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
        };
    }

    private static void ValidarRequest(CriarEntregaRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
        {
            throw new ArgumentException("O nome da entrega e obrigatorio.");
        }

        if (string.IsNullOrWhiteSpace(request.Cidade))
        {
            throw new ArgumentException("A cidade da entrega e obrigatoria.");
        }

        if (string.IsNullOrWhiteSpace(request.Estado))
        {
            throw new ArgumentException("O estado da entrega e obrigatorio.");
        }

        if (string.IsNullOrWhiteSpace(request.Bairro))
        {
            throw new ArgumentException("O bairro da entrega e obrigatorio.");
        }

        if (string.IsNullOrWhiteSpace(request.Rua))
        {
            throw new ArgumentException("A rua da entrega e obrigatoria.");
        }

        if (string.IsNullOrWhiteSpace(request.DataPedido))
        {
            throw new ArgumentException("A data do pedido e obrigatoria.");
        }

        if (string.IsNullOrWhiteSpace(request.DataEntrega))
        {
            throw new ArgumentException("A data da entrega e obrigatoria.");
        }

        if (string.IsNullOrWhiteSpace(request.Entregador))
        {
            throw new ArgumentException("O entregador e obrigatorio.");
        }

        if (request.Cep <= 0)
        {
            throw new ArgumentException("O CEP da entrega deve ser maior que zero.");
        }

        if (request.Numero <= 0)
        {
            throw new ArgumentException("O numero da entrega deve ser maior que zero.");
        }
    }
}
