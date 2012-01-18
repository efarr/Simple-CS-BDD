using NUnit.Framework;

namespace Acme.Tests.ConcerningTaxes
{
	[TestFixture]
    public class When_fixed_amount_taxes_applied_to_order_with_no_products_in_it
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of().Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.AR);
		}

		[Test] public void Should_total_to_zero_dollars()
		{
			_order.Total.ShouldEqual(0m);
		}
	}
}