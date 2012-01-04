using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningTaxes
{
	[TestFixture]
	public class WhenOrderIsMillaryInStateWithNoTaxesForMillitary
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).ByMillitaryMember().In(StateOf.CA);
		}

		[Test] public void ShouldChargeNoTaxes()
		{
			_order.Tax.ShouldEqual(0m);
		}
	}
}