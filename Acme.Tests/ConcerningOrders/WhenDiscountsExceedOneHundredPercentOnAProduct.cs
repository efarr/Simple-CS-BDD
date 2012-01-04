using System;
using GiftRAP.Discounts;
using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningOrders
{
	[TestFixture]
	public class When_discounts_exceed_one_hundred_percent_on_a_product
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product1 = new Product(10);
			Product product2 = new Product(10);
			Coupon coupon1 = CreateCoupon.For(product1).Starting(DateTime.Now).Ending(DateTime.Now).WithDiscountOf(.75m);
			Coupon coupon2 = CreateCoupon.For(product1).Starting(DateTime.Now).Ending(DateTime.Now).WithDiscountOf(.50m);
			_order = CreateOrder.Of(product1, product2).On(DateTime.Now).Apply(coupon1, coupon2).In(StateOf.UT);
		}

		[Test] public void Should_price_product_at_zero_dollars()
		{
			_order.Total.ShouldEqual(10m);
		}
	}
}