using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Orchestrators;

namespace OrderManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController(OrderUseCaseOrchestrator orderUseCaseOrchestrator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await orderUseCaseOrchestrator.GetAllOrders();
        return Ok(orders);
    }
}