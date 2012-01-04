﻿using System;
using GiftRAP.Discounts;
using NUnit.Framework;

namespace GiftRAP.Tests.ConcerningPromotions
{
	[TestFixture]
	public class WhenPromotionEndDateBeforeTheOrderDate
	{
		private Order _order;
		[TestFixtureSetUp] public void Context()
		{
			Product product = new Product(10);
			Promotion promotion = CreatePromotion.WithDiscountOf(.1m).Starting(DateTime.Now.AddDays(-4)).Ending(DateTime.Now.AddDays(-1));
			_order = CreateOrder.Of(product).On(DateTime.Now).Apply(promotion).In(StateOf.UT);
		}

		[Test] public void ShouldNotApplyDiscount()
		{
			_order.Total.ShouldEqual(10m);
		}
	}
}