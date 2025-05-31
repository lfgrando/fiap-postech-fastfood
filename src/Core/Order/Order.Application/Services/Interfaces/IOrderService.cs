using Order.Application.Services.DTOs;
using Order.Domain.Entities;

namespace Order.Application.Services.Interfaces;
public interface IOrderService
{
    Task<GetResponse> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<Pagination<GetResponse>> GetAllAsync(OrderFilter filter, CancellationToken cancellationToken);
    Task<string> CreateAsync(CreateRequest request, CancellationToken cancellationToken);
    Task<CheckoutResponse> CheckoutAsync(string id, CheckoutRequest request, CancellationToken cancellationToken);
    Task ConfirmPaymentAsync(string id, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<GetResponse> UpdateStatusAsync(
        string id,
        UpdateStatusRequest updateStatusRequest,
        CancellationToken cancellationToken);

}
