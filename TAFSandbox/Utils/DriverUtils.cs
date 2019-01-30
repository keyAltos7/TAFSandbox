namespace TAFSandbox.Utils
{
	using System;

	using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Threading;

	using OpenQA.Selenium.Remote;

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
            TestContext.WriteLine($"Set '{text} into '{locator}'");
            var driver = GetDriverByKey(driverKey);
	        driver.FindElement(locator).Clear();
			driver.FindElement(locator).SendKeys(text);
        }

        public static void Submit(By locator)
        {
            Submit(locator, TestNameResolver.GetCurrentTestName());
        }

        public static void Submit(By locator, string driverKey)
        {

            TestContext.WriteLine($"Submit the '{locator}' button");
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

		/// <summary>
		/// Captures the element screen shot.
		/// </summary>
		/// <param name="element">The element.</param>
		/// <param name="uniqueName">Name of the unique.</param>
		/// <returns>returns the screenshot  image </returns>
		public static Image CaptureElementScreenShot(By locator, string uniqueName)
		{
			var driver = GetDriverByKey(TestNameResolver.GetCurrentTestName());
			var tempFileName = $@"C:\Users\kapatsevich\Desktop\Screenshots\Temp{uniqueName}.png";
			var cropedFileName = $@"C:\Users\kapatsevich\Desktop\Screenshots\{uniqueName}.png";
			var element = driver.FindElement(locator);
			Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
			screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

			Image img = Bitmap.FromFile(tempFileName);
			Rectangle rect = new Rectangle();

			if (element != null)
			{
				// Get the Width and Height of the WebElement using
				int width = element.Size.Width;
				//int height = element.Size.Height;
				int height = element.Size.Height;

				// Get the Location of WebElement in a Point.
				// This will provide X & Y co-ordinates of the WebElement
				Point p = element.Location;

				// Create a rectangle using Width, Height and element location
				rect = new Rectangle(p.X, p.Y, width, height);
			}

			// croping the image based on rect.
			Bitmap bmpImage = new Bitmap(img);
			var cropedImag = bmpImage.Clone(rect, bmpImage.PixelFormat);
			cropedImag.Save(cropedFileName, ImageFormat.Png);

			return cropedImag;
		}

	    /// <summary>
	    /// Captures the  screen shot.
	    /// </summary>
	    /// <param name="uniqueName">Name of the unique.</param>
	    /// <returns>returns the screenshot  image </returns>
	    public static void CaptureScreenShot(string uniqueName)
	    {
		    var driver = GetDriverByKey(TestNameResolver.GetCurrentTestName());
		    var tempFileName = $@"C:\Users\kapatsevich\Desktop\Screenshots\{uniqueName}_{((RemoteWebDriver)driver).Capabilities["browserName"]}.png";
		    Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
		    screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);
	    }
	}
}

