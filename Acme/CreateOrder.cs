using System;
using Acme.Discounts;
using Acme.Taxes;

namespace Acme
{
	public static class CreateOrder
	{
		public static Order In(this Order order, ITaxPolicy taxPolicy)
		{
			order.ApplyTaxPolicy(taxPolicy);
			return order;
		}

		public static Order Of(params Product[] products)
		{
			Order order = new Order();

			foreach (Product product in products)
			{
				order.Add(product);
			}

			return order;
		}

		public static Order Apply(this Order order, params DatedDiscount[] datedDiscounts)
		{
			foreach (DatedDiscount datedDiscount in datedDiscounts)
			{
				order.ApplyDiscount(datedDiscount);
			}

			return order;
		}

		public static Order On(this Order order, DateTime orderDate)
		{
			order.OrderDate = orderDate;
			return order;
		}

		public static Order ByMillitaryMember(this Order order)
		{
			order.IsMillitary = true;
			return order;
		}
	}
}