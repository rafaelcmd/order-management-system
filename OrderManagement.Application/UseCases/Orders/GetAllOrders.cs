using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.UseCases.Orders;

public class GetAllOrders(IOrderRepository orderRepository)
{
    public async Task<List<Order>> ExecuteAsync()
    {
        return await orderRepository.GetAllAsync();
    }
}