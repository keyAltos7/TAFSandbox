namespace TAFSandbox.Tests
{
    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

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
            return new ChromeDriver();
        }
    }
}
