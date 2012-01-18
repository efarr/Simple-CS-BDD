namespace Acme.Taxes
{
	public interface ITaxPolicy
	{
		void ApplyTaxes(Order order);
	}
}