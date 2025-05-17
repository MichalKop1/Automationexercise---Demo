using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExercise.Helpers
{
    public class DriverBuilder
    {
        private readonly IWebDriver driver;

        private bool incognito;
		private bool headless;
		private bool maximized;

        public DriverBuilder Incognito()
        {
            incognito = true;
			return this;
        }

		public DriverBuilder Headless()
		{
			headless = true;
			return this;
		}

		public DriverBuilder Maximized()
		{
			maximized = true;
			return this;
		}


		public DriverOptions Build(Browser currentBrowser)
		{
			DriverOptions options;

			if (currentBrowser is Browser.Chrome)
			{
				var chrome = new ChromeOptions();

				if (incognito) chrome.AddArgument("--incognito");
				if (headless) chrome.AddArguments("--headless", "--disable-gpu");
				if (maximized) chrome.AddArgument("--start-maximized");

				options = chrome;
			}

			else if (currentBrowser is Browser.Firefox)
			{
				var firefox = new FirefoxOptions();

				if (incognito) firefox.AddArgument("-inprivate");
				if (headless) firefox.AddArguments("--headless", "--disable-gpu");
				if (maximized) firefox.AddArgument("--start-maximized");

				options = firefox;
			}

			else if (currentBrowser is Browser.Edge)
			{
				var edge = new EdgeOptions();

				if (incognito) edge.AddArgument("-inprivate");
				if (headless) edge.AddArguments("--headless", "--disable-gpu");
				if (maximized) edge.AddArgument("--start-maximized");

				options = edge;
			}
			else
			{
				throw new ArgumentNullException(nameof(options));
			}

			return options;
		}
	}
}
