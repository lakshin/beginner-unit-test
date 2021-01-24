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
		public void CustomerName_Get_ShouldReturnInitializedName()
		{
			// Arrange
			string expectedCustomerName = "Mr. Bryan Walton";
			BankAccount account = new BankAccount(expectedCustomerName, 11.99m);

			// Act
			var actualCustomerName = account.CustomerName;

			//Assert
			Assert.AreEqual(expectedCustomerName, actualCustomerName, "Initial customer name is not properly set");
		}

		[TestMethod]
		public void Balance_Get_ShouldReturnInitializedBalance()
		{
			// Arrange
			decimal expectedBalance = 11.99m;
			BankAccount account = new BankAccount("Mr. Bryan Walton", expectedBalance);

			// Act
			var actualBalance = account.Balance;

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
			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act
			account.Debit(debitAmount);

			// Assert
			decimal actual = account.Balance;
			Assert.AreEqual(expected, actual, "Account not debited correctly");
		}

		[TestMethod]
		//[ExpectedException(typeof(System.ArgumentOutOfRangeException), "amount")]
		public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			decimal beginningBalance = 11.99m;
			decimal debitAmount = -100.00m;
			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act and assert
			//account.Debit(debitAmount);
			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount), "Exception not thrown when amount is less than zero");
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
		{
			// Arrange
			decimal beginningBalance = 11.99m;
			decimal debitAmount = 100.00m;
			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act and assert
			Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount), "Exception not thrown when amount is more than balance");
		}

		[TestMethod]
		public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange2()
		{
			// Arrange
			decimal beginningBalance = 11.99m;
			decimal debitAmount = 100.00m;
			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

			// Act and assert
			try
			{
				account.Debit(debitAmount);
			}
			catch (ArgumentOutOfRangeException e)
			{
				StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
				return;
			}

			Assert.Fail();
		}

		[DataRow(11.99, 4.55, 7.44)]
		[DataRow(12, 4, 8)]
		[DataTestMethod]
		public void Debit_WithValidAmount_UpdatesBalance2(double beginningBalance, double debitAmount, double expected)
		{
			// Arrange
			decimal beginningBalanceDecimal = Convert.ToDecimal(beginningBalance);
			decimal debitAmountDecimal = Convert.ToDecimal(debitAmount);
			decimal expectedDecimal = Convert.ToDecimal(expected);

			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalanceDecimal);

			// Act
			account.Debit(debitAmountDecimal);

			// Assert
			decimal actual = account.Balance;
			Assert.AreEqual(expectedDecimal, actual, "Account not debited correctly");
		}

		[DynamicData(nameof(TestData.GetTestData), typeof(TestData), DynamicDataSourceType.Method)]
		[DataTestMethod]
		public void Debit_WithValidAmount_UpdatesBalance3(double beginningBalance, double debitAmount, double expected)
		{
			// Arrange
			decimal beginningBalanceDecimal = Convert.ToDecimal(beginningBalance);
			decimal debitAmountDecimal = Convert.ToDecimal(debitAmount);
			decimal expectedDecimal = Convert.ToDecimal(expected);

			BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalanceDecimal);

			// Act
			account.Debit(debitAmountDecimal);

			// Assert
			decimal actual = account.Balance;
			Assert.AreEqual(expectedDecimal, actual, "Account not debited correctly");
		}
	}
}
