using GiftRAP.Discounts;
using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningCoupons
{
	[TestFixture]
    public class When_coupon_is_applied_to_item_on_order_in_standard_tax_state
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(10);
			Coupon coupon = CreateCoupon.For(product).WithDiscountOf(.5m);
			_order = CreateOrder.Of(product).Apply(coupon).In(StateOf.NC);
		}

		[Test] public void Should_calculate_tax_on_discounted_price()
		{
			_order.Tax.ShouldEqual(.25m);
		}
	}
}