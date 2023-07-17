namespace CoffeeShop.WebApi.Data.Orders;

/// <summary>
/// Repository for the <see cref="Order"/> entity
/// </summary>
public interface IOrderRepository
{
	/// <summary>
	/// Gets all <see cref="Order"/> entities
	/// </summary>
	/// <returns>List of <see cref="Order"/> entities</returns>
	Task<List<Order>> GetAsync();

	/// <summary>
	/// Gets a <see cref="Order"/> entity by its id
	/// </summary>
	/// <param name="id">Id of <see cref="Order"/> entity</param>
	/// <returns></returns>
	Task<Order> GetAsync(int id);

	/// <summary>
	/// Inserts a <see cref="Order"/> entity
	/// </summary>
	/// <param name="order">Inserting <see cref="Order"/> entity</param>
	/// <returns></returns>
	Task InsertAsync(Order order);

	/// <summary>
	/// Updates a <see cref="Order"/> entity
	/// </summary>
	/// <param name="order">New instance of <see cref="Order"/> entity</param>
	/// <returns></returns>
	Task UpdateAsync(Order order);

	/// <summary>
	/// Deletes a <see cref="Order"/> entity
	/// </summary>
	/// <param name="id">Id of <see cref="Order"/> entity</param>
	/// <returns></returns>
	Task DeleteAsync(int id);

	/// <summary>
	/// Saves changes to the database
	/// </summary>
	/// <returns></returns>
	Task SaveAsync();
}