using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningOrders
{
	[TestFixture]
	public class When_simple_state_tax_is_five_point_five_percent_on_a_ten_dollar_order
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).In(StateOf.GA);
		}

		[Test] public void Should_total_to_ten_dollars_and_fifty_five_cents()
		{
			_order.Total.ShouldEqual(10.55m);
		}

		[Test] public void Should_pretax_total_to_ten_dollars()
		{
			_order.PreTaxTotal.ShouldEqual(10m);
		}

		[Test] public void Should_have_fifty_five_cents_tax()
		{
			_order.Tax.ShouldEqual(.55m);
		}
	}
}