using CoffeeShop.WebApi.Data.Kinds;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.WebApi.Apis;

/// <summary>
/// API for kinds
/// </summary>
public class KindsApi : IApi
{

	#region IApi Members
	public void Register(WebApplication app)
	{
		app.MapGet("/kinds", Get)
			.Produces<List<Kind>>()
			.WithName("GetAllKinds")
			.WithTags("Kinds");

		app.MapGet("/kinds/{id:int}", GetById)
			.Produces<List<Kind>>()
			.WithName("GetKind")
			.WithTags("Kinds");

		app.MapPost("/kinds", Post)
			.Accepts<Kind>("application/json")
			.WithName("CreateKind")
			.WithTags("Kinds");

		app.MapPut("/kinds", Put)
			.Accepts<Kind>("application/json")
			.WithName("UpdateKind")
			.WithTags("Kinds");

		app.MapDelete("/kinds/{id:int}", Delete)
			.WithName("DeleteKind")
			.WithTags("Kinds");
	}
	#endregion

	private async Task<IResult> Get([FromServices] IKindRepository kindRepository)
	{
		// return all kinds from database
		return Results.Ok(await kindRepository.GetAsync());
	}

	private async Task<IResult> GetById([FromRoute] int id, [FromServices] IKindRepository kindRepository)
	{
		// get kind by id from database
		return await kindRepository.GetAsync(id) is { } kind
			? Results.Ok(kind)
			: Results.NotFound();
	}

	private async Task<IResult> Post([FromBody] Kind kind, [FromServices] IKindRepository kindRepository)
	{
		// insert kind into database
		await kindRepository.InsertAsync(kind);
		await kindRepository.SaveAsync();

		// return created kind
		return Results.Created($"/kinds/{kind.Id}", kind);
	}

	private async Task<IResult> Put([FromBody] Kind kind, [FromServices] IKindRepository kindRepository)
	{
		// update kind in database
		await kindRepository.UpdateAsync(kind);
		await kindRepository.SaveAsync();

		return Results.NoContent();
	}

	private async Task<IResult> Delete([FromRoute] int id, [FromServices] IKindRepository kindRepository)
	{
		// delete kind by id from database
		await kindRepository.DeleteAsync(id);
		await kindRepository.SaveAsync();

		return Results.NoContent();
	}
}