using Apselog.Domain.Entities;
using Apselog.Domain.Enums;

namespace Apselog.Domain.Interfaces.Repositories;

public interface IVeiculoRepository
{
    // busca por id
    Task<Veiculo?> GetByIdAsync(Guid id);
    // busca por placa
    Task<Veiculo?> GetByPlacaAsync(string placa);
    // lista por status, ex: VeiculoStatus.Rota
    Task<IEnumerable<Veiculo>> GetByStatusAsync(VeiculoStatus status);
    // lista todos
    Task<IEnumerable<Veiculo>> GetAllAsync();
    // adiciona
    Task AddAsync(Veiculo veiculo);
    // atualiza por id
    Task UpdateAsync(Veiculo veiculo);
    // deleta por id
    Task DeleteAsync(Guid id);
}
