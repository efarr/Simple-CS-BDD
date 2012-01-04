using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningSpecificStates
{
	[TestFixture]
	public class WhenOneLuxuryProductAtTenDollarsIsInOrderInFloridaWithTenPercentPromotion
	{
		private Order _order;
		[TestFixtureSetUp]
		public void Context()
		{
			_order = CreateOrder.Of(new Product(10){IsLuxuryItem = true}).Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.FL);
		}

		[Test]
		public void ShouldTotalToTenDollars()
		{
			_order.Total.ShouldEqual(10m);
		}

		[Test]
		public void ShouldPreTaxTotalToNineDollars()
		{
			_order.PreTaxTotal.ShouldEqual(9m);
		}

		[Test]
		public void ShouldHaveTaxesOfOneDollar()
		{
			_order.Tax.ShouldEqual(1m);
		}
	}
}