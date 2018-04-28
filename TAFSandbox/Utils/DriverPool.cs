namespace TAFSandbox.Utils
{
    using System;
    using System.Collections.Concurrent;

    using OpenQA.Selenium;

    //ToDo: add additional layer of abstraction - Browser
    //ToDo: switch approach from DriverPool to BrowserPool
    //ToDo: Add appropriate logging 

    /// <summary>
    /// Represents a pool of available Drivers objects and provides a unified means of working with a Browser abstraction.
    /// </summary>
    public static class DriverPool 
    {
        private static ConcurrentDictionary<string, IWebDriver> driversMap = new ConcurrentDictionary<string, IWebDriver>();

        /// <summary>
        /// Returns of a Driver instance given its reference name
        /// </summary>
        /// <param name="driverName">
        /// The driver name.
        /// </param>
        /// <returns>
        /// The <see cref="IWebDriver"/>.
        /// </returns>
        /// <exception cref="ArgumentException">Driver with this name is not registred 
        /// </exception>
        public static IWebDriver GetDriver(string driverName)
        {
            if (IsRegistred(driverName))
            {
                IWebDriver driver;
                driversMap.TryGetValue(driverName, out driver);
                return driver;
            }

            throw new ArgumentException($"The {driverName} is not registred", nameof(driverName));
        }

        /// <summary>
        /// Only registers a new instance of Driver with a valid reference name
        /// </summary>
        /// <param name="driverName">The reference name of a Driver </param>
        /// <param name="driver">The Driver object to register in the pool</param>
        public static void RegisterDriver(string driverName, IWebDriver driver) //return bool????
        {
            if (IsRegistred(driverName))
            {
                IWebDriver oldDriverValue;
                driversMap.TryGetValue(driverName, out oldDriverValue);
                driversMap.TryUpdate(driverName, driver, oldDriverValue);
            }
            else
            {
                driversMap.TryAdd(driverName, driver);
            }            
        }

        /// <summary>
        /// Disposes of a Driver instance given its reference name.
        /// </summary>
        /// <param name="driverName">The reference name of a Driver.</param>
        public static void DisposeDriver(string driverName)
        {
            if (IsRegistred(driverName))
            {
                IWebDriver obsoleteDriver;
                driversMap.TryRemove(driverName, out obsoleteDriver);
                obsoleteDriver.Quit();
            }   
        }

        /// <summary>
        /// Disposes of all Driver instances already registred in pool.
        /// </summary>
        public static void DisposeAllDrivers()
        {
            if (driversMap.Keys.Count != 0)
            {
                foreach (string driverName in driversMap.Keys)
                {
                    DisposeDriver(driverName);
                }
            }
        }

        private static bool IsRegistred(string key)
        {
            return driversMap.ContainsKey(key);
        }
    }
}
