namespace TAFSandbox.Utils
{
    using OpenQA.Selenium;

    /// <summary>    
    /// DriverUtils is Selenium WebDriver Facade
    /// This class contains general methods to enhance existing WebDriver functionality
    /// </summary>
    public static class DriverUtils
    {   
        public static void GoToUrl(string url)
        {
            GoToUrl(url, TestNameResolver.GetCurrentTestName());
        }

        public static void GoToUrl(string url, string driverKey)
        {
            var driver = GetDriverByKey(driverKey);
            driver.Navigate().GoToUrl(url);
        }

        public static void TypeInElement(By locator, string text)
        {
            TypeInElement(locator, text, TestNameResolver.GetCurrentTestName());
        }

        public static void TypeInElement(By locator, string text, string driverKey)
        {
            var driver = GetDriverByKey(driverKey);
            driver.FindElement(locator).SendKeys(text);
        }

        public static void Submit(By locator)
        {
            Submit(locator, TestNameResolver.GetCurrentTestName());
        }

        public static void Submit(By locator, string driverKey)
        {
            var driver = GetDriverByKey(driverKey);
            driver.FindElement(locator).Submit();
        }

        /// <summary>
        /// Internal method for getting the appropriate instance of the WebDriver for user needs
        /// </summary>
        /// <param name="driverKey">Key for access to WebDriver. Full test name is used as default </param>
        /// <returns>An instance of Driver</returns>
        private static IWebDriver GetDriverByKey(string driverKey)
        {    
            return DriverPool.GetDriver(driverKey);
        }        
    }
}
