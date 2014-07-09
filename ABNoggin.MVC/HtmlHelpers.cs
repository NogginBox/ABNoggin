using System;
using System.Web.Mvc;
using ABNoggin.Core;

namespace ABNoggin.MVC
{
	/// <summary>
	/// Html helpers are standard,
	/// but not sure if it's good to use them when they don't produce HTML
	/// </summary>
	public static class HtmlHelpers
	{
		private static ABTester Tester { get; set; }

		static HtmlHelpers()
		{
			Tester = new ABTester();
		}

		public static T ABTest<T>(this HtmlHelper helper, String name, T[] alternatives, String conversion)
		{
			return Tester.Test(name, alternatives, conversion);
		}

		public static bool ABTest(this HtmlHelper helper, String name, String conversion)
		{
			return Tester.Test(name, conversion);
		}
	}
}
