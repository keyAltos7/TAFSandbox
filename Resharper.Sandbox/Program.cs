using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resharper.Sandbox
{
	using System.IO;

	class Program
    {
        static void Main(string[] args)
        {
        }

	    private static void ExtractVariable(string fileName)
	    {
            // Extract Variable. Selection + Ctrl + Alt + V
            if (File.Exists(fileName))
		    {
			    // some code
            }

            // some code

            if (File.Exists(fileName))
		    {
			    // some code
            }
        }

	    private static void ConvertToLinq(IEnumerable<string> logFiles)
	    {
            // Convert to LINQ (Alt+Enter)

		    var notTestFiles = new List<string>();
		    foreach (var logFile in logFiles)
		    {
			    if (!logFiles.Contains("Test"))
			    {
				    notTestFiles.Add(logFile);
			    }
		    }

      //      var notTestFiles = new List<char[]>();
		    //foreach (var logFile in logFiles)
		    //{
			   // if (!logFiles.Contains("Test"))
			   // {
				  //  notTestFiles.Add(logFile.ToCharArray());
			   // }
		    //}

		    int c = 1;
		    int[] numbers = new []{1,2,3};
		    for (int i = 0; i < numbers.Length; ++i)
			    c *= numbers[i];
        }

	    private static string GetFilePrefix(string message)
	    {
		    return message.Contains("Test") ? "Test_" : "Prod_";
	    }

	    private static string BookmarkedMethod(string message)
	    {
		    var postfix = "SomePostfix";
		    var prefix = message.Contains("Test") ? "Test_" : "Prod_";

            return $"{prefix}{message}{postfix}";
	    }


	    private static (double, double) ExtractSubmethods(double a, double b, double c)
	    {
		    var disc = b * b - 4 * a * c;

		    double x1 = 0, x2 = 0;
            // some calculations
            return (x1, x2);
	    }

		/// <summary>
        /// Some description
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="param">paramName</param>
        /// <returns></returns>
	    public string SomeGenericMethod<T>(T param)
	    {
		    return param.ToString();
	    }

	    
	    
    }

	public abstract class Handler
	{
        public Handler Successor { get; protected set; }

        public void SetSuccessor(Handler successor)
		{
			this.Successor = successor;
		}

		public abstract void HandleRequest(int request);

		protected virtual void VirtualMethod()
		{

		}
	}

    /// <summary>
    /// The 'ConcreteHandler1' class
    /// </summary>
	public class ConcreteHandler1 : Handler
	{
		public override void HandleRequest(int request)
		{
			if (request >= 0 && request < 15)
			{
				Console.WriteLine("{0} handled request {1}",
					this.GetType().Name, request);
			}
			else if (Successor != null)
			{
				Successor.HandleRequest(request);
			}
		}
	}

    /// <summary>
    /// The 'CodeGenerationClass' class
    /// </summary>
	public class CodeGenerationClass : Handler
	{
		private string someString;

		public int SomeName { get; set; }


		public int SomeInt { get; set; }


		public override void HandleRequest(int request)
		{
			if (request >= 0 && request < 15)
			{
				Console.WriteLine("{0} handled request {1}",
					this.GetType().Name, request);
			}
			else if (Successor != null)
			{
				Successor.HandleRequest(request);
			}
		}
	}
}
