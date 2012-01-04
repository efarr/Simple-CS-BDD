using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningTaxes
{
	[TestFixture]
	public class WhenOrderHasLuxuryProductPricedAtTenDollarsAndNonLuxuryProductPricedAtTenDollarsInStateWithLuxuryTaxAndTaxRateOfFivePercent
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10) {IsLuxuryItem = true}, new Product(10)).In(StateOf.FL);
		}

		[Test] public void ShouldHaveTaxesOfOneDollarAndFiftyCents()
		{
			_order.Tax.ShouldEqual(1.5m);
		}

		[Test] public void ShouldCalculateTotalAtTwentyOneFifty()
		{
			_order.Total.ShouldEqual(21.5m);
		}

		[Test] public void ShouldCalculatePreTaxTotalAtTwentyDollars()
		{
			_order.PreTaxTotal.ShouldEqual(20m);
		}
	}
}