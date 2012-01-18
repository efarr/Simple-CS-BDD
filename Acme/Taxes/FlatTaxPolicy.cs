using System.Linq;

namespace Acme.Taxes
{
	public class FlatTaxPolicy : TaxPolicy
	{
		private readonly decimal _fixedTax;

		public FlatTaxPolicy(decimal fixedTax, ITaxPolicy previousPolicy = null)
			: base(previousPolicy)
		{
			_fixedTax = fixedTax;
		}

		protected override void ApplyTaxesImpl(Order order)
		{
			if (order.Products.Count() > 0)
			{
				// Allocate the fixed amount over the items in the order.
				decimal allocatedTaxes = _fixedTax / order.Products.Count();
				foreach (OrderedProduct orderedProduct in order.Products)
				{
					orderedProduct.TaxAmount = allocatedTaxes;
				}
			}
		}
	}
}