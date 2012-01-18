using System;
using System.Collections.Generic;

namespace Acme.Taxes
{
	internal class PercentageTaxPolicy : TaxPolicy
	{
		private readonly decimal _rate;
		private readonly Func<OrderedProduct, decimal> _taxableAmountPolicy;
		private readonly Func<Order, IEnumerable<OrderedProduct>> _taxableItemsPolicy;

		public PercentageTaxPolicy(	decimal rate, 
									Func<OrderedProduct, decimal> taxableAmountPolicy, 
									Func<Order, IEnumerable<OrderedProduct>> taxibleItemsPolicy, 
									ITaxPolicy previousPolicy = null)
			: base(previousPolicy)
		{
			_rate = rate;
			_taxableAmountPolicy = taxableAmountPolicy;
			_taxableItemsPolicy = taxibleItemsPolicy;
		}

		protected override void ApplyTaxesImpl(Order order)
		{
			foreach (OrderedProduct orderedProduct in _taxableItemsPolicy(order))
			{
				orderedProduct.TaxAmount +=  _taxableAmountPolicy(orderedProduct) * _rate;
			}
		}
	}
}