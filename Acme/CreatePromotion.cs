using GiftRAP.Discounts;

namespace GiftRAP
{
	public static class CreatePromotion
	{
		public static Promotion WithDiscountOf(decimal discount)
		{
			return new Promotion {DiscountPercent = discount};
		}
	}
}