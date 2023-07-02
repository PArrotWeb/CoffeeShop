namespace CoffeeShopWebApi.Data.Kinds;

public interface IKindRepository
{
	Task<List<Kind>> GetAsync();

	Task<Kind> GetAsync(int id);

	Task InsertAsync(Kind kind);

	Task UpdateAsync(Kind kind);

	Task DeleteAsync(int id);

	Task SaveAsync();
}