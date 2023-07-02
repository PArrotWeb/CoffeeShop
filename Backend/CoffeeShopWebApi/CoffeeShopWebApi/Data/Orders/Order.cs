using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopWebApi.Data.Orders;

public class Order
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Phone { get; set; }
	public string Email { get; set; }
	public string Address { get; set; }
	public DateTime Date { get; set; }
	
	[Column("id_kind")]
	public int KindId { get; set; }
	
	[Column("id_payment_method")]
	public int PaymentMethodId { get; set; }
	public string Additional { get; set; }
}