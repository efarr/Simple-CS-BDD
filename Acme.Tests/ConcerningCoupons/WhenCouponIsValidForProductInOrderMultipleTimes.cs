using Acme.Discounts;
using NUnit.Framework;

namespace Acme.Tests.ConcerningCoupons
{
	[TestFixture]
	public class When_coupon_is_valid_for_product_in_order_multiple_times
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(10);
			Coupon coupon = CreateCoupon.For(product).WithDiscountOf(.1m);
			_order = CreateOrder.Of(product, product).Apply(coupon).In(StateOf.UT);
		}

		[Test] public void Should_apply_discount_to_entire_quantity_of_discounted_product()
		{
			_order.Total.ShouldEqual(10m * 2m * .9m);
		}
	}
}