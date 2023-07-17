namespace CoffeeShop.WebApi.Data.PaymentMethods;

/// <summary>
/// Implementation of <see cref="IPaymentMethodRepository"/>
/// </summary>
public sealed class PaymentMethodsRepository : IPaymentMethodRepository
{

	public PaymentMethodsRepository(CoffeeShopDb context)
	{
		_context = context;
	}

	#region IPaymentMethodRepository Members
	public async Task<List<PaymentMethod>> GetAsync()
	{
		var paymentMethods = await _context.PaymentMethods.ToListAsync();
		if (paymentMethods is null) throw new Exception("PaymentMethods not found");
		return paymentMethods;
	}

	public async Task<PaymentMethod> GetAsync(int id)
	{
		var paymentMethod = await _context.PaymentMethods.FindAsync(id);
		if (paymentMethod is null) throw new Exception("PaymentMethod not found");
		return paymentMethod;
	}

	public async Task InsertAsync(PaymentMethod paymentMethod)
	{
		await _context.PaymentMethods.AddAsync(paymentMethod);
	}

	public async Task UpdateAsync(PaymentMethod paymentMethod)
	{
		var paymentMethodFromDb = await _context.PaymentMethods.FindAsync(paymentMethod.Id);
		if (paymentMethodFromDb is null) throw new Exception("PaymentMethod not found");

		paymentMethodFromDb.Name = paymentMethod.Name;
	}

	public async Task DeleteAsync(int id)
	{
		var paymentMethodFromDb = await _context.PaymentMethods.FindAsync(id);
		if (paymentMethodFromDb is null) throw new Exception("PaymentMethod not found");
		_context.PaymentMethods.Remove(paymentMethodFromDb);
	}

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
	#endregion

	private readonly CoffeeShopDb _context;

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	private bool _disposed;
	private void Dispose(bool disposing)
	{
		if (_disposed) return;
		if (disposing) _context.Dispose();
		_disposed = true;
	}
}