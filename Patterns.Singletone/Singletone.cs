namespace Patterns.Singletone
{
	using System;

	class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch("Windows 8.1");
            Console.WriteLine(comp.OS.Name);

            comp.OS = OS.getInstance("Windows 10");
            Console.WriteLine(comp.OS.Name);

            Computer comp2 = new Computer();
            comp2.OS = OS.getInstance("Windows 10");

            Console.WriteLine($"Comp 1 OS and comp 2  OS refference equals: {ReferenceEquals(comp.OS, comp2.OS)}");

            Console.ReadLine();
        }
    }

    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            this.OS = OS.getInstance(osName);
        }
    }
    class OS
    {
        private static OS instance;
        //private static readonly OS instance = new OS();

        private OS() { }

        public string Name { get; private set; }

        private static object syncRoot = new Object();

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (instance == null)
            {
                lock (syncRoot)
                {
                    if (instance == null)
                        instance = new OS(name);
                }
            }
            return instance;
        }
    }
}

// // I11 STAF
//namespace Framework.Helper
//{
//	/// <summary>
//	/// Wrapper for IWebDriver
//	/// </summary>
//	public static class WebDriver
//	{

//		private static IWebDriverFacade _instance;
//		/// <summary>
//		/// Implement the singleton for class WebDriver
//		/// </summary>
//		public static IWebDriverFacade Instance
//		{
//			get
//			{
//				if (_instance == null || _instance.IsDead)
//				{
//					_instance = WebDriverFacadeFactory.Create();
//				}
//				return _instance;
//			}
//		}
//	}
//}
