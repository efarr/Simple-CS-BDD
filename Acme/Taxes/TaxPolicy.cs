namespace Acme.Taxes
{
	public abstract class TaxPolicy : ITaxPolicy
	{
		private readonly ITaxPolicy _previousPolicy;

		internal TaxPolicy(ITaxPolicy previousPolicy)
		{
			_previousPolicy = previousPolicy;
		}

		public void ApplyTaxes(Order order)
		{
			if (_previousPolicy != null)
				_previousPolicy.ApplyTaxes(order);

			ApplyTaxesImpl(order);
		}


		protected abstract void ApplyTaxesImpl(Order order);
	}
}