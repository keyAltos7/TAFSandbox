namespace TAFSandbox.Tests
{
	using System;
	using System.Drawing;
	using System.Globalization;

	using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
	using OpenQA.Selenium.Edge;
	using OpenQA.Selenium.Firefox;
	using OpenQA.Selenium.IE;

	using Utils;

    /// <summary>
    /// The base test.
    /// </summary>
    public class BaseTest
    {
        private string GetCurrentTestName() => TestContext.CurrentContext.Test.FullName;

        /// <summary>
        /// The soft assert.
        /// </summary>
        protected SoftAssert SoftAssert = new SoftAssert();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {            
        }

        [SetUp]
        public void SetUp()
        {            
            DriverPool.RegisterDriver(GetCurrentTestName(), InitializeClient());
            //AssertsPool.RegisterTest(GetCurrentTestName());
        }

        [TearDown]
        public void TearDown()
        {  
            DriverPool.DisposeDriver(GetCurrentTestName());
            SoftAssert.PrintResults();
            //AssertsPool.PrintAsserts(GetCurrentTestName());
        }

        [OneTimeTearDown]
        public void OneTimeTearUp()
        {
            DriverPool.DisposeAllDrivers();
        }

        protected virtual IWebDriver InitializeClient()
        {
	  //      var options = new InternetExplorerOptions
		 //                     {
			//                      PageLoadStrategy = PageLoadStrategy.None,
			//                      UnhandledPromptBehavior = UnhandledPromptBehavior.Accept,
			//                      //options.EnableNativeEvents = true;
			//                      ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom,
			//                      //options.IgnoreZoomLevel = true;
			//                      EnablePersistentHover = false,
			//                      RequireWindowFocus = true
		 //                     };
	  //      var driver = new InternetExplorerDriver(options);
	        var driver = new ChromeDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
			driver.Manage().Window.Size = new Size(1280, 800);


			return driver;

        }

		//private static EdgeOptions InitOptions()
		//{
		// var options = new EdgeOptions
		//                {
		//                 PageLoadStrategy = PageLoadStrategy.Normal,
		//                 UnhandledPromptBehavior = UnhandledPromptBehavior.Accept,
		//                };
		// return options;
		//}

	    private static FirefoxProfile InitOptions()
	    {
		    var profile = new FirefoxProfile();

		    profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/x-excel, application/x-msexcel, application/excel, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword");
		    profile.SetPreference("browser.helperApps.neverAsk.openFile", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet, application/x-excel, application/x-msexcel, application/excel, application/vnd.ms-excel, application/vnd.openxmlformats-officedocument.wordprocessingml.document, application/msword");
		    profile.SetPreference("intl.accept_languages", CultureInfo.CurrentCulture.Name);
		    profile.SetPreference("dom.disable_beforeunload", true); //work-around of https://github.com/mozilla/geckodriver/issues/1151 issue

		    return profile;
	    }

	}
}
