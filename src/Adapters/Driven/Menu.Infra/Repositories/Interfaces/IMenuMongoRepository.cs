using Menu.Domain.Services.DTOs;
using Menu.Infra.Repositories.Entities;

namespace Menu.Infra.Repositories.Interfaces;

public interface IMenuMongoRepository
{
    Task<MenuItemMongoDb?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<MenuItemMongoDb> InsertOneAsync(MenuItemMongoDb menuItem, CancellationToken cancellationToken);
    Task<IEnumerable<MenuItemMongoDb>> GetAllAsync(MenuItemFilter menuItemFilter, CancellationToken cancellationToken);
    Task<bool> SoftDeleteAsync(string id, CancellationToken cancellationToken);
    Task UpdateAsync(string id, MenuItemMongoDb menuItem, CancellationToken cancellationToken);
    Task<MenuItemMongoDb> GetByNameAsync(string name, CancellationToken cancellationToken);
}