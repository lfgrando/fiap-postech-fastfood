using Menu.Domain.Services.DTOs;
using Menu.Domain.Services.Entities;

namespace Menu.Domain.Adapters.Repositories.Interfaces;

public interface IMenuRepository
{
    Task<MenuItem?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<MenuItem> InsertOneAsync(MenuItem menuItem, CancellationToken cancellationToken);
    Task<IEnumerable<MenuItem>> GetAllAsync(MenuItemFilter menuItemFilter, CancellationToken cancellationToken);
    Task<bool> SoftDeleteAsync(string id, CancellationToken cancellationToken);
    Task UpdateAsync(string id, MenuItem menuItem, CancellationToken cancellationToken);
    Task<MenuItem?> GetByNameAsync(string name, CancellationToken cancellationToken);
}