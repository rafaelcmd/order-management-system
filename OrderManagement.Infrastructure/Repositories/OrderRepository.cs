using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Persistence;

namespace OrderManagement.Infrastructure.Repositories;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    public async Task<Order?> GetByIdAsync(int orderId)
    {
        return await context.Orders.FindAsync(orderId);
    }
    
    public async Task<List<Order>> GetAllAsync()
    {
        return await context.Orders.ToListAsync();
    }
    
    public async Task CreateAsync(Order order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(int orderId)
    {
        var order = await context.Orders.FindAsync(orderId);
        if (order != null)
        {
            context.Orders.Remove(order);    
        }
        
        await context.SaveChangesAsync();
    }
}