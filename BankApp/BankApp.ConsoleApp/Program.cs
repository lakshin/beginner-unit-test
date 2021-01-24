using System;
using BankApp.Service;

namespace BankApp.ConsoleApp
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var name = "Mr.Bryan Walton";
			BankAccount ba = new BankAccount(name, 11.99m);
			Console.WriteLine("Hello {0}. Your opening balance is ${1}", name, ba.Balance);

			ba.Credit(5.77m);
			Console.WriteLine("Credited: ${0}", 5.77);

			ba.Debit(11.22m);
			Console.WriteLine("Debited: ${0}", 11.22);

			Console.WriteLine("Current balance is ${0}", ba.Balance);
		}
	}
}
