using Acme.Discounts;

namespace Acme
{
	internal class OrderedProduct
	{
		private readonly Product _product;

		public OrderedProduct(Product product)
		{
			_product = product;
		}

		private AppliedDiscount _appliedDiscount;

		internal void ApplyDiscount(DatedDiscount datedDiscount)
		{
			if (datedDiscount.DoesApplyTo(_product))
				_appliedDiscount = new AppliedDiscount(datedDiscount.DiscountPercent, _appliedDiscount);
		}

		private decimal AppliedDiscounts { get { return _appliedDiscount == null ? 0m : _appliedDiscount.GetDiscount(_product.Price); } }
		internal decimal DiscountedPrice { get { return _product.Price - AppliedDiscounts; } }
		internal decimal TotalPrice { get { return _product.Price + TaxAmount - AppliedDiscounts; } }
		internal decimal OriginalPrice { get { return _product.Price; } }
		internal bool IsLuxuryItem { get { return _product.IsLuxuryItem; } }
		internal decimal TaxAmount { get; set; }
	}
}