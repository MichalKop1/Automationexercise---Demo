using AutomationExercise.Common;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using AutomationExercise.Factories;
using AutomationExercise.Helpers;
using OpenQA.Selenium.Interactions;

namespace AutomationExercise.Pages;

public class LoginOrRegisterPage
{
	private readonly IWebDriver driver;
	private WebDriverWait wait;
	private ObjectClass settings;

	private By UserSignUpLabel = By.CssSelector("div.signup-form h2");
	private By UserLogInLabel = By.CssSelector("div.login-form h2");

	private By NameTextBox = By.CssSelector("input[data-qa='signup-name']");
	private By EmailTextBox = By.CssSelector("input[data-qa='signup-email']");
	private By SignupButton = By.CssSelector("button[data-qa='signup-button']");


	private By LoginTextBox = By.CssSelector("input[data-qa='login-email']");
	private By PasswordTextBox = By.CssSelector("input[data-qa='login-password']");
	private By LoginButton = By.CssSelector("button[data-qa='login-button']");

	private By ErrorPopUp = By.CssSelector("p[style='color: red;']");

	public LoginOrRegisterPage()
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

	public LoginOrRegisterPage Open()
	{
		driver.Url = settings.LoginOrRegisterLink;

		return this;
	}

	public bool IsUserSignUpVisible()
	{
		var signupLabel = driver.FindElement(UserSignUpLabel);

		return signupLabel.Displayed;
	}

	public bool IsUserLogInVisible()
	{
		var loginLabel = driver.FindElement(UserLogInLabel);

		return loginLabel.Displayed;
	}

	public LoginOrRegisterPage CompleteNewUserCredentials(string name, string email)
	{
		var nameBox = driver.FindElement(NameTextBox);
		var emailBox = driver.FindElement(EmailTextBox);

		Actions fillInTheForm = new Actions(driver);

		fillInTheForm
			.Click(nameBox)
				.SendKeys(name)
			.Click(emailBox)
				.SendKeys(email)
			.Perform();

		return this;
	}

	public LoginOrRegisterPage CompleteLoginCredentials(string email, string password)
	{
		var emailTextbox = driver.FindElement(LoginTextBox);
		var passwordTextbox = driver.FindElement(PasswordTextBox);
		Actions fillInTheForm = new Actions(driver);

		fillInTheForm
			.Click(emailTextbox)
				.SendKeys(email)
			.Click(passwordTextbox)
				.SendKeys(password)
			.Perform();

		return this;
	}



	public bool LoginWithIncorrectData(string login, string pass)
	{
		var emailTextbox = driver.FindElement(LoginTextBox);
		var passwordTextbox = driver.FindElement(PasswordTextBox);
		var loginbutton = driver.FindElement(LoginButton);
		Actions fillInTheForm = new Actions(driver);

		fillInTheForm
			.Click(emailTextbox)
				.SendKeys(login)
			.Click(passwordTextbox)
				.SendKeys(pass)
			.Pause(TimeSpan.FromMilliseconds(200))
			.Click(loginbutton)
			.Perform();

		var error = driver.FindElement(ErrorPopUp);

		return error.Displayed;
	}

	public LoginOrRegisterPage SignupShowsError()
	{
		var signupButton = driver.FindElement(SignupButton);
		signupButton.Click();

		return this;
	}

	public bool EmailExistsErrorVisible()
	{
		var errorMessage = driver.FindElement(ErrorPopUp);

		return errorMessage.Displayed;
	}

	public SignupPage Signup()
	{
		var signupButton = driver.FindElement(SignupButton);
		signupButton.Click();

		return new SignupPage();
	}

	public IndexPage Login()
	{
		var loginbutton = driver.FindElement(LoginButton);
		loginbutton.Click();

		return new IndexPage();
	}
}
