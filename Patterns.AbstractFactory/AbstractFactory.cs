namespace Patterns.AbstractFactory
{
	using System;

    class Program1
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
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

//public abstract class BaseDriverFactory
//{

//	public IWebDriver GetDriver(IWebDriverSettings webDriverSettings)

//	protected abstract DriverOptions InitOptions(IWebDriverSettings webDriverSettings);

//	protected abstract IWebDriver InitDriverWithOptions(DriverOptions driverOptions);

//	protected abstract DesiredCapabilities InitRemoteDriverCapabilities(IWebDriverSettings webDriverSettings);
//}

// public class ChromeDriverFactory : BaseDriverFactory

//public static class WebDriverFactory
//{
//public static IWebDriver CreateWebDriver(IWebDriverSettings settings)
//{
//Guard.ForNull(settings, nameof(settings));
//BaseDriverFactory factory;

//	switch (settings.BrowserName)
//{
//	case BrowserName.Chrome:
//	factory = new ChromeDriverFactory();
//	break;

//	case BrowserName.ChromeBeta:
//	factory = new ChromeBetaDriverFactory();
//	break;

//	case BrowserName.HeadlessChrome:
//	factory = new HeadlessChromeDriverFactory();
//	break;

//	case BrowserName.Firefox60:
//	factory = new FirefoxDriverFactory("60");
//	break;

//	case BrowserName.Firefox68:
//	factory = new FirefoxDriverFactory("68");
//	break;

//	case BrowserName.HeadlessFirefox60:
//	factory = new HeadlessFirefoxDriverFactory("60");
//	break;

//	case BrowserName.HeadlessFirefox68:
//	factory = new HeadlessFirefoxDriverFactory("68");
//	break;

//	case BrowserName.InternetExplorer:
//	factory = new InternetExplorerDriverFactory();
//	break;

//	case BrowserName.HeadlessInternetExplorer:
//	factory = new HeadlessInternetExplorerDriverFactory();
//	break;

//	case BrowserName.MicrosoftEdge:
//	factory = new EdgeDriverFactory();
//	break;

//	default:
//	throw new InvalidEnumArgumentException(FormattableString.Invariant($"The browser is unsupported: {settings.BrowserName}"));
//}

//return factory.GetDriver(settings);
//}
//}
