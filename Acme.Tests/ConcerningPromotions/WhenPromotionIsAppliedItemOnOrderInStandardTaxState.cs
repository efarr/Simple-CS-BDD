using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningPromotions
{
	[TestFixture]
	public class WhenPromotionIsAppliedItemOnOrderInStandardTaxState
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10)).Apply(CreatePromotion.WithDiscountOf(.5m)).In(StateOf.NC);
		}

		[Test] public void ShouldCalculateTaxOnDiscountedPrice()
		{
			_order.Tax.ShouldEqual(.25m);
		}
	}
}