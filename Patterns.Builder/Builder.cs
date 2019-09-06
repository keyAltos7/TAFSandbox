namespace Patterns.Builder
{
	using System;

	public class MainApp
    {
        public static void Main()
        {
            var tom = new UserBuilder().SetName("Tom").SetCompany("Microsoft").SetAge(23).Build();
            var alice = User.CreateBuilder().SetName("Alice").IsMarried.SetAge(25).Build();

            UserBuilder seregaBuilder = new UserBuilder();
            SeregaDirector seregaDirector = new SeregaDirector(seregaBuilder);
            seregaDirector.Construct();

            var serega = seregaBuilder.Build();

            Console.WriteLine(tom);
            Console.WriteLine(alice);
            Console.WriteLine(serega);
            Console.Read();
        }
    }

    public class SeregaDirector
    {
        private UserBuilder builder;
        public SeregaDirector(UserBuilder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            this.builder.SetName("Serega").SetAge(18);
        }
    }


    public class UserBuilder
    {
        private User user;
        public UserBuilder()
        {
            this.user = new User();
        }
        public UserBuilder SetName(string name)
        {
            this.user.Name = name;
            return this;
        }
        public UserBuilder SetCompany(string company)
        {
            this.user.Company = company;
            return this;
        }
        public UserBuilder SetAge(int age)
        {
            this.user.Age = age > 0 ? age : 0;
            return this;
        }
        public UserBuilder IsMarried
        {
            get
            {
                this.user.IsMarried = true;
                return this;
            }
        }
        public User Build()
        {
            return this.user;
        }
    }

    public class User
    {
        public string Name { get; set; }        // имя
        public string Company { get; set; }     // компания
        public int Age { get; set; }            // возраст
        public bool IsMarried { get; set; }      // женат/замужем

		public static UserBuilder CreateBuilder()
		{
			return new UserBuilder();
		}

		public override string ToString()
        {
            return $"{nameof(this.Name)}: {this.Name}, {nameof(this.Company)}: {this.Company}, {nameof(this.Age)}: {this.Age}, {nameof(this.IsMarried)}: {this.IsMarried}";
        }
    }
}


/// <summary>
/// Configures the targets
/// </summary>
//public class TargetBuilder
//{
//    private readonly string _friendlyName;
//    private ITarget _frame;

//    public TargetBuilder(string friendlyName)
//    {
//        _friendlyName = friendlyName ?? string.Empty;
//    }

//    public TargetBuilder InFrame(ITarget frame)
//    {
//        _frame = frame;
//        return this;
//    }

//    public ITarget LocatedBy(By by)
//    {
//        Guard.ForNull(by, nameof(by));
//        return new TargetBy(by, _friendlyName, _frame);
//    }

//    public ITargetWithParameters LocatedBy(string formatValue, Func<string, By> createBy)
//    {
//        Guard.ForNull(createBy, nameof(createBy));
//        Guard.ForNull(formatValue, nameof(formatValue));
//        return new TargetByParameterizable(_friendlyName, createBy, formatValue);
//    }

//    public ITarget LocatedByWebElement(IWebElement webElement)
//    {
//        Guard.ForNull(webElement, nameof(webElement));
//        return new TargetByWebElement(webElement, _friendlyName);
//    }
//}


//public static readonly ITarget TabsPanel =
//Target.The("Tabs").LocatedBy(By.Id("main-tab"));


//public static readonly ITarget HomeTab =
//Target.The("Home-tab").LocatedBy(By.CssSelector("li#home-tab"));


//public static ITarget Tab(string name) =
//Target.The(FormattableString.Invariant($"{name}")).LocatedBy(By.CssSelector(FormattableString.Invariant($"li[title='{name}']"))).
//RelativeTo(TabsPanel);

//public static ITarget ItemTypeLabel =
//    Target.The("Name of ItemType").InFrame(PageElements.WorkFrame).LocatedBy(By.CssSelector("span.label_span"));

