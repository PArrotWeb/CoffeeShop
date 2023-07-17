namespace CoffeeShop.WebApi.Data.Kinds;

/// <summary>
/// Entity for the Kind table
/// </summary>
public class Kind
{
	/// <summary>
	/// Id of the Kind
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Name of the Kind
	/// </summary>
	public string Title { get; set; } = null!;

	/// <summary>
	/// Description of the Kind
	/// </summary>
	public string Description { get; set; } = null!;
}