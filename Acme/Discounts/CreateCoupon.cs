using System;
using GiftRAP.Discounts;

namespace GiftRAP
{
	public static class CreateCoupon
	{
		public static Coupon For(Product product)
		{
			return	new Coupon(product.Id);
		}

		public static T Starting<T>(this T coupon, DateTime startingDate) where T : DatedDiscount
		{
			coupon.StartDate = startingDate;
			return coupon;
		}

		public static T Ending<T>(this T coupon, DateTime endingDate) where T : DatedDiscount
		{
			coupon.EndDate = endingDate;
			return coupon;
		}

		public static Coupon WithDiscountOf(this Coupon coupon, decimal discount)
		{
			coupon.DiscountPercent = discount;
			return coupon;
		}
	}
}