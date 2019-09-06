namespace PatternsTrainingExamples
{
	using System;

	namespace DoFactory.GangOfFour.Facade.Structural
    {
        class MainApp

        {
            /// <summary>

            /// Entry point into console application.

            /// </summary>

            public static void Main()
            {
                Facade facade = new Facade();

                facade.MethodA();
                facade.MethodB();

                // Wait for user

                Console.ReadKey();
            }
        }

        /// <summary>

        /// The 'Subsystem ClassA' class

        /// </summary>

        class SubSystemOne

        {
            public void MethodOne()
            {
                Console.WriteLine(" SubSystemOne Method");
            }
        }

        /// <summary>

        /// The 'Subsystem ClassB' class

        /// </summary>

        class SubSystemTwo

        {
            public void MethodTwo()
            {
                Console.WriteLine(" SubSystemTwo Method");
            }
        }

        /// <summary>

        /// The 'Subsystem ClassC' class

        /// </summary>

        class SubSystemThree

        {
            public void MethodThree()
            {
                Console.WriteLine(" SubSystemThree Method");
            }
        }

        /// <summary>

        /// The 'Subsystem ClassD' class

        /// </summary>

        class SubSystemFour

        {
            public void MethodFour()
            {
                Console.WriteLine(" SubSystemFour Method");
            }
        }

        /// <summary>

        /// The 'Facade' class

        /// </summary>

        class Facade

        {
            private SubSystemOne _one;
            private SubSystemTwo _two;
            private SubSystemThree _three;
            private SubSystemFour _four;

            public Facade()
            {
                this._one = new SubSystemOne();
                this._two = new SubSystemTwo();
                this._three = new SubSystemThree();
                this._four = new SubSystemFour();
            }

            public void MethodA()
            {
                Console.WriteLine("\nMethodA() ---- ");
                this._one.MethodOne();
                this._two.MethodTwo();
                this._four.MethodFour();
            }

            public void MethodB()
            {
                Console.WriteLine("\nMethodB() ---- ");
                this._two.MethodTwo();
                this._three.MethodThree();
            }
        }
    }
}

