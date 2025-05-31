using Order.Domain.Entities.Enums;

namespace Order.Application.Services.Exceptions;
internal class PaymentMethodNotSupportedException : Exception
{
    private const string DEFAULT_MESSAGE = "Payment method '{0}' not supported.";

    internal PaymentMethodNotSupportedException(string paymentMethod)
        : base(string.Format(DEFAULT_MESSAGE, paymentMethod))
    {
    }

    internal static void ThrowIfPaymentMethodIsNotSupported(string paymentMethod)
    {
        if (!Enum.IsDefined(typeof(PaymentMethod), paymentMethod))
            throw new PaymentMethodNotSupportedException(paymentMethod);

        _ = Enum.TryParse(paymentMethod, out PaymentMethod paymentMethodEnum);
        if (paymentMethodEnum != PaymentMethod.Pix)
            throw new PaymentMethodNotSupportedException(paymentMethod);
    }
}
