using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningTaxes
{
	[TestFixture]
	public class WhenOrderIsNonMillaryInStateWithNoTaxesForMillitary
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).In(StateOf.CA);
		}

		[Test] public void ShouldChargeTaxes()
		{
			_order.Tax.ShouldEqual(1.1m);
		}
	}
}