using System;

namespace PatternsTrainingExamples
{
    //public class MainApp
    //{
    //    public static void Main()
    //    {
    //        var tom = new UserBuilder().SetName("Tom").SetCompany("Microsoft").SetAge(23).Build();
    //        var alice = User.CreateBuilder().SetName("Alice").IsMarried.SetAge(25).Build();

    //        UserBuilder seregaBuilder = new UserBuilder();
    //        SeregaDirector seregaDirector = new SeregaDirector(seregaBuilder);
    //        seregaDirector.Construct();

    //        var serega = seregaBuilder.Build();

    //        Console.WriteLine(tom);
    //        Console.WriteLine(alice);
    //        Console.WriteLine(serega);
    //        Console.Read();
    //    }
    //}

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
            user = new User();
        }
        public UserBuilder SetName(string name)
        {
            user.Name = name;
            return this;
        }
        public UserBuilder SetCompany(string company)
        {
            user.Company = company;
            return this;
        }
        public UserBuilder SetAge(int age)
        {
            user.Age = age > 0 ? age : 0;
            return this;
        }
        public UserBuilder IsMarried
        {
            get
            {
                user.IsMarried = true;
                return this;
            }
        }
        public User Build()
        {
            return user;
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
