using GiftRAP.Discounts;
using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningPromotions
{
	[TestFixture]
	public class WhenTenPercentPromotionAndTwentyPercentCouponIsAppliedToTenDollarOrderInStateWithNoTaxes
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(5);
			Promotion promotion = CreatePromotion.WithDiscountOf(.1m);
			Coupon coupon = CreateCoupon.For(product).WithDiscountOf(.2m);
			_order = CreateOrder.Of(product, product).Apply(promotion, coupon).In(StateOf.UT);
		}

		[Test] public void ShouldTotalOrderToSevenDollars()
		{
			_order.Total.ShouldEqual(7m);
		}
	}
}