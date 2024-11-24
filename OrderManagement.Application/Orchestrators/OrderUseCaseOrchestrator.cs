using OrderManagement.Application.UseCases.Orders;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Orchestrators;

public class OrderUseCaseOrchestrator(GetAllOrders getAllOrders)
{
    public Task<List<Order>> GetAllOrders() => getAllOrders.ExecuteAsync();
}