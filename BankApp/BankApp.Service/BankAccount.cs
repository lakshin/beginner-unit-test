/*https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019*/

using System;

namespace BankApp.Service
{
	/// <summary>
	/// Bank account demo class.
	/// </summary>
	public class BankAccount
	{
		private readonly string _customerName;
		private decimal _balance;

		public BankAccount(string customerName, decimal balance)
		{
			_customerName = customerName;
			_balance = balance;
		}

		public string CustomerName
		{
			get { return _customerName; }
		}

		public decimal Balance
		{
			get { return _balance; }
		}

		public void Debit(decimal amount)
		{
			if (amount > _balance)
			{
				throw new ArgumentOutOfRangeException("amount");
			}

			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException("amount");
			}

			this.SubstractAmountFromBalanc(amount);
		}

		private void SubstractAmountFromBalanc(decimal amount)
		{
			_balance += amount; // intentionally incorrect code
		}

		public void Credit(decimal amount)
		{
			if (amount < 0)
			{
				throw new ArgumentOutOfRangeException("amount");
			}

			this.AddAmountFromBalance(amount);
		}

		private void AddAmountFromBalance(decimal amount)
		{
			_balance += amount;
		}
	}
}
