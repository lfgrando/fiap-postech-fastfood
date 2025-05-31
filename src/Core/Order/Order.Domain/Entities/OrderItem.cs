using Order.Domain.Entities.Enums;
using Order.Domain.Entities.Exceptions;

namespace Order.Domain.Entities;
public class OrderItem
{
    private string? _id;
    private string? _name;
    private ItemCategory _category;
    private decimal _price;
    private int _amount;

    public OrderItem(
        string? id,
        string? name,
        ItemCategory category,
        decimal price,
        int amount)
    {
        _name = name;
        _category = category;
        _price = price;
        _amount = amount;
        Id = id;
    }

    public string? Id
    {
        get => _id;
        set => _id = OrderItemPropertyException.ThrowIfEmptyOrWhiteSpace(value, nameof(Id));
    }

    public string? Name
    {
        get => _name;
        set => _name = OrderItemPropertyException.ThrowIfEmptyOrWhiteSpace(value, nameof(Name));
    }

    public ItemCategory Category
    {
        get => _category;
        set => _category = ValidateCategory(value);
    }

    public decimal Price
    {
        get => _price;
        set => _price = OrderItemPropertyException.ThrowIfZeroOrNegative(value, nameof(Price));
    }

    public int Amount
    {
        get => _amount;
        set => _amount = OrderItemPropertyException.ThrowIfZeroOrNegative(value, nameof(Amount));
    }

    private static ItemCategory ValidateCategory(ItemCategory value)
    {
        var isInvalidCategory = !Enum.IsDefined(typeof(ItemCategory), value) || value == ItemCategory.None;

        if (isInvalidCategory)
        {
            throw new OrderItemPropertyException(nameof(Category));
        }

        return value;
    }

    public decimal GetTotalPrice()
    {
        return Price * Amount;
    }
}
