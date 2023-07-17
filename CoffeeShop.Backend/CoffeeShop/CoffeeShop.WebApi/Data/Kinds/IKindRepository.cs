namespace CoffeeShop.WebApi.Data.Kinds;

/// <summary>
/// Repository for the <see cref="Kind"/> entity
/// </summary>
public interface IKindRepository
{
	/// <summary>
	/// Gets all <see cref="Kind"/> entities
	/// </summary>
	/// <returns>List of <see cref="Kind"/> entities</returns>
	Task<List<Kind>> GetAsync();

	/// <summary>
	/// Gets a <see cref="Kind"/> entity by its id
	/// </summary>
	/// <param name="id">Id of <see cref="Kind"/> entity</param>
	/// <returns></returns>
	Task<Kind> GetAsync(int id);

	/// <summary>
	/// Inserts a <see cref="Kind"/> entity
	/// </summary>
	/// <param name="kind">Inserting <see cref="Kind"/> entity</param>
	/// <returns></returns>
	Task InsertAsync(Kind kind);

	/// <summary>
	/// Updates a <see cref="Kind"/> entity
	/// </summary>
	/// <param name="kind">New instance of <see cref="Kind"/> entity</param>
	/// <returns></returns>
	Task UpdateAsync(Kind kind);

	/// <summary>
	/// Deletes a <see cref="Kind"/> entity
	/// </summary>
	/// <param name="id">Id of <see cref="Kind"/> entity</param>
	/// <returns></returns>
	Task DeleteAsync(int id);

	/// <summary>
	/// Saves changes to the database
	/// </summary>
	/// <returns></returns>
	Task SaveAsync();
}