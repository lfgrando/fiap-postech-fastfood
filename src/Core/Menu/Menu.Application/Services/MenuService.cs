using CrossCutting.Exceptions;
using Menu.Domain.Adapters.Repositories.Interfaces;
using Menu.Domain.Services.DTOs;
using Menu.Domain.Services.Entities;
using Menu.Domain.Services.Interfaces;

namespace Menu.Application.Services;

public class MenuService : IMenuService
{
    private readonly IMenuRepository _repository;

    public MenuService(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<MenuItemResponse>> GetAllAsync(MenuItemFilter menuItemFilter, CancellationToken cancellationToken)
    {
        var menuItems = await _repository.GetAllAsync(menuItemFilter, cancellationToken);

        var response = menuItems.Select(menuItem => new MenuItemResponse(
                            menuItem.Id,
                            menuItem.Name,
                            menuItem.Price,
                            menuItem.Category,
                            menuItem.Description,
                            menuItem.IsActive));

        return response;
    }

    public async Task<MenuItemResponse> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var menuItem = await _repository.GetByIdAsync(id, cancellationToken);

        if (menuItem is null)
        {
            throw new KeyNotFoundException($"Menu item with ID {id} not found.");
        }

        var response = new MenuItemResponse(
                            menuItem.Id,
                            menuItem.Name,
                            menuItem.Price,
                            menuItem.Category,
                            menuItem.Description,
                            menuItem.IsActive);

        return response;
    }

    public async Task<MenuItemResponse> RegisterAsync(RegisterMenuItemRequest request, CancellationToken cancellationToken)
    {
        var menuItem = new MenuItem(
            name: request.Name!,
            price: request.Price,
            category: request.Category,
            description: request.Description!,
            isActive: true);

        menuItem = await _repository.InsertOneAsync(menuItem, cancellationToken);

        var response = new MenuItemResponse(
            Id: menuItem.Id,
            Name: menuItem.Name,
            Price: menuItem.Price,
            Category: menuItem.Category,
            Description: menuItem.Description,
            IsActive: menuItem.IsActive);

        return response;
    }

    public async Task SoftDeleteAsync(string id, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        var updateWasSuccessful = await _repository.SoftDeleteAsync(id, cancellationToken);

        if (updateWasSuccessful is false)
        {
            throw new KeyNotFoundException($"Menu item with ID {id} not found.");
        }
    }

    public async Task UpdateAsync(string id, UpdateMenuItemRequest request, CancellationToken cancellationToken)
    {
        var menuItem = await _repository.GetByIdAsync(id, cancellationToken);

        if (menuItem is null)
        {
            throw new KeyNotFoundException($"Menu item with ID {id} not found.");
        }

        menuItem.Name = request.Name!;
        menuItem.Price = request.Price;
        menuItem.Category = request.Category;
        menuItem.Description = request.Description!;
        menuItem.IsActive = request.IsActive;

        var existingMenuItem = await _repository.GetByNameAsync(menuItem.Name, cancellationToken);
        if (existingMenuItem is not null && existingMenuItem.Id != id)
        {
            throw new DuplicateItemException($"A menu item with the name '{menuItem.Name}' already exists.");
        }

        await _repository.UpdateAsync(id, menuItem, cancellationToken);
    }
}
