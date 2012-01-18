using Acme.Discounts;
using NUnit.Framework;

namespace Acme.Tests.ConcerningPromotions
{
	[TestFixture]
	public class When_ten_percent_promotion_is_applied_to_ten_dollar_order_in_state_with_no_taxes
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(5);
			Promotion promotion = new Promotion {DiscountPercent = .1m};
			_order = CreateOrder.Of(product, product).Apply(promotion).In(StateOf.UT);
		}

		[Test] public void Should_total_order_to_nine_dollars()
		{
			_order.Total.ShouldEqual(9m);
		}

		[Test] public void Should_pretax_total_order_to_nine_dollars()
		{
			_order.Total.ShouldEqual(9m);
		}
	}
}