using System;

namespace GiftRAP.Discounts
{
	public class Coupon : DatedDiscount
	{
		private readonly Guid _productAppliesTo;

		internal Coupon(Guid productAppliesTo)
		{
			_productAppliesTo = productAppliesTo;
		}

		internal override bool DoesApplyTo(Product product)
		{
			return product.Id == _productAppliesTo;
		}
	}
}