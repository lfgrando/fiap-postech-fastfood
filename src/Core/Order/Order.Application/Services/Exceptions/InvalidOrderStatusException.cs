namespace Order.Application.Services.Exceptions;
internal class InvalidOrderStatusException : Exception
{
    private const string DEFAULT_MESSAGE = "OrderStatus cannot be null or empty.";
    internal InvalidOrderStatusException()
        : base(DEFAULT_MESSAGE)
    {
    }

    internal static void ThrowIfNullOrEmpty(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOrderStatusException();
        }
    }
}
