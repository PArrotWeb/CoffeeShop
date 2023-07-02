using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShopWebApi.Data;

public class CoffeeShopDb : DbContext
{

	public CoffeeShopDb(DbContextOptions<CoffeeShopDb> options) : base(options)
	{

	}

	public DbSet<Kind> Kinds => Set<Kind>();
	public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();
	public DbSet<Order> Orders => Set<Order>();
}