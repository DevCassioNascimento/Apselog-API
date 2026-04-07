using Apselog.Application.DTOs.Request;
using Apselog.Application.DTOs.Response.Entrega;
using Apselog.Application.UseCases.Interfaces.Entrega;
using Apselog.Domain.Interfaces.Repositories;

namespace Apselog.Application.UseCases.Entrega;

public class AtualizarEntregaUseCase : IAtualizarEntregaUseCase
{
    private readonly IEntregaRepository _entregaRepository;

    public AtualizarEntregaUseCase(IEntregaRepository entregaRepository)
    {
        _entregaRepository = entregaRepository;
    }

    public async Task<AtualizarEntregaResponse> ExecutarAsync(AtualizarEntregaRequest request)
    {
        var entrega = await _entregaRepository.GetByIdAsync(request.Id);

        if (entrega is null)
        {
            throw new KeyNotFoundException("Entrega nao encontrada.");
        }

        ValidarRequest(request);

        entrega.Nome = request.Nome;
        entrega.Cidade = request.Cidade;
        entrega.Estado = request.Estado;
        entrega.Cep = request.Cep;
        entrega.Bairro = request.Bairro;
        entrega.Rua = request.Rua;
        entrega.Numero = request.Numero;
        entrega.Complemento = request.Complemento;
        entrega.DataPedido = request.DataPedido;
        entrega.DataEntrega = request.DataEntrega;
        entrega.Entregador = request.Entregador;
        entrega.Status = request.Status;

        await _entregaRepository.UpdateAsync(entrega);

        return new AtualizarEntregaResponse
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

    private static void ValidarRequest(AtualizarEntregaRequest request)
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
