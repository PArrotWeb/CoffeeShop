using CoffeeShop.WebApi.Data.PaymentMethods;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.WebApi.Apis;

/// <summary>
/// API for payment methods
/// </summary>
public class PaymentMethodsApi : IApi
{

	#region IApi Members
	public void Register(WebApplication app)
	{
		app.MapGet("/payment-methods", Get)
			.Produces<List<PaymentMethod>>()
			.WithName("GetAllPaymentMethods")
			.WithTags("PaymentMethods");

		app.MapGet("/payment-methods/{id:int}", GetById)
			.Produces<List<PaymentMethod>>()
			.WithName("GetPaymentMethod")
			.WithTags("PaymentMethods");

		app.MapPost("/payment-methods", Post)
			.Accepts<PaymentMethod>("application/json")
			.WithName("CreatePaymentMethod")
			.WithTags("PaymentMethods");

		app.MapPut("/payment-methods", Put)
			.Accepts<PaymentMethod>("application/json")
			.WithName("UpdatePaymentMethod")
			.WithTags("PaymentMethods");

		app.MapDelete("/payment-methods/{id:int}", Delete)
			.WithName("DeletePaymentMethod")
			.WithTags("PaymentMethods");
	}
	#endregion

	private async Task<IResult> Get([FromServices] IPaymentMethodRepository paymentMethodRepository)
	{
		// return all payment methods from the database
		return Results.Ok(await paymentMethodRepository.GetAsync());
	}

	private async Task<IResult> GetById([FromRoute] int id,
		[FromServices] IPaymentMethodRepository paymentMethodRepository)
	{
		// get payment method by id from the database
		return await paymentMethodRepository.GetAsync(id) is { } paymentMethod
			? Results.Ok(paymentMethod)
			: Results.NotFound();
	}

	private async Task<IResult> Post([FromBody] PaymentMethod paymentMethod, [FromServices] IPaymentMethodRepository
		paymentMethodRepository)
	{
		// insert payment method into the database
		await paymentMethodRepository.InsertAsync(paymentMethod);
		await paymentMethodRepository.SaveAsync();
		
		// return created payment method
		return Results.Created($"/payment-methods/{paymentMethod.Id}", paymentMethod);
	}

	private async Task<IResult> Put([FromBody] PaymentMethod paymentMethod,
		[FromServices] IPaymentMethodRepository paymentMethodRepository)
	{
		// update payment method in the database
		await paymentMethodRepository.UpdateAsync(paymentMethod);
		await paymentMethodRepository.SaveAsync();
		
		return Results.NoContent();
	}

	private async Task<IResult> Delete([FromRoute] int id,
		[FromServices] IPaymentMethodRepository paymentMethodRepository)
	{
		// delete payment method from the database
		await paymentMethodRepository.DeleteAsync(id);
		await paymentMethodRepository.SaveAsync();
		
		return Results.NoContent();
	}
}