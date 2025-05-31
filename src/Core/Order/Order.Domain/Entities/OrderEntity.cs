using Order.Domain.Entities.Enums;
using Order.Domain.Entities.Exceptions;

namespace Order.Domain.Entities;
public class OrderEntity
{
    private string? _id;
    private string? _customerId;
    private string? _customerName;
    private IEnumerable<OrderItem> _items = [];
    private OrderStatus _status;
    private PaymentMethod _paymentMethod;
    private decimal _totalPrice;

    public OrderEntity(
        string? id,
        string? customerId,
        string? customerName,
        IEnumerable<OrderItem> items,
        OrderStatus status,
        PaymentMethod paymentMethod,
        decimal totalPrice)
    {
        Id = id;
        CustomerId = customerId;
        CustomerName = customerName;
        Items = items;
        Status = status;
        PaymentMethod = paymentMethod;
        TotalPrice = totalPrice;
    }

    public OrderEntity(
        string? customerId,
        string? customerName,
        IEnumerable<OrderItem> items)
    {
        CustomerId = customerId;
        CustomerName = customerName;
        Items = items;
        TotalPrice = SumItems(items);
        Status = OrderStatus.Pending;
        PaymentMethod = PaymentMethod.None;
    }


    public string? Id { get => _id; set => _id = value; }
    public string? CustomerId { get => _customerId; set => _customerId = value; }
    public string? CustomerName { get => _customerName; set => _customerName = value; }
    public OrderStatus Status { get => _status; set => _status = ValidateCategory(value); }

    public PaymentMethod PaymentMethod { get => _paymentMethod; set => _paymentMethod = value; }

    public decimal TotalPrice
    {
        get => _totalPrice;
        set => _totalPrice = OrderPropertyException.ThrowIfZeroOrNegative(value, nameof(TotalPrice));
    }

    internal IEnumerable<OrderItem> Items { get => _items; set => _items = value; }


    private static OrderStatus ValidateCategory(OrderStatus value)
    {
        var isInvalidCategory = !Enum.IsDefined(typeof(OrderStatus), value) || value == OrderStatus.None;

        if (isInvalidCategory)
        {
            throw new OrderItemPropertyException(nameof(OrderStatus));
        }

        return value;
    }

    private static decimal SumItems(IEnumerable<OrderItem> items)
    {
        decimal total = 0;

        foreach (var item in items)
        {
            total += item.GetTotalPrice();
        }

        return total;
    }
}
