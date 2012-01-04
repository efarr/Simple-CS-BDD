using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningOrders
{
	[TestFixture]
	public class When_product_priced_at_ten_dollars_is_added_to_order_in_state_with_no_taxes
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).In(StateOf.UT);
		}

		[Test] public void Should_total_to_ten_dollars()
		{
			_order.Total.ShouldEqual(10m);
		}

		[Test] public void Should_pretax_total_to_ten_dollars()
		{
			_order.PreTaxTotal.ShouldEqual(10m);
		}

		[Test] public void Should_have_zero_tax()
		{
			_order.Tax.ShouldEqual(0m);
		}
	}
}
