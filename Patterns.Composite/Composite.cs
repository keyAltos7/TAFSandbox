using System;
using System.Collections.Generic;

namespace PatternsTrainingExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker a = new Worker("Worker Tom", 5);
            Supervisor b = new Supervisor("Supervisor Mary", 6);
            Supervisor c = new Supervisor("Supervisor Jerry", 7);
            Supervisor d = new Supervisor("Supervisor Bob", 9);
            Worker e = new Worker("Worker Jimmy", 8);

            //set up the relationships
            b.AddSubordinate(a); //Tom works for Mary
            c.AddSubordinate(b); //Mary works for Jerry
            c.AddSubordinate(d); //Bob works for Jerry
            d.AddSubordinate(e); //Jimmy works for Bob

            //Jerry shows his happiness and asks everyone else to do the same
            if (c is IEmployee)
                (c as IEmployee).ShowHappiness();

            Console.Read();
        }
    }

    public interface IEmployee
    {
        void ShowHappiness();
    }

    public class Worker : IEmployee
    {
        private string name;
        private int happiness;

        public Worker(string name, int happiness)
        {
            this.name = name;
            this.happiness = happiness;
        }

        void IEmployee.ShowHappiness()
        {
            Console.WriteLine(name + " showed happiness level of " + happiness);
        }
    }

    public class Supervisor : IEmployee
    {
        private string name;
        private int happiness;

        private List<IEmployee> subordinate = new List<IEmployee>();

        public Supervisor(string name, int happiness)
        {
            this.name = name;
            this.happiness = happiness;
        }

        void IEmployee.ShowHappiness()
        {
            Console.WriteLine(name + " showed happiness level of " + happiness);
            //show all the subordinate's happiness level
            foreach (IEmployee i in subordinate)
                i.ShowHappiness();
        }

        public void AddSubordinate(IEmployee employee)
        {
            subordinate.Add(employee);
        }
    }
}

//public abstract class CompositeAction : IAction<Unit>, IEnumerable<IAction<Unit>>
//#pragma warning restore CA1710
//{
//    protected CompositeAction(params IAction<Unit>[] actions)
//    {
//    }

//    public CompositeAction And(IAction<Unit> action)
//    {
//        Guard.ForNull(action, nameof(action));
//        return new AnonymousCompositeAction(Actions.Add(action));
//    }

//    public Unit ExecuteAttemptsToAs(IInnerActorFacade actor)
//    {
//        return ExecuteActions(actor);
//    }

//    private Unit ExecuteActions(IInnerActorFacade actor)
//    {
//        Guard.ForNull(actor, nameof(actor));
//        foreach (var action in Actions)
//        {
//            actor.Execute(action);
//        }

//        return Unit.Default;
//    }

//    public void ExampleOfUsing()
//    {
//	    actor.Execute(someAction);
//        actor.Execute(Enter.TheNewValue(credentials.LoginName).
//            Into(LoginPageElements.UserNameInputField).
//            And(Enter.TheNewValue(credentials.Password).Into(LoginPageElements.PasswordInputField)).
//            And(Select.TheText(credentials.DatabaseName).
//                Into(LoginPageElements.DatabaseSelectField)).
//            And(Click.On(LoginPageElements.LogOnButton)).
//            And(Wait.UntilTargetIsPresent(HeaderElements.Logo)).
//            And(Wait.UntilTargetIsPresent(HeaderElements.UserMenuButton)));
//    }
//}

//	public class TreeStructureModel : IEnumerable<TreeNodeModel>, IEquatable<TreeStructureModel>
///// <summary>
///// Nodes of tree structure
///// </summary>
//private readonly List<TreeNodeModel> nodes;

///// <summary>
///// Initializes a new instance of the <see cref="TreeStructureModel"/> class
///// </summary>
///// <param name="nodes"></param>
//public TreeStructureModel(List<TreeNodeModel> nodes)
//{
//this.nodes = Guard.NotNull(nodes, nameof(nodes)).ToList();
//}


