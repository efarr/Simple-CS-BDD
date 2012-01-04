using GiftRAP.Discounts;
using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningCoupons
{
	[TestFixture]
	public class When_coupon_applied_to_order_does_not_match_product_in_order
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product productInOrder = new Product(10m);
			Product productNotInOrder = new Product(20m);
			Coupon coupon = CreateCoupon.For(productNotInOrder).WithDiscountOf(.1m);
			_order = CreateOrder.Of(productInOrder).Apply(coupon).In(StateOf.UT);
		}

		[Test] public void Should_not_apply_discount()
		{
			_order.Total.ShouldEqual(10m);
		}
	}
}