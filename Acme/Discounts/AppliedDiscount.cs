using System;

namespace Acme.Discounts
{
	internal class AppliedDiscount
	{
		private readonly decimal _discount;

		internal AppliedDiscount PreviousDiscount { get; set; }

		internal AppliedDiscount(decimal discount, AppliedDiscount previousDiscount = null)
		{
			PreviousDiscount = previousDiscount;
			_discount = discount;
		}

		internal decimal GetDiscount(decimal price)
		{
			decimal discount = 0m;

			if (PreviousDiscount != null)
				discount = PreviousDiscount.GetDiscount(price);

			// Don't allow discount to exceed price.
			return Math.Min(price, discount + (price*_discount));
		}
	}
}