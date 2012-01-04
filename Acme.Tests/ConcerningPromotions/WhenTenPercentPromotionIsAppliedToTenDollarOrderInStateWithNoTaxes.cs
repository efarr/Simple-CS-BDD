using GiftRAP.Discounts;
using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningPromotions
{
	[TestFixture]
	public class WhenTenPercentPromotionIsAppliedToTenDollarOrderInStateWithNoTaxes
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(5);
			Promotion promotion = new Promotion {DiscountPercent = .1m};
			_order = CreateOrder.Of(product, product).Apply(promotion).In(StateOf.UT);
		}

		[Test] public void ShouldTotalOrderToNineDollars()
		{
			_order.Total.ShouldEqual(9m);
		}

		[Test] public void ShouldPreTaxTotalOrderToNineDollars()
		{
			_order.Total.ShouldEqual(9m);
		}
	}
}