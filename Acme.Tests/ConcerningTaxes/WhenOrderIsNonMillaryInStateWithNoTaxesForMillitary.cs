using NUnit.Framework;

namespace Acme.Tests.ConcerningTaxes
{
	[TestFixture]
	public class When_order_is_nonmillary_in_state_with_no_taxes_for_millitary
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).In(StateOf.CA);
		}

		[Test] public void Should_charge_taxes()
		{
			_order.Tax.ShouldEqual(1.1m);
		}
	}
}