namespace Acme.Discounts
{
	public class Promotion : DatedDiscount
	{
		internal override bool DoesApplyTo(Product product)
		{
			return true;
		}
	}
}