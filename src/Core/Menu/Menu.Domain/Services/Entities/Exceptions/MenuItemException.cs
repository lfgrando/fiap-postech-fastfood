using CrossCutting.Exceptions;

namespace Menu.Domain.Services.Entities.Exceptions;

public class MenuItemException : BaseEntityException<MenuItem>
{
    public MenuItemException(string propertyName) : base(propertyName)
    {
    }

    public static new void ThrowIfEmptyOrWhiteSpace(string? value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{propertyName} cannot be empty or whitespace.");
    }

    public static void ThrowIfExceedsMaxLength(string value, string propertyName, int maxLength)
    {
        if (value.Length > maxLength)
            throw new ArgumentException($"{propertyName} cannot exceed {maxLength} characters.");
    }

    public static void ThrowIfZero(decimal value, string propertyName)
    {
        if (value == 0)
            throw new ArgumentException($"{propertyName} cannot be zero.");
    }

    public static void ThrowIfNegative(decimal value, string propertyName)
    {
        if (value < 0)
            throw new ArgumentException($"{propertyName} cannot be negative.");
    }
}