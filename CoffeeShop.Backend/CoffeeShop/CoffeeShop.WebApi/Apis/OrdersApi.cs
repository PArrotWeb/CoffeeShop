using CoffeeShop.WebApi.Data.Orders;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.WebApi.Apis;

/// <summary>
/// API for orders
/// </summary>
public class OrdersApi : IApi
{

	#region IApi Members
	public void Register(WebApplication app)
	{
		app.MapGet("/orders", Get)
			.Produces<List<Order>>()
			.WithName("GetAllOrders")
			.WithTags("Orders");

		app.MapGet("/orders/{id:int}", GetById)
			.Produces<List<Order>>()
			.WithName("GetOrder")
			.WithTags("Orders");

		app.MapPost("/orders", Post)
			.Accepts<Order>("application/json")
			.WithName("CreateOrder")
			.WithTags("Orders");

		app.MapPut("/orders", Put)
			.Accepts<Order>("application/json")
			.WithName("UpdateOrder")
			.WithTags("Orders");

		app.MapDelete("/orders/{id:int}", Delete)
			.WithName("DeleteOrder")
			.WithTags("Orders");
	}
	#endregion

	private async Task<IResult> Get([FromServices] IOrderRepository orderRepository)
	{
		// return all orders from the database
		return Results.Ok(await orderRepository.GetAsync());
	}

	private async Task<IResult> GetById([FromRoute] int id, [FromServices] IOrderRepository orderRepository)
	{
		// get order by id from the database
		return await orderRepository.GetAsync(id) is { } order
			? Results.Ok(order)
			: Results.NotFound();
	}

	private async Task<IResult> Post([FromBody] Order order, [FromServices] IOrderRepository orderRepository)
	{
		// insert order into the database
		await orderRepository.InsertAsync(order);
		await orderRepository.SaveAsync();

		// return created order
		return Results.Created($"/orders/{order.Id}", order);
	}

	private async Task<IResult> Put([FromBody] Order order, [FromServices] IOrderRepository orderRepository)
	{
		// update order in the database
		await orderRepository.UpdateAsync(order);
		await orderRepository.SaveAsync();

		return Results.NoContent();
	}

	private async Task<IResult> Delete([FromRoute] int id, [FromServices] IOrderRepository orderRepository)
	{
		// delete order from the database
		await orderRepository.DeleteAsync(id);
		await orderRepository.SaveAsync();

		return Results.NoContent();
	}
}