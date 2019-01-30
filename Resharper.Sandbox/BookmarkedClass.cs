using System.Threading;
using System;

namespace Resharper.Sandbox
{
	
	using System.Linq;

	public class BookmarkedClass
	{
		public int IntProp{
			get {return 5;}
			set
			{
				IntProp = value;}
		}

		private static void DoSmthSecretly(){
			Console.WriteLine("Private static");}

		string stringField = String.Empty;

		public string InstancePublicMethod(string param)
		{
			return param + 1;
			Thread.Sleep(1000);
		}

		public BookmarkedClass()
		{
			IntProp = 18;
			int[] array = new []{1,2,4};

			array.ToList().ForEach(n => Console.WriteLine(n));
		}

		public event Func<int> SomeEvent;
	}
}