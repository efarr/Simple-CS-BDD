using NUnit.Framework;

namespace Acme.Tests.ConcerningPromotions
{
	[TestFixture]
	public class When_promotion_is_applied_item_on_order_in_standard_tax_state
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).Apply(CreatePromotion.WithDiscountOf(.5m)).In(StateOf.NC);
		}

		[Test] public void Should_calculate_tax_on_discounted_price()
		{
			_order.Tax.ShouldEqual(.25m);
		}
	}
}