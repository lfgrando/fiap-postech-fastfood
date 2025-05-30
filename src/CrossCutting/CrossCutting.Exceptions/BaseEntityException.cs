namespace CrossCutting.Exceptions;

public class BaseEntityException<TEntity> : Exception
    where TEntity : class
{
    private const string _MESSAGE = "The {0} property {1} with the wrong value";

    private static readonly string _className = typeof(TEntity).Name;

    public BaseEntityException(string propertyName)
        : base(string.Format(_MESSAGE, _className, propertyName))
    {

    }

    public static string ThrowIfEmptyOrWhiteSpace(string? value, string propertyName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new BaseEntityException<TEntity>(propertyName);
        }

        return value;
    }
}