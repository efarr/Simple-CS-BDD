using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningOrders
{
	[TestFixture]
	public class When_promotion_applied_to_order_with_no_products_in_it
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of().Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.GA);
		}

		[Test] public void Should_total_to_zero_dollars()
		{
			_order.Total.ShouldEqual(0m);
		}
	}
}