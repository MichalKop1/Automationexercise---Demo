using AutomationExercise.Common;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using AutomationExercise.Factories;
using AutomationExercise.Helpers;


namespace AutomationExercise.Pages;

public class SignupPage
{
	private readonly IWebDriver driver;
	private WebDriverWait wait;
	private ObjectClass settings;

	private readonly By MrTitleRadioButton = By.Id("id_gender1");
	private readonly By MrsTitleRadioButton = By.Id("id_gender2");
	private By PasswordTextBox = By.Id("password");

	private By DayComboBox = By.Id("days");

	private By MonthComboBox = By.Id("months");

	private By YearComboBox = By.Id("years");

	private By NewsletterCheckBox = By.Id("newsletter");
	private By SpecialOffersCheckBox = By.Id("optin");
	private By FirstNameTextBox = By.Id("first_name");
	private By LastNameTextBox = By.Id("last_name");
	private By CompanyTextBox = By.Id("company");
	private By Address1TextBox = By.Id("address1");
	private By Address2TextBox = By.Id("address2");
	private By CountryComboBox = By.Id("country");
	private By StateTextBox = By.Id("state");
	private By CityTextBox = By.Id("city");
	private By ZipcodeTextBox = By.Id("zipcode");
	private By PhoneTextBox = By.Id("mobile_number");
	private By CreateAccountButton = By.CssSelector("button[data-qa='create-account']");
	private By AccountCreatedLabel = By.CssSelector("h2[data-qa='account-created']");
	private By AfterRegisterContinueButton = By.LinkText("Continue");


	public SignupPage()
    {
		settings = JsonHelper.GetJsonSettings;
		Browser browser = JsonHelper.GetBrowser;

		var options = new DriverBuilder()
			.Incognito()
			.Build(browser);

		driver = WebDriverFactory.GetDriver(browser, options);

		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
	}

	public SignupPage FillTheEntireForm(string password, string firstName, string lastName,
		string Company, string address, string state, string city,
		string zipcode, string mobileNumber)
	{
		var mrTitle = driver.FindElement(MrTitleRadioButton);
		mrTitle.Click();

		var passwordBox = driver.FindElement(PasswordTextBox);
		passwordBox.Click();
		passwordBox.SendKeys(password);

		var day = driver.FindElement(DayComboBox);
		var exactDay = new SelectElement(day);
		exactDay.SelectByValue("5");

		var month = driver.FindElement(MonthComboBox);
		var exactMonth = new SelectElement(month);
		exactMonth.SelectByValue("5");

		var year = driver.FindElement(YearComboBox);
		var exactYear = new SelectElement(year);
		exactYear.SelectByValue("1990");

		var newsletter = driver.FindElement(NewsletterCheckBox);
		newsletter.Click();

		var specialOffer = driver.FindElement(SpecialOffersCheckBox);
		specialOffer.Click();

		var _firstName = driver.FindElement(FirstNameTextBox);
		_firstName.Click();
		_firstName.SendKeys(firstName);

		var _lastName = driver.FindElement(LastNameTextBox);
		_lastName.Click();
		_lastName.SendKeys(lastName);

		var company = driver.FindElement(CompanyTextBox);
		company.Click();
		company.SendKeys(Company);

		var address1 = driver.FindElement(Address1TextBox);
		address1.Click();
		address1.SendKeys(address);

		var address2 = driver.FindElement(Address2TextBox);

		var country = driver.FindElement(CountryComboBox);
		var exactCountry = new SelectElement(country);
		exactCountry.SelectByValue("Canada");

		var _state = driver.FindElement(StateTextBox);
		_state.Click();
		_state.SendKeys(state);

		var _city = driver.FindElement(CityTextBox);
		_city.Click();
		_city.SendKeys(city);

		var _zipcode = driver.FindElement(ZipcodeTextBox);
		_zipcode.Click();
		_zipcode.SendKeys(zipcode);

		var _phone = driver.FindElement(PhoneTextBox);
		_phone.Click();
		_phone.SendKeys(mobileNumber);

		
	

		return this;
	}

	public SignupPage Register()
	{
		var createAccount = driver.FindElement(CreateAccountButton);
		createAccount.Click();

		return this;
	}

	public IndexPage ContinueToIndexPage()
	{
		var continueButton = driver.FindElement(AfterRegisterContinueButton);
		continueButton.Click();

		return new IndexPage();
	}

	public bool IsAccountCreatedLabelVisible()
	{
		var accCreatedLable = driver.FindElement(AccountCreatedLabel);

		return accCreatedLable.Displayed;
	}
}
