using AutomationExercise.Common;
using AutomationExercise.Factories;
using AutomationExercise.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Pages;

public class CartPage
{
	private readonly IWebDriver driver;
	private WebDriverWait wait;
	private ObjectClass settings;

	public CartPage()
	{
		settings = JsonHelper.GetJsonSettings;
		Browser browser = JsonHelper.GetBrowser;

		var options = new DriverBuilder()
			.Incognito()
			.Build(browser);

		driver = WebDriverFactory.GetDriver(browser, options);
		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
	}


}
