using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningPromotions
{
	[TestFixture]
	public class WhenPromotionIsAppliedToItemOnOrderInPreDiscountTaxState
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).Apply(CreatePromotion.WithDiscountOf(.5m)).In(StateOf.FL);
		}

		[Test] public void ShouldCalculateTaxOnFullPrice()
		{
			_order.Tax.ShouldEqual(.50m);
		}
	}
}