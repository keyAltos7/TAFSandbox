namespace TAFSandbox.Utils
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System.Collections.ObjectModel;
    using System.Threading;

    /// <summary>    
    /// DriverUtils is Selenium WebDriver Facade
    /// This class contains general methods to enhance existing WebDriver functionality
    /// </summary>
    public static class DriverUtils
    {
        /// <summary>
        /// The go to url.
        /// </summary>
        /// <param name="url">
        /// The url.
        /// </param>
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

        public static ReadOnlyCollection<LogEntry> GetBrowserLogs()
        {
            var driver = GetDriverByKey(TestNameResolver.GetCurrentTestName());
            return driver.Manage().Logs.GetLog(LogType.Browser);
        }

        public static void PressKeys(params string[] keys)
        {
            var driver = GetDriverByKey(TestNameResolver.GetCurrentTestName());
            var actions = new Actions(driver);

            actions.KeyDown(Keys.LeftControl).SendKeys("a").Build().Perform();
            Thread.Sleep(1000);
            actions.KeyUp(Keys.LeftControl).Build().Perform();

            actions.KeyDown(Keys.LeftControl).SendKeys("s").Build().Perform();
            Thread.Sleep(1000);
            actions.KeyUp(Keys.LeftControl).Build().Perform();

            actions.SendKeys(Keys.Delete).Build().Perform();


            //foreach (string key in keys)
            //{
            //    actions.SendKeys(key).Build().Perform();
            //    Thread.Sleep(2000);
            //    actions.Release().Build().Perform();
            //}
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
