using Apselog.Domain.Entities;

namespace Apselog.Domain.Interfaces.Repositories;

public interface IEntregaRepository
{
    // busca por id
    Task<Entrega?> GetByIdAsync(Guid id);
    // lista todas
    Task<IEnumerable<Entrega>> GetAllAsync();
    // adiciona
    Task AddAsync(Entrega entrega);
    // atualiza por id
    Task UpdateAsync(Entrega entrega);
    // deleta por id
    Task DeleteAsync(Guid id);
}
