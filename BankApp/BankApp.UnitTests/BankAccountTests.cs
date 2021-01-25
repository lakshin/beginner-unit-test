using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankApp.Service;
using System;

namespace BankApp.UnitTests
{
	[TestClass]
	public class BankAccountTests
	{
		//[ClassInitialize()]
		//public static void InitTestSuite(TestContext testContext)
		//{
		//	//Some code to execute before all tests
		//}

		//[TestInitialize()]
		//public void Startup()
		//{
		//	//Some code to execute before each test
		//}

		//[TestCleanup()]
		//public void Cleanup()
		//{
		//	//Some code to execute after each test
		//}

		[TestMethod]
		public void CustomerName_OnGet_ShouldReturnInitializedName()
		{
			// Arrange
			string expectedCustomerName = "Mr. Bryan Walton";
			BankAccount sut = new BankAccount(expectedCustomerName, 11.99m);

			// Act
			var actualCustomerName = sut.CustomerName;

			//Assert
			Assert.AreEqual(expectedCustomerName, actualCustomerName, "Initial customer name is not properly set");
		}

		[TestMethod]
		public void Balance_OnGet_ShouldReturnInitializedBalance()
		{
			// Arrange
			decimal expectedBalance = 11.99m;
			BankAccount sut = new BankAccount("Mr. Bryan Walton", expectedBalance);

			// Act
			var actualBalance = sut.Balance;

			//Assert
			Assert.AreEqual(expectedBalance, actualBalance, "Initial balance is not properly set");
		}

		[TestMethod]
		public void Debit_WithValidAmount_UpdatesBalance()
		{
			// Arrange
			decimal beginningBalance = 11.99m;
			decimal debitAmount = 4.55m;
			decimal expected = 7.44m;
			BankAccount sut = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act
			sut.Debit(debitAmount);

			// Assert
			decimal actual = sut.Balance;
			Assert.AreEqual(expected, actual, "Account not debited correctly");
		}

		[TestMethod]
		//[ExpectedException(typeof(System.ArgumentOutOfRangeException), "amount")]
		public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			decimal beginningBalance = 11.99m;
			decimal debitAmount = -100.00m;
			BankAccount sut = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act and assert
			//account.Debit(debitAmount);
			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => sut.Debit(debitAmount), "Exception not thrown when amount is less than zero");
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			decimal beginningBalance = 11.99m;
			decimal debitAmount = 100.00m;
			BankAccount sut = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act and assert
			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => sut.Debit(debitAmount), "Exception not thrown when amount is more than balance");
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange2()
		{
			// Arrange
			decimal beginningBalance = 11.99m;
			decimal debitAmount = 100.00m;
			BankAccount sut = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act and assert
			try
			{
				sut.Debit(debitAmount);
			}
			catch (ArgumentOutOfRangeException e)
			{
				StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
				return;
			}

			Assert.Fail();
		}
	}
}
