namespace CoffeeShop.WebApi.Data.Kinds;

/// <summary>
/// Implementation of <see cref="IKindRepository"/>
/// </summary>
public sealed class KindRepository : IKindRepository
{

	public KindRepository(CoffeeShopDb context)
	{
		_context = context;
	}

	#region IKindRepository Members
	public async Task<List<Kind>> GetAsync()
	{
		var kinds = await _context.Kinds.ToListAsync();
		if (kinds is null) throw new Exception("Kinds not found");
		return kinds;
	}

	public async Task<Kind> GetAsync(int id)
	{
		var kind = await _context.Kinds.FindAsync(id);
		if (kind is null) throw new Exception("Kind not found");
		return kind;
	}

	public async Task InsertAsync(Kind kind)
	{
		await _context.Kinds.AddAsync(kind);
	}

	public async Task UpdateAsync(Kind kind)
	{
		var kindFromDb = await _context.Kinds.FindAsync(kind.Id);
		if (kindFromDb is null) throw new Exception("Kind not found");
		kindFromDb.Title = kind.Title;
		kindFromDb.Description = kind.Description;
	}

	public async Task DeleteAsync(int id)
	{
		var kindFromDb = await _context.Kinds.FindAsync(id);
		if (kindFromDb is null) throw new Exception("Kind not found");
		_context.Kinds.Remove(kindFromDb);
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