using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.PageObject
{
	using OpenQA.Selenium;
	using OpenQA.Selenium.Support.UI;

	class Program
    {
        static void Main(string[] args)
        {
			var loginPage = new LogOnPage();

	        loginPage.TypeUserName("SomeName");
	        loginPage.TypePassword("SomePassword");
	        loginPage.ClickLogOnButton();

	        var mainPage = loginPage.LogOnAsUser("SomeName", "SomePassword");

	        var actuaLinkHref = loginPage.ArasLinkHref;
	        var expectedLinkHref = "Some link";

	        bool assert = string.Equals(actuaLinkHref, expectedLinkHref, StringComparison.CurrentCulture);
        }
    }

    /// <summary>
    /// The log on window.
    /// </summary>
    public class LogOnPage : BaseInnovatorPage
    {
	    public LogOnPage()
	    {
		    
	    }
        #region Private variables
        private static readonly By loginPageContainerLocator = By.ClassName("login-page");
        private static readonly By userNameInputFieldLocator = By.Id("username");
        private static readonly By passwordInputFieldLocator = By.Id("password");
        private static readonly By databaseSelectFieldLocator = By.Id("database_select");
        private static readonly By loginButtonLocator = By.Id("login.login_btn_label");
        private static readonly By cancelButtonLocator = By.Id("login.cancel_btn_label");
        private static readonly By versionLocator = By.ClassName("version");
        private static readonly By updateInfoLocator = By.ClassName("update-info");
        private static readonly By passwordFiledTooltipLocator = By.CssSelector(".password.aras-tooltip");

        private IWebElement LoginPageContainer
        {
            get
            {
                SwitchToMainFrame();
                return WebDriver.Instance.FindElement(loginPageContainerLocator);
            }
        }
        #endregion

        #region web elements 
        /// <summary>
        /// Gets or sets the database select field.
        /// </summary>
        private IWebElement DatabaseSelectField => LoginPageContainer.FindElement(databaseSelectFieldLocator);

        /// <summary>
        /// Gets or sets the aras link.
        /// </summary>
        private IWebElement UpdateInfo => LoginPageContainer.FindElement(updateInfoLocator);

        /// <summary>
        /// Gets or sets the innovator version.
        /// </summary>
        private IWebElement InnovatorVersion => LoginPageContainer.FindElement(versionLocator);

        /// <summary>
        /// Gets or sets the password field tooltip.
        /// </summary>
        private IWebElement PasswordFieldTooltip => LoginPageContainer.FindElement(passwordFiledTooltipLocator);

        /// <summary>
        /// Gets the user name input field.
        /// </summary>
        public TextBoxElement UserNameInputField => new TextBoxElement(LoginPageContainer, userNameInputFieldLocator);

        /// <summary>
        /// Gets or sets the password input field.
        /// </summary>
        public TextBoxElement PasswordInputField => new TextBoxElement(LoginPageContainer, passwordInputFieldLocator);

        /// <summary>
        /// Gets or sets the log on button.
        /// </summary>
        public ButtonElement LogOnButton => new ButtonElement(LoginPageContainer, loginButtonLocator);

        /// <summary>
        /// Gets or sets the cancel button.
        /// </summary>
        public ButtonElement CancelButton => new ButtonElement(LoginPageContainer, cancelButtonLocator);

        /// <summary>
        /// Gets aras link.
        /// </summary>
        public LinkElement ArasLink => new LinkElement(UpdateInfo, By.ClassName("aras-link"));
        #endregion

        /// <summary>
        /// Gets the title.
        /// </summary>
        public static string Title => "Aras Innovator Login";

        /// <summary>
        /// Gets the aras link href.
        /// </summary>
        public string ArasLinkHref => ArasLink.Href;

        /// <summary>
        /// Gets the innovator version
        /// </summary>
        public string InnovatorVersionText => InnovatorVersion.Text.Trim();

        /// <summary>
        /// Gets the tooltip text for password field.
        /// </summary>
        public string TooltipTextForPasswordField => PasswordFieldTooltip.GetAttribute("data-tooltip");

        /// <summary>
        /// Gets the url.
        /// </summary>
        public Uri Url
        {
            get
            {
                SwitchTo();
                return new Uri(Driver.Url);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogOnPage"/> class.
        /// </summary>
        public LogOnPage(string handle) : base(handle) { }

        /// <summary>
        /// Switch to main frame.
        /// </summary>
        private void SwitchToMainFrame()
        {
            SwitchTo();
            WaiterManager.Instance.WaitForFrameAvailableAndSwithToIt("main");
            WaiterManager.Instance.WaitDocumentCompleteState();
        }

        /// <summary>
        /// Type user name.
        /// </summary>
        public LogOnPage TypeUserName(string userName)
        {
            UserNameInputField.Clear();
            UserNameInputField.SendKeys(userName);
            return this;
        }

        /// <summary>
        /// Type password.
        /// </summary>
        public LogOnPage TypePassword(string password)
        {
            PasswordInputField.Clear();
            PasswordInputField.SendKeys(password);
            return this;
        }

        /// <summary>
        /// Select database name from dropdownlist
        /// </summary>
        public LogOnPage SelectDatabase(string databasename)
        {
            new SelectElement(DatabaseSelectField).SelectOption(databasename);
            return this;
        }

        /// <summary>
        /// Click log on button
        /// </summary>
        public LogOnPage ClickLogOnButton()
        {
            LogOnButton.Click();
            return this;
        }

        /// <summary>
        /// Click cancel and wait untill window closed.
        /// </summary>
        public void ClickCancelAndWaitUntillWindowClosed()
        {
            CancelButton.Click();
            WaiterManager.Instance.WaitUntilLastWindowClosed();
        }

        /// <summary>
        /// Wait for log on window is ready.
        /// </summary>
        public LogOnPage WaitLogOnWindowIsReady()
        {
            SwitchToMainFrame();
            WaiterManager.Instance.WaitCondition((d) => LogOnButton.IsEnabled);
            WaiterManager.Instance.WaitCondition((d) => UserNameInputField.IsDisplayed);
            WaiterManager.Instance.WaitCondition((d) => PasswordInputField.IsDisplayed);
            WaiterManager.Instance.WaitForElementIsDisplayed(InnovatorVersion);
            return this;
        }

        /// <summary>
        /// Login innovator
        /// </summary>
        public void LogOnInnovator(string userName, string password, string database)
        {
            TypeUserName(userName);
            TypePassword(password);
            SelectDatabase(database);
            ClickLogOnButton();
            SwitchTo();
        }

        /// <summary>
        /// Login to innovator as admin
        /// </summary>
        public MainWindow LogOnAsAdmin()
        {
            return LogOnAsUser(AppConfig.Instance.AdminLogOnName, AppConfig.Instance.AdminPassword);
        }

        /// <summary>
        /// Logina as  usual user.
        /// </summary>
        public MainWindow LogOnAsUser(string userName, string password)
        {
            LogOnInnovator(userName, password, AppConfig.Instance.DatabaseName);
            MainWindow mainWnd = new MainWindow(Handle);
            mainWnd.WaitMainWindowIsReady();
            return mainWnd;
        }

        /// <summary>
        /// Check that is tooltip for password field shown.
        /// </summary>
        public bool IsTooltipForPasswordFieldShown()
        {
            return (PasswordFieldTooltip.GetAttribute("data-tooltip-show") == "true");
        }
    }

    public class BaseInnovatorPage
    {
    }
}

}
