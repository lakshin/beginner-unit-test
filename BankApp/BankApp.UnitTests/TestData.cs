using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.UnitTests
{
	public class TestData
	{
		public static IReadOnlyCollection<object[]> GetTestData()
		{
			return new List<object[]>
			{
				new object[]{ 11.99, 4.55, 7.44 },
				new object[]{ 12, 4, 8 }
			};
		}
	}
}
