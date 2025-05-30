using Menu.Domain.Services.Entities;

namespace Menu.Domain.Services.DTOs;

public record MenuItemFilter(
    string? Name,
    MenuCategory? Category,
    int Skip,
    int Limit);