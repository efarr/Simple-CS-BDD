using System;

namespace GiftRAP.Sample
{
	/// <summary>
	/// Just enough to give you the idea
	/// </summary>
	class Program
	{
		static void Main()
		{
			Sample1();
			Sample2();
			Sample3();
			Sample4();
			Sample5();
		}

		private static void Sample1()
		{
			Product luxuryProduct = new Product(10) { IsLuxuryItem = true };
			Product nonLuxuryProduct = new Product(10);
			Order order = CreateOrder.Of(luxuryProduct, nonLuxuryProduct).Apply(CreatePromotion.WithDiscountOf(.1m)).In(StateOf.FL);

			DisplayOrder(order, "Order in Florida (5% tax rate) with $10 luxury item and $10 non-luxury item and 10% promotion:");
		}

		private static void Sample2()
		{
			Product luxuryProduct = new Product(10) { IsLuxuryItem = true };
			Product nonLuxuryProduct = new Product(10);
			Order order = CreateOrder.Of(luxuryProduct, nonLuxuryProduct).
										Apply(CreatePromotion.WithDiscountOf(.1m), CreateCoupon.For(nonLuxuryProduct).WithDiscountOf(.5m)).
										In(StateOf.FL);

			DisplayOrder(order, "Order in Florida (5% tax rate) with $10 luxury item and $10 non-luxury item and 10% promotion and 50% coupon on non-luxury item:");
		}

		private static void Sample3()
		{
			Product luxuryProduct = new Product(10) { IsLuxuryItem = true };
			Product nonLuxuryProduct = new Product(10);
			Order order = CreateOrder.Of(luxuryProduct, nonLuxuryProduct).
										Apply(CreatePromotion.WithDiscountOf(.1m), CreateCoupon.For(nonLuxuryProduct).WithDiscountOf(.5m)).
										In(StateOf.NC);

			DisplayOrder(order, "Order in North Carolina (5% tax rate) with $10 luxury item and $10 non-luxury item and 10% promotion and 50% coupon on non-luxury item:");
		}

		private static void Sample4()
		{
			Product luxuryProduct = new Product(10) { IsLuxuryItem = true };
			Product nonLuxuryProduct = new Product(10);
			Order order = CreateOrder.Of(luxuryProduct, nonLuxuryProduct).
										Apply(CreatePromotion.WithDiscountOf(.1m), CreateCoupon.For(luxuryProduct).WithDiscountOf(.5m)).
										In(StateOf.FL);

			DisplayOrder(order, "Order in Florida (5% tax rate) with $10 luxury item and $10 non-luxury item and 10% promotion and 50% coupon on luxury item:");
		}

		private static void Sample5()
		{
			Product luxuryProduct = new Product(10) { IsLuxuryItem = true };
			Product nonLuxuryProduct = new Product(10);
			Order order = CreateOrder.Of(luxuryProduct, nonLuxuryProduct).
										Apply(CreatePromotion.WithDiscountOf(.1m), CreateCoupon.For(luxuryProduct).WithDiscountOf(.5m)).
										In(StateOf.NC);

			DisplayOrder(order, "Order in North Carolina (5% tax rate) with $10 luxury item and $10 non-luxury item and 10% promotion and 50% coupon on luxury item:");
		}

		private static void DisplayOrder(Order order, string description)
		{
			Console.WriteLine(description);
			Console.WriteLine("Total before taxes: ${0}", order.PreTaxTotal);
			Console.WriteLine("Taxes: ${0}", order.Tax);
			Console.WriteLine("Total: ${0}", order.Total);
			Console.WriteLine();
		}
	}
}
