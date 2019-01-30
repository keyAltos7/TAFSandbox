namespace Patterns.ChainOfResponsibility
{
    using System;

    namespace DoFactory.GangOfFour.Chain.Structural
    {
        /// <summary>

        /// MainApp startup class for Structural

        /// Chain of Responsibility Design Pattern.

        /// </summary>

        class MainApp

        {
            /// <summary>

            /// Entry point into console application.

            /// </summary>

            static void Main()
            {
                // Setup Chain of Responsibility

                Handler h1 = new ConcreteHandler1();
                Handler h2 = new ConcreteHandler2();
                Handler h3 = new ConcreteHandler3();
                h1.SetSuccessor(h2);
                h2.SetSuccessor(h3);

                // Generate and process request

                int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20, 31 };

                foreach (int request in requests)
                {
                    h1.HandleRequest(request);
                }

                // Wait for user

                Console.ReadKey();
            }
        }

        /// <summary>

        /// The 'Handler' abstract class

        /// </summary>

        abstract class Handler
        {
            protected Handler successor;

            public void SetSuccessor(Handler successor)
            {
                this.successor = successor;
            }

            public abstract void HandleRequest(int request);
        }

        /// <summary>

        /// The 'ConcreteHandler1' class

        /// </summary>

        class ConcreteHandler1 : Handler

        {
            public override void HandleRequest(int request)
            {
                if (request >= 0 && request < 15)
                {
                    Console.WriteLine("{0} handled request {1}",
                      this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

        /// <summary>

        /// The 'ConcreteHandler2' class

        /// </summary>

        class ConcreteHandler2 : Handler

        {
            public override void HandleRequest(int request)
            {
                if (request >= 10 && request < 20)
                {
                    Console.WriteLine("{0} handled request {1}",
                      this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }

        /// <summary>

        /// The 'ConcreteHandler3' class

        /// </summary>

        class ConcreteHandler3 : Handler

        {
            public override void HandleRequest(int request)
            {
                if (request >= 20 && request < 30)
                {
                    Console.WriteLine("{0} handled request {1}",
                      this.GetType().Name, request);
                }
                else if (successor != null)
                {
                    successor.HandleRequest(request);
                }
            }
        }
    }
}


//public class ArasFilterListHanlder : BaseElementHandler
//{
//    /// <inheritdoc />
//    public override BaseWebElement Handle(IWebElement element)
//    {
//        if (ElementHelper.Instance.IsElementPresent(By.CssSelector(".aras-filter-list .aras-filter-list__input"), element))
//        {
//            return new ArasFilterListElement(element);
//        }
//        else if (Successor != null)
//        {
//            return Successor.Handle(element);
//        }
//        return null;
//    }
//}

//public class CellService
//{
//    public void SetCombobox(int rowNum, int colNum, string value)
//    {
//        GridComponent.GridData.Rows[rowNum].Cells[colNum].SelectCurrentCell();
//        DojoFilterListHandler dojoHandler = new DojoFilterListHandler();
//        ArasFilterListHanlder arasHandler = new ArasFilterListHanlder();
//        dojoHandler.Successor = arasHandler;
//        BaseFilterList filterList =
//            dojoHandler.Handle(GridComponent.GridData.Rows[rowNum].Cells[colNum].Element) as BaseFilterList;
//        filterList.SelectOption(value);
//    }
//}


