using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningTaxes
{
	[TestFixture] 
	public class When_taxes_calculate_to_fraction_of_penny
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			_order = CreateOrder.Of(new Product(10.01m)).In(StateOf.NC);
		}

		[Test] public void Should_be_rounded_to_nearest_penny()
		{
			_order.Total.ShouldEqual(10.51m);
		}
	}
}