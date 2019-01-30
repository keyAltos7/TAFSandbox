using System;
using System.Threading.Tasks;

namespace ConsoleSandbox
{
    /// <summary>
    /// TestClass contains several cref examples.
    /// </summary>
    public class TestClass
    {
        /// <summary>
        /// This sample shows how to specify the <see cref="TestClass"/> constructor as a cref attribute.
        /// </summary>
        public TestClass()
        { }

        /// <summary>
        /// This sample shows how to specify the <see cref="TestClass(int)"/> constructor as a cref attribute.
        /// </summary>
        public TestClass(int value)
        { }

        /// <summary>
        /// The GetZero method.
        /// </summary>
        /// <remarks>
        /// <example> 
        /// This sample shows how to call the <see cref="GetZero"/> method.
        /// <code>
        /// <para/>// class TestClass 
        /// <para/>{
        /// <para/>    static int Main() 
        /// <para/>    {
        /// <para/>        return GetZero();
        /// <para/>    }
        /// <para/>}
        /// </code>
        /// </example>
        /// </remarks>


        public static int GetZero()
        {
            return 0;
        }

        /// <summary>
        /// The GetGenericValue method.
        /// </summary>
        /// <remarks> 
        /// This sample shows how to specify the <see cref="GetGenericValue"/> method as a cref attribute.
        /// </remarks>

        public static T GetGenericValue<T>(T para)
        {
            return para;
        }
    }

    /// <summary>
    /// GenericClass.
    /// </summary>
    /// <remarks> 
    /// This example shows how to specify the <see cref="GenericClass{T}"/> type as a cref attribute.
    /// </remarks>
    class GenericClass<T>
    {
        // Fields and members.
    }

    class Program
    {
        static int Main()
        {
	        int.TryParse("", out var param);
	        Console.WriteLine(param);
			return TestClass.GetZero();

	        
        }
	}
}
