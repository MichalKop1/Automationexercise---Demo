using AutomationExercise.Common;
using AutomationExercise.Factories;
using AutomationExercise.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace AutomationExercise.Pages;

public class ContactUsPage
{
	private readonly IWebDriver driver;
	private WebDriverWait wait;
	private ObjectClass settings;

	private readonly By GetInTouchLabel = By.CssSelector("div.col-sm-12 h2");
	private readonly By NameTextBox = By.Name("name");
	private readonly By EmailTextBox = By.Name("email");
	private readonly By SubjectTextBox = By.Name("subject");
	private readonly By MessageTextBox = By.Id("message");

	private readonly By AttachFileButton = By.Name("upload_file");


	private readonly By SubmitButton = By.Name("submit");
	private readonly By DetailsSubmittedSuccessfullyLabel = By.CssSelector("div[class='status alert alert-success']");
	private readonly By HomeButton = By.CssSelector("a[href='/']");

	public ContactUsPage()
    {
		settings = JsonHelper.GetJsonSettings;
		Browser browser = JsonHelper.GetBrowser;

		var options = new DriverBuilder()
		.Incognito()
		.Build(browser);

		driver = WebDriverFactory.GetDriver(browser, options);

		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
	}

	public ContactUsPage FillInTheForm(string name, string email, string subject, string message)
	{
		var nameTextbox = driver.FindElement(NameTextBox);
		nameTextbox.SendKeys(name);

		var emailTextBox = driver.FindElement(EmailTextBox);
		emailTextBox.SendKeys(email);

		var subjectTextBox = driver.FindElement(SubjectTextBox);
		subjectTextBox.SendKeys(subject);

		var messageTextBox = driver.FindElement(MessageTextBox);
		messageTextBox.SendKeys(message);

		return this;
	}

	public bool GetInTouchLabelVisible()
	{
		var getInTouchlabel = driver.FindElement(GetInTouchLabel);

		return getInTouchlabel.Displayed;
	}

	public ContactUsPage AttachFile(string path)
	{
		var attachFileButton = driver.FindElement(AttachFileButton);
		attachFileButton.SendKeys(path);

		return this;
	}

	public ContactUsPage Submit()
	{
		var submitButton = driver.FindElement(SubmitButton);
		submitButton.Click();

		IAlert alert = driver.SwitchTo().Alert();
		alert.Accept();

		return this;
	}

	public bool DetailsSubmittedSuccessfullyVisible()
	{
		var label = driver.FindElement(DetailsSubmittedSuccessfullyLabel);

		return label.Displayed;
	}

	public IndexPage ClickHomeButton()
	{
		var button = driver.FindElement(HomeButton);
		button.Click();

		return new IndexPage();
	}
}
