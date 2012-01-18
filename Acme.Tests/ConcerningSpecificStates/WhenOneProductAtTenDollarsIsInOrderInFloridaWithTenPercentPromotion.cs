using NUnit.Framework;

namespace Acme.Tests.ConcerningSpecificStates
{
	[TestFixture]
	public class WhenOneProductAtTenDollarsIsInOrderInFloridaWithTenPercentPromotion
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.FL);
		}

		[Test] public void ShouldTotalToNineDollarsAndFiftyCents()
		{
			_order.Total.ShouldEqual(9.5m);
		}

		[Test] public void ShouldPreTaxTotalToNineDollars()
		{
			_order.PreTaxTotal.ShouldEqual(9m);
		}

		[Test] public void ShouldHaveTaxesOfFiftyCents()
		{
			_order.Tax.ShouldEqual(.5m);
		}
	}
}