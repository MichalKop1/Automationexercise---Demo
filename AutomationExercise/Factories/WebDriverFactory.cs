using AutomationExercise.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AutomationExercise.Factories;

public static class WebDriverFactory
{
	private static IWebDriver driver;

	public static IWebDriver GetDriver(Browser key)
	{
		if (driver is not null)
		{
			return driver;
		}
		else if (key is Browser.Chrome)
		{
			driver = new ChromeDriver();
		}
		else if (key is Browser.Firefox)
		{
			driver = new FirefoxDriver();
		}
		else if (key is Browser.Edge)
		{
			driver = new EdgeDriver();
		}
		else
		{
			throw new ArgumentException(nameof(key));
		}

		return driver;
	}

	public static IWebDriver GetDriver(Browser key, DriverOptions options)
	{
		if (driver is not null)
		{
			return driver;
		}
		else if (key is Browser.Chrome)
		{
			driver = new ChromeDriver((ChromeOptions)options);
		}
		else if (key is Browser.Firefox)
		{
			driver = new FirefoxDriver((FirefoxOptions)options);
		}
		else if (key is Browser.Edge)
		{
			driver = new EdgeDriver((EdgeOptions)options);
		}
		else
		{
			throw new ArgumentException(nameof(key));
		}

		return driver;
	}

	public static void Quit()
	{
		driver.Quit();
	}
}
