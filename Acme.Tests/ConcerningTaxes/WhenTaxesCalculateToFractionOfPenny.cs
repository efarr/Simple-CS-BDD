using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningTaxes
{
	[TestFixture] 
	public class WhenTaxesCalculateToFractionOfPenny
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10.01m)).In(StateOf.NC);
		}

		[Test] public void ShouldBeRoundedToNearestPenny()
		{
			_order.Total.ShouldEqual(10.51m);
		}
	}
}