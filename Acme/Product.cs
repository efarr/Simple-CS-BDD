using System;

namespace Acme
{
	public class Product
	{
		public Guid Id { get; private set; }
		public decimal Price { get; private set; }
		public bool IsLuxuryItem { get; set; }

		public Product(decimal price)
		{
			Id = Guid.NewGuid();
			Price = price;
			IsLuxuryItem = false;
		}
	}
}
