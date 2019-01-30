namespace TAFSandbox.Tests
{
	using System;
	using System.Drawing;
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

	    [Test]
	    [Parallelizable(ParallelScope.Self)]
	    public void ScreenshotForElement()
	    {
			DriverUtils.GoToUrl("http://192.168.200.198/i7251_12UI");
		    Thread.Sleep(5000);
		    var driver = DriverPool.GetDriver(TestNameResolver.GetCurrentTestName());
			driver.SwitchTo().Frame("main");
			DriverUtils.TypeInElement(By.Id("password"), "innovator");
		    DriverUtils.TypeInElement(By.Id("username"), "admin");
		    driver.FindElement(By.Id("login.login_btn_label")).Click();

			Thread.Sleep(1000);
		    driver.SwitchTo().DefaultContent();
		    Thread.Sleep(2000);



			DriverUtils.CaptureElementScreenShot(By.CssSelector(".aras-header__logo svg use"), "InnovatorLogo");

		  //  var diff = Compare(
			 //   @"C:\Users\kapatsevich\Desktop\Screenshots\GoogleLogo.png",
				//@"C:\Users\kapatsevich\Desktop\Screenshots\logo original.png");
	    }

	    [Test]
	    [Parallelizable(ParallelScope.Self)]
	    public void Screenshot()
	    {
		    DriverUtils.GoToUrl("http://192.168.200.198/i7251_12UI");
		    Thread.Sleep(2000);
		    var driver = DriverPool.GetDriver(TestNameResolver.GetCurrentTestName());
		    driver.SwitchTo().Frame("main");
		    DriverUtils.TypeInElement(By.Id("password"), "innovator");
		    DriverUtils.TypeInElement(By.Id("username"), "admin");
		    driver.FindElement(By.Id("login.login_btn_label")).Click();
		    Thread.Sleep(1000);
		    driver.SwitchTo().DefaultContent();
		    Thread.Sleep(2000);

		    DriverUtils.CaptureScreenShot("Innovator");
		    //  var diff = Compare(
		    //   @"C:\Users\kapatsevich\Desktop\Screenshots\GoogleLogo.png",
		    //@"C:\Users\kapatsevich\Desktop\Screenshots\logo original.png");
	    }
	}
}
