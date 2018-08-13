using System;

namespace PatternsTrainingExamples
{
    class ProgramMain
    {
        public static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());

            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
	        //pizza3 = new CheesePizza(pizza3);
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", с томатами", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", с сыром", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }
}

//public abstract class BaseWebElement : IBaseElement
//{

//    #region Public Properties

//    /// <summary>
//    /// Gets a value indicating whether or not this element is displayed.
//    /// </summary>
//    public virtual bool IsDisplayed
//    {
//        get
//        {
//            return _webElement.Displayed;
//        }
//    }

//    /// <summary>
//    /// Gets a value indicating whether or not this element is enabled.
//    /// </summary>
//    public virtual bool IsEnabled
//    {
//        get
//        {
//            return _webElement.Enabled;
//        }
//    }

//    /// <summary>
//    /// Gets the innerText of this element
//    /// </summary>
//    public virtual string Text
//    {
//        get
//        {
//            return _webElement.Text;
//        }
//    }

//    /// <summary>
//    /// Get element's size
//    /// </summary>
//    public virtual Size Size
//    {
//        get
//        {
//            return _webElement.Size;
//        }
//    }

//    /// <summary>
//    /// Get width of element
//    /// </summary>
//    public virtual int Width
//    {
//        get
//        {
//            return Size.Width;
//        }
//    }

//    /// <summary>
//    /// Get height of element
//    /// </summary>
//    public virtual int Height
//    {
//        get
//        {
//            return Size.Height;
//        }
//    }

//    /// <summary>
//    /// Get location for element
//    /// </summary>
//    public virtual Point Location
//    {
//        get
//        {
//            return _webElement.Location;
//        }
//    }

//    #endregion


//    /// <summary>
//    /// The baseWebElement based on IWebElement.
//    /// </summary>
//    protected IWebElement WebElement
//    {
//        get
//        {
//            return _webElement;
//        }
//    }

//    private IWebElement _webElement;

//    /// <summary>
//    /// Initializes a new instance of the <see cref="BaseWebElement"/> class.
//    /// </summary>
//    /// <param name="webElementContainer">WebElement container.</param>
//    /// <param name="by">Mechanism to find element in WebElement container</param>
//    protected BaseWebElement(IWebElement webElementContainer, By by)
//    {
//        Validator.CheckParamatersForNull(webElementContainer);
//        Validator.CheckParamatersForNull(by);
//        _webElement = webElementContainer.FindElement(by);
//    }

//    /// <summary>
//    /// Initializes a new instance of the <see cref="BaseWebElement"/> class.
//    /// </summary>
//    /// <param name="webElement">WebElement </param>
//    protected BaseWebElement(IWebElement webElement)
//    {
//        Validator.CheckParamatersForNull(webElement);
//        _webElement = webElement;
//    }


//    #region Public Methods

//    /// <summary>
//    /// Clicks this element.
//    /// </summary>
//    public virtual void Click()
//    {
//        WaiterManager.Instance.WaitForElementToBeClickable(_webElement);
//        _webElement.Click();
//    }

//    /// <summary>
//    /// Clicks this element by javascript.
//    /// </summary>
//    public virtual void JsClick()
//    {
//        ((IJavaScriptExecutor)WebDriver.Instance).ExecuteScript("var elem=arguments[0]; setTimeout(function() {elem.click();}, 100);", _webElement);
//    }

//    /// <summary>
//    /// Gets the value of the specified attribute for this element.
//    /// </summary>
//    public virtual string GetAttribute(string attributeName)
//    {
//        return WebElement.GetAttribute(attributeName);
//    }

//    /// <summary>
//    /// Gets the value of the specified CSS property for this element.
//    /// </summary>
//    public virtual string GetCssValue(string propertyName)
//    {
//        return WebElement.GetCssValue(propertyName);
//    }
//    #endregion
//}

// //----------------------------------CheckBoxElement------------------------------------------------------------------------------
//public class CheckBoxElement : BaseWebElement, ICheckBox
//{
//	/// <summary>
//	/// Initializes a new instance of the <see cref="CheckBoxElement"/> class.
//	/// </summary>
//	/// <param name="webElementContainer">WebElement container.</param>
//	public CheckBoxElement(IWebElement webElementContainer) : base(webElementContainer, By.TagName("input"))
//	{

//	}

//	/// <summary>
//	/// Initializes a new instance of the <see cref="CheckBoxElement"/> class.
//	/// </summary>
//	/// <param name="webElementContainer">WebElement container.</param>
//	/// <param name="by">Criteria by which we can find element in WebElement container.</param>
//	public CheckBoxElement(IWebElement webElementContainer, By by) : base(webElementContainer, by)
//	{

//	}

//	/// <summary>
//	/// Gets state of checkBox
//	/// </summary>
//	public bool IsChecked
//	{
//		get
//		{
//			return WebElement.Selected;
//		}
//	}

//	/// <summary>
//	/// Select or unselect element depend on value of state
//	/// </summary>
//	/// <param name="state">
//	/// Set state of checkBox (true-selected, false-unselected)
//	/// </param>
//	public void SetState(bool state)
//	{
//		if (IsChecked != state)
//		{
//			ElementHelper.Instance.Click(WebElement);
//		}
//	}
//}

// //----------------------------------CheckBoxFactory------------------------------------------------------------------------------

//public class CheckBoxFactory : IWebElementFactory<CheckBoxElement>
//{
//	/// <summary>
//	/// Create CheckBoxElement from cell
//	/// </summary>
//	public static CheckBoxElement Create(ICell cell)
//	{
//		Validator.CheckParamatersForNull(cell);
//		return new CheckBoxElement(cell.Element);
//	}

//	CheckBoxElement IWebElementFactory<CheckBoxElement>.Create(ICell cell)
//	{
//		return Create(cell);
//	}
//}


// //----------------------------------Using------------------------------------------------------------------------------


//public void DefineMultiSelectBoxFieldByNameAndSelectValues(string fieldName, List<string> values)
//{
//Validator.CheckParamatersForNull(values);
//IWebElement field = DefineFieldByName(fieldName);
//IWebElement overSelect = field.FindElement(By.CssSelector(".multiselect .overSelect"));
//IWebElement checkboxes = field.FindElement(By.CssSelector(".multiselect #checkboxes"));
//checkboxes.FindElements(By.TagName("label"));
//overSelect.Click();
//foreach (string value in values)
//{
//	var checkboxContainer = checkboxes.FindElement(By.XPath("//label[text()='" + value + "']"));
//	ElementHelper.MoveToElement(checkboxContainer);
//	CheckBoxFactory.Create(checkboxContainer).SetState(true);
//}
//overSelect.Click();
//}