namespace CoffeeShopWebApi.Data.PaymentMethods;

public interface IPaymentMethodRepository
{
	Task<List<PaymentMethod>> GetAsync();

	Task<PaymentMethod> GetAsync(int id);

	Task InsertAsync(PaymentMethod kind);

	Task UpdateAsync(PaymentMethod kind);

	Task DeleteAsync(int id);

	Task SaveAsync();
}