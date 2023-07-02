namespace CoffeeShopWebApi.Data.Orders;

public interface IOrderRepository
{
	Task<List<Order>> GetAsync();

	Task<Order> GetAsync(int id);

	Task InsertAsync(Order kind);

	Task UpdateAsync(Order kind);

	Task DeleteAsync(int id);

	Task SaveAsync();
}