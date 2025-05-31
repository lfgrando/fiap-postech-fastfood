using Order.Domain.Entities.Enums;
using Payment.Domain.Adapters.DTOs;
using Payment.Domain.Entities;

namespace Payment.Domain.Adapters;

public interface IMercadoPagoPaymentAdapter
{
    Task<OrderPaymentCheckoutEntity> CreatePaymentAsync(
        CheckoutInput checkoutInput,
        PaymentMethod paymentMethod,
        CancellationToken cancellationToken);
}
