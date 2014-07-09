using System;
using System.Web.Mvc;
using ABNoggin.Core;

namespace ABNoggin.MVC
{
	/// <summary>
	/// Extension of view base class lets us use this.ExtenstionMethod in view,
	/// but not seen this done before, so not sure it's best practice
	/// </summary>
	public static class ABViewBaseClassHelpers
	{
		private static ABTester Tester { get; set; }

		static ABViewBaseClassHelpers()
		{
			Tester = new ABTester();
		}

		public static T ABTest<T>(this WebViewPage viewPage, String name, T[] alternatives, String conversion)
		{
			return Tester.Test(name, alternatives, conversion);
		}

		public static bool ABTest(this WebViewPage viewPage, String name, String conversion)
		{
			return Tester.Test(name, conversion);
		}
	}
}
