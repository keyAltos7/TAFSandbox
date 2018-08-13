namespace TAFSandbox.Tests
{
    using System.Threading;

    using NUnit.Framework;

    using OpenQA.Selenium;

    using Utils;

    /// <summary>
    /// Just an example of test class with minimum interaction with an Web Application
    /// Thread sleeps were added for illustrate an slow operation and show the effectivity of parallelization
    /// </summary>
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestClass1 : BaseTest
    {
        /// <summary>
        /// Contains examples of SoftAssert using.
        /// </summary>
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test1()
        {
	        SoftAssert.IsTrue(false);
            DriverUtils.GoToUrl("https://www.google.by");
            Thread.Sleep(3000);
            SoftAssert.IsTrue(false, "assert 1");
            DriverUtils.TypeInElement(By.Name("q"), "google");            
            Thread.Sleep(5000);
            SoftAssert.IsTrue(false);
            DriverUtils.Submit(By.Name("q"));
            SoftAssert.IsTrue(true, "assert 3");
            Thread.Sleep(2000);
            SoftAssert.IsTrue(false, "assert 4");
            TestContext.AddTestAttachment(@"C:\Users\kapatsevich\Downloads\ValeryKapatsevich.jpeg", "Added screenshot for Class1.Test1");
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test2()
        {
            DriverUtils.GoToUrl("http://the-internet.herokuapp.com/key_presses");
            var keys = new[] { Keys.LeftControl + "a", Keys.F12, Keys.F12 };

            DriverUtils.PressKeys(/*keys*/);
            TestContext.AddTestAttachment(@"C:\Users\kapatsevich\Downloads\ValeryKapatsevich.jpeg", "Added screenshot for Class1.Test2");
            //Thread.Sleep(2000);
            //DriverUtils.TypeInElement(By.Id("text"), "google");
            //Thread.Sleep(4000);
            //DriverUtils.Submit(By.Id("text"));
            //Thread.Sleep(3000);
        }
    }
}
