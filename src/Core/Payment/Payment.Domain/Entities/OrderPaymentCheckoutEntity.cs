namespace Payment.Domain.Entities;

public class OrderPaymentCheckoutEntity
{
    // TODO: Auto validate
    public required long Id { get; set; }
    public required string PaymentMethod { get; set; }
    public required string QrCode { get; set; }
    public required string QrCodeBase64 { get; set; }
    public required decimal Amount { get; set; }
}
