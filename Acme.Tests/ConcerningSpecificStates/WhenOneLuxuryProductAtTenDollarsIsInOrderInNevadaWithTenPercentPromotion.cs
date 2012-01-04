using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningSpecificStates
{
	[TestFixture]
	public class WhenOneLuxuryProductAtTenDollarsIsInOrderInNevadaWithTenPercentPromotion
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10) { IsLuxuryItem = true }).Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.NV);
		}

		[Test] public void ShouldTotalToNineSeventy()
		{
			_order.Total.ShouldEqual(9.7m);
		}

		[Test] public void ShouldPreTaxTotalToNineDollars()
		{
			_order.PreTaxTotal.ShouldEqual(9m);
		}

		[Test] public void ShouldHaveTaxesOfSeventyCents()
		{
			_order.Tax.ShouldEqual(.7m);
		}
	}
}