using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningTaxes
{
	[TestFixture]
	public class WhenFlatStateTaxIsOneDollarOnATenDollarOrder
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).In(StateOf.AR);
		}

		[Test] public void ShouldCalculateTaxAtOneDollar()
		{
			_order.Tax.ShouldEqual(1m);
		}

		[Test] public void ShouldCalculateOrderTotalAtElevenDollars()
		{
			_order.Total.ShouldEqual(11m);
		}

		[Test] public void ShouldCalculatePreTaxTotalAtTenDollars()
		{
			_order.PreTaxTotal.ShouldEqual(10m);
		}
	}
}