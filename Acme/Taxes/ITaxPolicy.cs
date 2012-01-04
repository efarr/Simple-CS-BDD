namespace GiftRAP.Taxes
{
	public interface ITaxPolicy
	{
		void ApplyTaxes(Order order);
	}
}