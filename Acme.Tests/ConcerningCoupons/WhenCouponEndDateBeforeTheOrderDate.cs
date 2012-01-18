using System;
using Acme.Discounts;
using NUnit.Framework;

namespace Acme.Tests.ConcerningCoupons
{
	[TestFixture]
	public class When_coupon_end_date_before_the_order_date
	{
		private Order _order;
		[TestFixtureSetUp]
		public void Context()
		{
			Product product = new Product(10);
			Coupon coupon = CreateCoupon.For(product).Starting(DateTime.Now.AddDays(-4)).Ending(DateTime.Now.AddDays(-1)).WithDiscountOf(.1m);
			_order = CreateOrder.Of(product).On(DateTime.Now).Apply(coupon).In(StateOf.UT);
		}

		[Test]
		public void Should_not_apply_discount()
		{
			_order.Total.ShouldEqual(10m);
		}
	}
}