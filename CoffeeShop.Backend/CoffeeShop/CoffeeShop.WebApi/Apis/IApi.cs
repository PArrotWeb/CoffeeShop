namespace CoffeeShop.WebApi.Apis;

/// <summary>
/// Interface for API registration
/// </summary>
public interface IApi
{
	/// <summary>
	/// Register API
	/// </summary>
	/// <param name="app">Web application</param>
	void Register(WebApplication app);
}