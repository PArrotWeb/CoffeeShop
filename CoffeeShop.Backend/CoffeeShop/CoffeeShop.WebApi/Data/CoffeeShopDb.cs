using CoffeeShop.WebApi.Data.Kinds;
using CoffeeShop.WebApi.Data.Orders;
using CoffeeShop.WebApi.Data.PaymentMethods;

namespace CoffeeShop.WebApi.Data;

/// <summary>
/// Database context for the CoffeeShop database.
/// </summary>
public class CoffeeShopDb : DbContext
{

	public CoffeeShopDb(DbContextOptions<CoffeeShopDb> options) : base(options)
	{

	}

	public DbSet<Kind> Kinds => Set<Kind>();
	public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
	public DbSet<Order> Orders => Set<Order>();
}