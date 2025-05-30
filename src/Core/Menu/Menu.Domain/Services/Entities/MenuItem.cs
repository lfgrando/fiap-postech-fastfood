using Menu.Domain.Services.Entities.Exceptions;

namespace Menu.Domain.Services.Entities;

public class MenuItem
{
    private string? _Name;
    private decimal _Price;
    private string? _Description;

    public string Id { get; set; } = string.Empty;
    public DateTime Created { get; set; }

    public string Name
    {
        get => _Name!;
        set => _Name = ValidateName(value);
    }

    public decimal Price
    {
        get => _Price;
        set => _Price = ValidatePrice(value);
    }

    public string Description
    {
        get => _Description!;
        set => _Description = ValidateDescription(value);
    }

    public bool IsActive { get; set; }
    public MenuCategory Category { get; set; }

    public MenuItem(string name, decimal price, MenuCategory category, string description, bool isActive)
    {
        Name = name;
        Price = price;
        Category = category;
        Description = description;
        IsActive = isActive;
    }

    private string ValidateName(string? value)
    {
        MenuItemException.ThrowIfEmptyOrWhiteSpace(value, nameof(Name));
        return value!.Trim();
    }

    private decimal ValidatePrice(decimal value)
    {
        MenuItemException.ThrowIfZero(value, nameof(Price));
        MenuItemException.ThrowIfNegative(value, nameof(Price));
        return value;
    }

    private string ValidateDescription(string? value)
    {
        MenuItemException.ThrowIfEmptyOrWhiteSpace(value, nameof(Description));
        MenuItemException.ThrowIfExceedsMaxLength(value!, nameof(Description), 200);
        return value!;
    }
}
