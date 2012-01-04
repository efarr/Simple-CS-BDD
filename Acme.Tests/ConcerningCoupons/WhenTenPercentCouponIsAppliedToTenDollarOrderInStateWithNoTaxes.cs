using GiftRAP.Discounts;
using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningCoupons
{
	[TestFixture]
	public class When_ten_percent_coupon_is_applied_to_ten_dollar_order_in_state_with_no_taxes
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(10);
			Coupon coupon = CreateCoupon.For(product).WithDiscountOf(.1m);
			_order = CreateOrder.Of(product).Apply(coupon).In(StateOf.UT);
		}

		[Test] public void Should_total_order_to_nine_dollars()
		{
			_order.Total.ShouldEqual(9m);
		}
	}
}