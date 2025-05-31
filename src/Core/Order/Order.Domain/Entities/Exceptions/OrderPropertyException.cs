using CrossCutting.Exceptions;

namespace Order.Domain.Entities.Exceptions;
internal class OrderPropertyException : BaseEntityException<OrderEntity>
{
    public OrderPropertyException(string propertyName) : base(propertyName)
    {
    }

    internal static string ThrowIfNullOrEmpty(string? value, string propertyName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new OrderPropertyException(propertyName);
        }
        return value;
    }

    internal static decimal ThrowIfZeroOrNegative(decimal value, string propertyName)
    {
        if (value < 0.00M)
        {
            throw new OrderPropertyException(propertyName);
        }

        return value;
    }
}
