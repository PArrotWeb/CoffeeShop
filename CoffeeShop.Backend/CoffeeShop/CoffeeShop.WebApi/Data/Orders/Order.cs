using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.WebApi.Data.Orders;

/// <summary>
/// Entity for the Order table
/// </summary>
public class Order
{
	/// <summary>
	/// Id of the Order
	/// </summary>
	public int Id { get; set; }
	
	/// <summary>
	/// Orderer name
	/// </summary>
	public string Name { get; set; } = null!;

	/// <summary>
	/// Orderer phone number
	/// </summary>
	public string Phone { get; set; } = null!;
	
	/// <summary>
	/// Orderer email 
	/// </summary>
	public string Email { get; set; } = null!;
	
	/// <summary>
	/// Orderer address
	/// </summary>
	public string Address { get; set; } = null!;
	
	/// <summary>
	/// Date of receipt of the order
	/// </summary>
	public DateTime Date { get; set; }
	
	/// <summary>
	/// Id of kind of coffee 
	/// </summary>
	[Column("id_kind")]
	public int KindId { get; set; }
	
	/// <summary>
	/// Id of PaymentMethod
	/// </summary>
	[Column("id_payment_method")]
	public int PaymentMethodId { get; set; }
	
	/// <summary>
	/// Additional information about the order
	/// </summary>
	public string Additional { get; set; } = null!;
}