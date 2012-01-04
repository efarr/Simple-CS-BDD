using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningSpecificStates
{
	[TestFixture]
	public class WhenOneLuxuryProductAtTenDollarsIsInOrderInNorthCarolinaWithTenPercentPromotion
	{
		private Order _order;
		[TestFixtureSetUp]
		public void Context()
		{
			_order = CreateOrder.Of(new Product(10){IsLuxuryItem = true}).Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.NC);
		}

		[Test]
		public void ShouldTotalToNineDollarsAndNinetyCents()
		{
			_order.Total.ShouldEqual(9.9m);
		}

		[Test]
		public void ShouldPreTaxTotalToNineDollars()
		{
			_order.PreTaxTotal.ShouldEqual(9m);
		}

		[Test]
		public void ShouldHaveTaxesOfNinetyCents()
		{
			_order.Tax.ShouldEqual(.9m);
		}
	}
}