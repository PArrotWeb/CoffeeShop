namespace CoffeeShop.WebApi.Data.Orders;

/// <summary>
/// Implementation of <see cref="IOrderRepository" />
/// </summary>
public class OrderRepository : IOrderRepository
{

	private readonly CoffeeShopDb _context;

	private bool _disposed;

	public OrderRepository(CoffeeShopDb context)
	{
		_context = context;
	}

	#region IOrderRepository Members
	public async Task<List<Order>> GetAsync()
	{
		var orders = await _context.Orders.ToListAsync();
		if (orders is null)
		{
			throw new Exception("Orders not found");
		}
		return orders;
	}

	public async Task<Order> GetAsync(int id)
	{
		var order = await _context.Orders.FindAsync(id);
		if (order is null)
		{
			throw new Exception("Order not found");
		}
		return order;
	}

	public async Task InsertAsync(Order order)
	{
		await _context.Orders.AddAsync(order);
	}

	public async Task UpdateAsync(Order order)
	{
		var orderFromDb = await _context.Orders.FindAsync(order.Id);
		if (orderFromDb is null)
		{
			throw new Exception("Order not found");
		}

		orderFromDb.Name = order.Name;
		orderFromDb.Phone = order.Phone;
		orderFromDb.Email = order.Email;
		orderFromDb.Address = order.Address;
		orderFromDb.Date = order.Date;
		orderFromDb.KindId = order.KindId;
		orderFromDb.PaymentMethodId = order.PaymentMethodId;
		orderFromDb.Additional = order.Additional;
	}

	public async Task DeleteAsync(int id)
	{
		var orderFromDb = await _context.Orders.FindAsync(id);
		if (orderFromDb is null)
		{
			throw new Exception("Order not found");
		}
		_context.Orders.Remove(orderFromDb);
	}

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
	#endregion

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
		{
			return;
		}
		if (disposing)
		{
			_context.Dispose();
		}
		_disposed = true;
	}
}