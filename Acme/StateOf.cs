using System;
using System.Collections.Generic;
using System.Linq;
using Acme.Taxes;

namespace Acme
{
	public static class StateOf
	{
		public static ITaxPolicy GA { get { return CreateTaxPolicy.WithSimpleRateOf(.055m); } }
		public static ITaxPolicy TN { get { return CreateTaxPolicy.WithSimpleRateOf(.04m); } }
		public static ITaxPolicy UT { get { return CreateTaxPolicy.WithSimpleRateOf(0m); } }
		public static ITaxPolicy AR { get { return new FlatTaxPolicy(1m); } }
		public static ITaxPolicy NM { get { return CreateTaxPolicy.WithPreDiscountRateOf(.07m); } }
		public static ITaxPolicy NV { get { return CreateTaxPolicy.WithPreDiscountRateOf(.07m); } }
		public static ITaxPolicy FL { get { return CreateTaxPolicy.WithPreDiscountAndLuxuryRateOf(.05m); } }
		public static ITaxPolicy NC { get { return CreateTaxPolicy.WithSimpleRateAndLuxuryTaxOf(.05m); } }
		public static ITaxPolicy CA { get { return new MillitaryTaxPolicy(CreateTaxPolicy.WithSimpleRateAndLuxuryTaxOf(.11m)); } }
	}

	/// <summary>
	/// Helper methods to build the various combinations of tax policies.
	/// </summary>
	internal static class CreateTaxPolicy
	{
		internal static ITaxPolicy WithSimpleRateOf(decimal rate)
		{
			return new PercentageTaxPolicy(rate, orderedProduct => orderedProduct.DiscountedPrice, order => order.Products);
		}

		internal static ITaxPolicy WithSimpleRateAndLuxuryTaxOf(decimal rate)
		{
			Func<OrderedProduct, decimal> discountedPrices = op => op.DiscountedPrice;
			Func<Order, IEnumerable<OrderedProduct>> allItems = order => order.Products;
			Func<Order, IEnumerable<OrderedProduct>> luxuryItems = order => order.Products.Where(p => p.IsLuxuryItem);

			ITaxPolicy baseTaxes = new PercentageTaxPolicy(rate, discountedPrices, allItems);
			return new PercentageTaxPolicy(rate, discountedPrices, luxuryItems, baseTaxes);
		}

		internal static ITaxPolicy WithPreDiscountRateOf(decimal rate)
		{
			return new PercentageTaxPolicy(rate, orderedProduct => orderedProduct.OriginalPrice, order => order.Products);
		}

		internal static ITaxPolicy WithPreDiscountAndLuxuryRateOf(decimal rate)
		{
			Func<OrderedProduct, decimal> originalPrices = op => op.OriginalPrice;
			Func<Order, IEnumerable<OrderedProduct>> allItems = order => order.Products;
			Func<Order, IEnumerable<OrderedProduct>> luxuryItems = order => order.Products.Where(p => p.IsLuxuryItem);

			ITaxPolicy baseTaxes = new PercentageTaxPolicy(rate, originalPrices, allItems);
			return new PercentageTaxPolicy(rate, originalPrices, luxuryItems, baseTaxes);
		}
	}
}