namespace Patterns.FactoryMethod
{
	namespace Factory
    {
	    using System;

	    abstract class Product
        {
            public abstract string GetType();
        }

        class ConcreteProductA : Product
        {
            public override string GetType() { return "ConcreteProductA"; }
        }

        class ConcreteProductB : Product
        {
            public override string GetType() { return "ConcreteProductB"; }
        }

        abstract class Creator
        {
            public abstract Product FactoryMethod();
        }

        class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod() { return new ConcreteProductA(); }
        }

        class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod() { return new ConcreteProductB(); }
        }

        public class MainApp
        {
            public static void Main()
            {
                // an array of creators
                Creator[] creators = { new ConcreteCreatorA(), new ConcreteCreatorB() };
                // iterate over creators and create products
                foreach (Creator creator in creators)
                {
                    Product product = creator.FactoryMethod();
                    Console.WriteLine("Created {0}", product.GetType());
                }
                // Wait for user
                Console.Read();
            }
        }
    }
}


///// <summary>
///// Interface for Factory Method which create BaseWebElement
///// </summary>
//public interface IWebElementFactory<T>
//{
//	/// <summary>
//	/// Return object of class BaseWebElement
//	/// </summary>
//	/// <param name="cell"></param>
//	/// <returns></returns>
//	T Create(ICell cell);
//}

//public class DatePickerFactory : IWebElementFactory<DatePickerElement>
//{
//	/// <summary>
//	/// Create CalednarElement from cell
//	/// </summary>
//	/// <param name="cell"></param>
//	public static DatePickerElement Create(ICell cell)
//	{
//		Validator.CheckParamatersForNull(cell);
//		DatePickerElement picker;
//		if (ElementHelper.Instance.IsElementPresent(By.CssSelector(".dijitInputInner"), cell.Element))
//		{
//			picker = new DatePickerElement(
//				cell.Element,
//				By.CssSelector(".dijitInputInner"),
//				By.CssSelector(".dijitArrowButtonContainer"));
//		}
//		else
//		{
//			cell.SelectCurrentCell();
//			picker = new DatePickerElement(cell.Element);
//		}

//		return picker;
//	}
//}


// // It's PageObject Method
///// <summary>
///// Open dialog
///// </summary>
//public void DatePickerOpenDialog(int rowNum, int colNum, FieldActionType fieldAction)
//{
//GridComponent.GridData.Rows[rowNum].Cells[colNum].SelectCurrentCell();
//DatePickerFactory.Create(GridComponent.GridData.Rows[rowNum].Cells[colNum]).OpenDialog(fieldAction);
//}

