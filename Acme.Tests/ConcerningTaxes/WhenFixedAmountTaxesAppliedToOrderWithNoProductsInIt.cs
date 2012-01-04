using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningTaxes
{
	[TestFixture]
	public class WhenFixedAmountTaxesAppliedToOrderWithNoProductsInIt
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of().Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.AR);
		}

		[Test] public void ShouldTotalToZeroDollars()
		{
			_order.Total.ShouldEqual(0m);
		}
	}
}