namespace GiftRAP
{
	/// <summary>
	/// Ensures that we don't return fractions of pennies.
	/// </summary>
	public class Money
	{
		private decimal _amount;

		public static implicit operator decimal (Money money)
		{
			return money._amount;
		}

		public static implicit operator Money (decimal amount)
		{
			return new Money {_amount = decimal.Round(amount, 2)};
		}

		#region object overrides

		public override string ToString()
		{
			return _amount.ToString();
		}

		public bool Equals(Money other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other._amount == _amount;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof (Money)) return false;
			return Equals((Money) obj);
		}

		public override int GetHashCode()
		{
			return _amount.GetHashCode();
		}

		#endregion
	}
}