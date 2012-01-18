using System;
using System.Collections.Generic;
using System.Linq;
using Acme.Discounts;
using Acme.Taxes;

namespace Acme
{
	public class Order
	{
		internal Order()
		{
			OrderDate = DateTime.Now;
		}

		private readonly IList<OrderedProduct> _products = new List<OrderedProduct>();
		internal IEnumerable<OrderedProduct> Products { get { return _products; } }
		public void Add(Product product)
		{
			_products.Add(new OrderedProduct(product));
		}

		public void ApplyDiscount(DatedDiscount datedDiscount)
		{
			if (datedDiscount.IsValidOn(OrderDate))
				foreach (OrderedProduct orderedProduct in Products)
				{
					orderedProduct.ApplyDiscount(datedDiscount);
				}
		}

		public void ApplyTaxPolicy(ITaxPolicy taxPolicy)
		{
			taxPolicy.ApplyTaxes(this);
		}

		internal DateTime OrderDate { get; set; }
		internal bool IsMillitary { get; set; }

		public Money PreTaxTotal { get { return Total - Tax; } }
		public Money Tax { get { return Products.Sum(p => p.TaxAmount); } }
		public Money Total { get { return _products.Sum(p => (p.TotalPrice)); } }
	}
}