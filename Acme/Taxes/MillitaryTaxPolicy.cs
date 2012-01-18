namespace Acme.Taxes
{
	public class MillitaryTaxPolicy : TaxPolicy
	{
		public MillitaryTaxPolicy(ITaxPolicy previousPolicy = null)
			: base(previousPolicy)
		{
		}

		protected override void ApplyTaxesImpl(Order order)
		{
			if (order.IsMillitary)
				foreach (OrderedProduct orderedProduct in order.Products)
				{
					orderedProduct.TaxAmount = 0;
				}
		}
	}
}