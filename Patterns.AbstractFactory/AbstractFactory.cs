namespace Patterns.AbstractFactory
{
	using System;

    class Program1
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new WarriorFactory());
            Console.WriteLine($"Elf");
            elf.Hit();
            elf.Run();

            Hero Warrior = new Hero(new WarriorFactory());
            Console.WriteLine($"Warrior");
            Warrior.Hit();
            Warrior.Run();

            Console.ReadLine();
        }
    }

    //абстрактный класс - оружие
    abstract class Weapon
    {
        public abstract void Hit();
    }
    // абстрактный класс движение
    abstract class Movement
    {
        public abstract void Move();
    }

    // класс арбалет
    class Arbalet : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Стреляем из арбалета");
        }
    }
    // класс меч
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("Бьем мечом");
        }
    }
    // движение полета
    class FlyMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Летим");
        }
    }
    // движение - бег
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("Бежим");
        }
    }
    // класс абстрактной фабрики
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
    }
    // Фабрика создания летящего героя с арбалетом
    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new FlyMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Arbalet();
        }
    }
    // Фабрика создания бегущего героя с мечом
    class WarriorFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }
    }
    // клиент - сам супергерой
    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        public Hero(HeroFactory factory)
        {
            this.weapon = factory.CreateWeapon();
            this.movement = factory.CreateMovement();
        }
        public void Run()
        {
            this.movement.Move();
        }
        public void Hit()
        {
            this.weapon.Hit();
        }
    }
}


///// <summary>
///// Factory for local WebDriver
///// </summary>
//internal interface IWebDriverFactory
//{
//    /// <summary>
//    /// Create options
//    /// </summary>
//    DriverOptions CreateOptions(WebDriverFactoryArgs args);

//    /// <summary>
//    /// Create Driver
//    /// </summary>
//    IWebDriver CreateDriver(DriverOptions options);
//}

///// <summary>
///// Create ChromeDriver
///// </summary>
//internal class ChromeDriverFactory : IWebDriverFactory
//{
//    /// <inheritdoc />
//    public IWebDriver CreateDriver(DriverOptions options)
//    {
//        return new ChromeDriver(options as ChromeOptions);
//    }

//    /// <inheritdoc />
//    public DriverOptions CreateOptions(WebDriverFactoryArgs args)
//    {
//        Validator.CheckParamatersForNull(args);
//        var options = ChromeOptionsFactory.Create(args);
//        return options;
//    }
//}

//var options = factory.CreateOptions(args);
//return factory.CreateDriver(options);
