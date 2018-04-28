namespace TAFSandbox.Utils
{
    using NUnit.Framework;

    /// <summary>
    /// Incapsulate the refference between Nunit implementation for getting test name
    /// </summary>
    internal class TestNameResolver
    {
        /// <summary>
        /// Provide full test name for current running test
        /// </summary>
        /// <returns>Test name</returns>
        public static string GetCurrentTestName() => TestContext.CurrentContext.Test.FullName;
    }
}
