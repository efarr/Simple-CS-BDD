using NUnit.Framework;

namespace Acme.Tests.ConcerningPromotions
{
	[TestFixture]
	public class When_promotion_is_applied_to_item_on_order_in_prediscount_tax_state
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).Apply(CreatePromotion.WithDiscountOf(.5m)).In(StateOf.FL);
		}

		[Test] public void Should_calculate_tax_on_full_price()
		{
			_order.Tax.ShouldEqual(.50m);
		}
	}
}