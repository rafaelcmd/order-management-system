using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int orderId);
    Task<List<Order>> GetAllAsync();
    Task CreateAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int orderId);
}