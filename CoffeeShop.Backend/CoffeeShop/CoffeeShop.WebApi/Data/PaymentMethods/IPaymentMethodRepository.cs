namespace CoffeeShop.WebApi.Data.PaymentMethods;

/// <summary>
/// Repository for the <see cref="PaymentMethod"/> entity
/// </summary>
public interface IPaymentMethodRepository
{
	/// <summary>
	/// Gets all <see cref="PaymentMethod"/> entities
	/// </summary>
	/// <returns>List of <see cref="PaymentMethod"/> entities</returns>
	Task<List<PaymentMethod>> GetAsync();

	/// <summary>
	/// Gets a <see cref="PaymentMethod"/> entity by its id
	/// </summary>
	/// <param name="id">Id of <see cref="PaymentMethod"/> entity</param>
	/// <returns></returns>
	Task<PaymentMethod> GetAsync(int id);

	/// <summary>
	/// Inserts a <see cref="PaymentMethod"/> entity
	/// </summary>
	/// <param name="paymentMethod">Inserting <see cref="PaymentMethod"/> entity</param>
	/// <returns></returns>
	Task InsertAsync(PaymentMethod paymentMethod);

	/// <summary>
	/// Updates a <see cref="PaymentMethod"/> entity
	/// </summary>
	/// <param name="paymentMethod">New instance of <see cref="PaymentMethod"/> entity</param>
	/// <returns></returns>
	Task UpdateAsync(PaymentMethod paymentMethod);

	/// <summary>
	/// Deletes a <see cref="PaymentMethod"/> entity
	/// </summary>
	/// <param name="id">Id of <see cref="PaymentMethod"/> entity</param>
	/// <returns></returns>
	Task DeleteAsync(int id);

	/// <summary>
	/// Saves changes to the database
	/// </summary>
	/// <returns></returns>
	Task SaveAsync();
}