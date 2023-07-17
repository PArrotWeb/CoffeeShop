namespace CoffeeShop.WebApi.Data.PaymentMethods;

/// <summary>
/// Entity for the PaymentMethod table
/// </summary>
public class PaymentMethod
{
	/// <summary>
	/// Id of the PaymentMethod
	/// </summary>
	public int Id { get; set; }

	/// <summary>
	/// Name of the PaymentMethod
	/// </summary>
	public string Name { get; set; } = null!;
}