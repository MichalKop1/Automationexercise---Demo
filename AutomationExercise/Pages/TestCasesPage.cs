using AutomationExercise.Common;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationExercise.Factories;
using AutomationExercise.Helpers;

namespace AutomationExercise.Pages;

public class TestCasesPage
{
	private readonly IWebDriver driver;
	private WebDriverWait wait;
	private ObjectClass settings;

    public TestCasesPage()
    {
		settings = JsonHelper.GetJsonSettings;
		Browser browser = JsonHelper.GetBrowser;

		var options = new DriverBuilder()
			.Incognito()
			.Build(browser);

		driver = WebDriverFactory.GetDriver(browser, options);

		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
	}

	public bool IsPageVisible()
	{
		bool titleSubstring = driver.Url.Contains("test_cases");

		return titleSubstring;
	}

}
