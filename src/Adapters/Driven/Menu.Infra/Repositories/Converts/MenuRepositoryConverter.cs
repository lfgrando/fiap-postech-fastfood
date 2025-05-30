using Menu.Domain.Adapters.Repositories.Interfaces;
using Menu.Domain.Services.DTOs;
using Menu.Domain.Services.Entities;
using Menu.Infra.Repositories.Entities;
using Menu.Infra.Repositories.Interfaces;

namespace Menu.Infra.Repositories.Converts;

public class MenuRepositoryConverter : IMenuRepository
{
    private readonly IMenuMongoRepository _repository;

    public MenuRepositoryConverter(IMenuMongoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MenuItem>> GetAllAsync(MenuItemFilter menuItemFilter, CancellationToken cancellationToken)
    {
        var menuItemsMongoDb = await _repository.GetAllAsync(menuItemFilter, cancellationToken);

        var response = menuItemsMongoDb.Select(menuItem => menuItem.ToDomain());

        return response;
    }

    public async Task<MenuItem?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var menuItemMongoDb = await _repository.GetByIdAsync(id, cancellationToken);

        return menuItemMongoDb?.ToDomain() ?? null;
    }

    public async Task<MenuItem> InsertOneAsync(MenuItem menuItem, CancellationToken cancellationToken)
    {
        var menuItemMongoDb = MenuItemMongoDb.Create(menuItem);

        var menuItemMongoDbInserted = await _repository.InsertOneAsync(menuItemMongoDb, cancellationToken);

        return menuItemMongoDbInserted.ToDomain();
    }

    public async Task<bool> SoftDeleteAsync(string id, CancellationToken cancellationToken)
    {
        var updateWasSucessful = await _repository.SoftDeleteAsync(id, cancellationToken);
        return updateWasSucessful;
    }

    public async Task UpdateAsync(string id, MenuItem menuItem, CancellationToken cancellationToken)
    {
        var menuItemMongoDb = MenuItemMongoDb.Create(menuItem);

        await _repository.UpdateAsync(id, menuItemMongoDb, cancellationToken);
    }

    public async Task<MenuItem?> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        var menuItemMongoDb = await _repository.GetByNameAsync(name, cancellationToken);
        return menuItemMongoDb?.ToDomain() ?? null;
    }
}