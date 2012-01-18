using NUnit.Framework;

namespace Acme.Tests.ConcerningOrders
{
	[TestFixture]
	public class When_order_has_no_products_in_it
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of().In(StateOf.GA);
		}

		[Test] public void Should_total_to_zero_dollars()
		{
			_order.Total.ShouldEqual(0m);
		}
	}
}