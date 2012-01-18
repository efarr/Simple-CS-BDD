using NUnit.Framework;

namespace Acme.Tests.ConcerningTaxes
{
	[TestFixture]
	public class When_order_has_luxury_product_priced_at_ten_dollars_and_nonluxury_product_priced_at_ten_dollars_in_state_with_luxury_tax_and_tax_rate_of_five_percent
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10) {IsLuxuryItem = true}, new Product(10)).In(StateOf.FL);
		}

		[Test] public void Should_have_taxes_of_one_dollar_and_fifty_cents()
		{
			_order.Tax.ShouldEqual(1.5m);
		}

		[Test] public void Should_calculate_total_at_twenty_one_fifty()
		{
			_order.Total.ShouldEqual(21.5m);
		}

		[Test] public void Should_calculate_pretax_total_at_twenty_dollars()
		{
			_order.PreTaxTotal.ShouldEqual(20m);
		}
	}
}