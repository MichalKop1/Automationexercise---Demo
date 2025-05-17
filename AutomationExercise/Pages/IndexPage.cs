using AutomationExercise.Common;
using AutomationExercise.Factories;
using AutomationExercise.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Pages;
// zbych09@gmail.com
// zbych09
public class IndexPage
{
	// https://automationexercise.com/test_cases
	private readonly IWebDriver driver;
	private WebDriverWait wait;
    ObjectClass settings;

    private readonly By ConsentButton = By.ClassName("fc-button-label");
	private readonly By IndexPageLogo = By.CssSelector("img[src='/static/images/home/logo.png']");
	
    private readonly By ProductOne = By.CssSelector("a[data-product-id='1']");
    private readonly By ContinueShoppingButton = By.CssSelector("button.btn.btn-success.close-modal.btn-block");
	private readonly By CartButton = By.CssSelector("a[href='/view_cart'");
	private readonly By LoginRegisterButton = By.CssSelector("a[href='/login'");

	private readonly By LoggedInLabel = By.ClassName("fa-user");
	private readonly By DeleteAccountButton = By.CssSelector("a[href='/delete_account']");
	private readonly By AccountDeletedLabel = By.CssSelector("h2[data-qa='account-deleted']");
	private readonly By ContinueButtonAfterDeletedAccount = By.CssSelector("a[data-qa='continue-button']");
	private readonly By LogoutButton = By.CssSelector("a[href='/logout']");
	private readonly By ContactUsButton = By.CssSelector("a[href='/contact_us']");
	private readonly By TestCasesButton = By.CssSelector("a[href='/test_cases']");
	private readonly By ProductsButton = By.CssSelector("a[href='/products']");

	public IndexPage()
    {
		settings = JsonHelper.GetJsonSettings;
        Browser browser = JsonHelper.GetBrowser;

		var options = new DriverBuilder()
            .Incognito()
			.Headless()
            .Build(browser);

        driver = WebDriverFactory.GetDriver(browser, options);
		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
	}

    public IndexPage Open()
    {
        driver.Url = settings.ConnectionLink;

        var but = driver.FindElements(ConsentButton);
		but.FirstOrDefault()?.Click();

		return this;
    }

	public bool IsIndexPageVisible()
	{
		var a = driver.FindElement(IndexPageLogo);

		return a.Displayed;
	}

    public IndexPage AddFirstRecomendedProductToCart()
    {
		var product = driver.FindElement(ProductOne);
		product.Click();

		var continueButton = driver.FindElement(ContinueShoppingButton);
		continueButton.Click();

		return this;
	}

    public CartPage GoToCart()
    {
		var cart = driver.FindElement(CartButton);
		cart.Click();

		return new CartPage();
	}

	public LoginOrRegisterPage GoToLoginRegisterPage()
	{
		var loginRegister = driver.FindElement(LoginRegisterButton);
		loginRegister.Click();

		return new LoginOrRegisterPage();
	}

	public ContactUsPage GoToContactUsPage()
	{
		var contactUs = driver.FindElement(ContactUsButton);
		contactUs.Click();

		return new ContactUsPage();
	}

	public TestCasesPage GoToTestCasesPage()
	{
		var testCasesButton = driver.FindElement(TestCasesButton);
		testCasesButton.Click();

		return new TestCasesPage();
	}

	public ProductsPage GoToProductsPage()
	{
		var productsButton = driver.FindElement(ProductsButton);
		productsButton.Click();

		return new ProductsPage();
	}

	public IndexPage DeleteAccount()
	{
		var delAccButton = driver.FindElement(DeleteAccountButton);
		delAccButton.Click();

		return this;
	}

	public IndexPage ClickContinueAfterDelete()
	{
		var continueButton = driver.FindElement(ContinueButtonAfterDeletedAccount);
		continueButton.Click();

		return this;
	}

	public bool IsLoggedInLabelVisible()
	{
		var loggedLabel = driver.FindElement(LoggedInLabel);

		return loggedLabel.Displayed;
	}

	public bool IsAccountDeletedLabelVisible()
	{
		var delLabel = driver.FindElement(AccountDeletedLabel);

		return delLabel.Displayed;
	}

	public IndexPage Logout()
	{
		var logout = driver.FindElement(LogoutButton);
		logout.Click();

		return this;
	}
}
