using AutomationExercise.Common;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using AutomationExercise.Factories;
using AutomationExercise.Helpers;

namespace AutomationExercise.Pages;

public class ProductsPage
{
	private readonly IWebDriver driver;
	private WebDriverWait wait;
	private ObjectClass settings;

	private readonly By AllProductsLabel = By.CssSelector("div.features_items h2");
	private readonly By ListOfFeaturedProducts = By.ClassName("features_items");
	private readonly By ViewProductFirst = By.CssSelector("a[href='/product_details/1']");

	private readonly By ProductName = By.CssSelector("div.product-information h2");
	private readonly By ProductCategory = By.CssSelector("div.product-information p");
	private readonly By ProductPrice = By.CssSelector("div span span");
	private readonly By ProductAvailability = By.CssSelector("div.product-information p:nth-child(6)");
	private readonly By ProductCondition = By.CssSelector("div.product-information p:nth-child(7)");
	private readonly By ProductBrand = By.CssSelector("div.product-information p:nth-child(8)");

	public ProductsPage()
    {
		settings = JsonHelper.GetJsonSettings;
		Browser browser = JsonHelper.GetBrowser;

		var options = new DriverBuilder()
			.Incognito()
			.Build(browser);

		driver = WebDriverFactory.GetDriver(browser, options);

		wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
	}

	public bool AllProductsVisible()
	{
		var label = driver.FindElement(AllProductsLabel);

		return label.Displayed;
	}

	public bool ListOfFeaturedItemsVisible()
	{
		var list = driver.FindElement(ListOfFeaturedProducts);

		return list.Displayed;
	}

	public ProductsPage ViewFirstProduct()
	{
		var viewButton = driver.FindElement(ViewProductFirst);
		viewButton.Click();

		return this;
	}

	public bool ProductDetailsPageVisible()
	{
		bool title = driver.Url.Contains("product_details");
		var a = driver.Url;

		return title;
	}

	public bool ProductDetailedDescriptionVisible()
	{
		var name = driver.FindElement(ProductName);
		var n = name.Displayed;
		var category = driver.FindElement(ProductCategory);
		var cat = category.Displayed;
		var price = driver.FindElement(ProductPrice);
		var pr = price.Displayed;
		var available = driver.FindElement(ProductAvailability);
		var av = available.Displayed;
		var condition = driver.FindElement(ProductCondition);
		var cond = condition.Displayed;
		var brand = driver.FindElement(ProductBrand);
		var br = brand.Displayed;

		return name.Displayed && category.Displayed && price.Displayed 
			&& available.Displayed && condition.Displayed && brand.Displayed;
	}
}
