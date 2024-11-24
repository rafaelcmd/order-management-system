using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Orchestrators;
using OrderManagement.Application.UseCases.Orders;
using OrderManagement.Infrastructure.Persistence;
using OrderManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<GetAllOrders>();

builder.Services.AddScoped<OrderUseCaseOrchestrator>();

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();