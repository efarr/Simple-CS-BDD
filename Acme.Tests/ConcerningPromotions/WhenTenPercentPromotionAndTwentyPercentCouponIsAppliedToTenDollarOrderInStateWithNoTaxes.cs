using Acme.Discounts;
using NUnit.Framework;

namespace Acme.Tests.ConcerningPromotions
{
	[TestFixture]
	public class When_ten_percent_promotion_and_twenty_percent_coupon_is_applied_to_ten_dollar_order_in_state_with_no_taxes
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(5);
			Promotion promotion = CreatePromotion.WithDiscountOf(.1m);
			Coupon coupon = CreateCoupon.For(product).WithDiscountOf(.2m);
			_order = CreateOrder.Of(product, product).Apply(promotion, coupon).In(StateOf.UT);
		}

		[Test] public void Should_total_order_to_seven_dollars()
		{
			_order.Total.ShouldEqual(7m);
		}
	}
}