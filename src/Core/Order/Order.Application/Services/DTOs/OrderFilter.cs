namespace Order.Application.Services.DTOs;
public record OrderFilter(string? Status, int Page, int Size)
{
}
