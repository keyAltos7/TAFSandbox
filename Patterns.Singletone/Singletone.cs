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


//public sealed class ExtentReportSingletonFactory
//{
//	private static ExtentReports instance;

//	public static ExtentReports GetInstance(
//		IReportSettings reportSettings,
//		BrowserInfo browserInfo,
//		string extentReportsConfigPath)
//	{
//		lock (Lock)
//		{
//			if (instance == null)
//			{
//				var directory = Path.GetDirectoryName(typeof(ExtentReportsObserver).Assembly.Location);

//				if (string.IsNullOrEmpty(extentReportsConfigPath))
//				{
//					extentReportsConfigPath =
//						FormattableString.Invariant($"{directory}\\{ExtentReportsDefaultConfig}");
//				}

//				instance = CreateExtentReport(reportSettings, browserInfo, extentReportsConfigPath);
//			}

//			return instance;
//		}
//	}
//}