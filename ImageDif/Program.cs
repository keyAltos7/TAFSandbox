namespace ImageDif
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

	class Program
	{
		static void Main(string[] args)
		{
			object str = "asdasd";
			Console.WriteLine(str.ToString());
			
			var a = new MyClass() {Label = "LabelForInstance", Owner = "Me"};

			foreach (var data in a.GetValues())
			{
				Console.WriteLine($"{data.id}-{data.value}");
			}

			Console.ReadKey();
		}
	}

	class MyClass
	{
		private Dictionary<string, string> map = new Dictionary<string, string>()
			                                         {
				                                         ["Owner"] = "ownerId",
														 ["Label"] = "LabelId"
			                                         };

		public string Label { get; set; }

		public string Owner { get; set; }

		public IEnumerable<(string id, string value)> GetValues()
		{
			foreach (var prop in this.GetType().GetProperties())
			{
				var propValue = (string )prop.GetValue(this);
				var id = this.map[prop.Name];
				yield return (id:id, value:propValue);
			}
		}
	}
}
