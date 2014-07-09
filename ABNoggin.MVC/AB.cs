using System;
using ABNoggin.Core;

namespace ABNoggin.MVC
{
	/// <summary>
	/// A static class will be accessible from all views,
	/// but not sure if this will allow us a nice way to access html context
	/// </summary>
	public static class AB
	{
		private static readonly ABTester Tester;

		static  AB()
		{
			Tester = new ABTester();
		}

		public static T Test<T>(String name, T[] alternatives, String conversion)
		{
			return Tester.Test(name, alternatives, conversion);
		}

		public static bool Test(String name, String conversion)
		{
			return Tester.Test(name, conversion);
		}
	}
}
