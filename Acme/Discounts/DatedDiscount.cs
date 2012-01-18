using System;

namespace Acme.Discounts
{
	public abstract class DatedDiscount
	{
		internal DateTime StartDate { get; set; }
		internal DateTime EndDate { get; set; }
		public decimal DiscountPercent { get; set; }

		internal DatedDiscount()
		{
			StartDate = DateTime.MinValue;
			EndDate = DateTime.MaxValue;
		}

		internal bool IsValidOn(DateTime date)
		{
			return date.Date >= StartDate.Date && date.Date <= EndDate.Date;
		}

		internal abstract bool DoesApplyTo(Product product);
	}
}