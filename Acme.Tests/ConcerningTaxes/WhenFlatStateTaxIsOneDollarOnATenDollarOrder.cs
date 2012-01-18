using NUnit.Framework;

namespace Acme.Tests.ConcerningTaxes
{
	[TestFixture]
	public class When_flat_state_tax_is_one_dollar_on_a_ten_dollar_order
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).In(StateOf.AR);
		}

		[Test] public void Should_calculate_tax_at_one_dollar()
		{
			_order.Tax.ShouldEqual(1m);
		}

		[Test] public void Should_calculate_order_total_at_eleven_dollars()
		{
			_order.Total.ShouldEqual(11m);
		}

		[Test] public void Should_calculate_pretax_total_at_ten_dollars()
		{
			_order.PreTaxTotal.ShouldEqual(10m);
		}
	}
}