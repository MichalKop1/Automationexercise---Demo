using AutomationExercise.Factories;
using AutomationExercise.Pages;
using AutomationExerciseTests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExerciseTests.PageTests;

[TestFixture]
public class IndexPageTests
{
	private IndexPage _indexPage;

	[OneTimeSetUp]
	public void SetUp()
	{
		_indexPage = new IndexPage();
	}

	[TestCaseSource(typeof(PagestTestData), nameof(PagestTestData.RegisterUserTestData))]
	public void RegisterUser_ProvideCorrectData_RegisterSuccessful(string login, string email, string password, string name, string surname, string company, string address1, string address2, string state,string city, string zipCode, string phoneNumber)
	{
		var indexPageOpened = _indexPage.Open();
		bool isPageVisible = indexPageOpened.IsIndexPageVisible();
		Assert.That(isPageVisible, Is.True);

		var loginRegisterPage = indexPageOpened.GoToLoginRegisterPage();
		bool isSignupLabelVisible = loginRegisterPage.IsUserSignUpVisible();
		Assert.That(isSignupLabelVisible, Is.True);

		var credentialsFill = indexPageOpened.GoToLoginRegisterPage().CompleteNewUserCredentials(login, email)
			.Signup().FillTheEntireForm(password, name, surname, company, address1, state, city, zipCode, phoneNumber)
			.Register();
		bool createdAccLabel = credentialsFill.IsAccountCreatedLabelVisible();
		Assert.That(createdAccLabel, Is.True);

		var backToIndex = credentialsFill.ContinueToIndexPage();
		bool accountCreatedLabel = backToIndex.IsLoggedInLabelVisible();
		Assert.That(accountCreatedLabel, Is.True);

		var deleteAccount = backToIndex.DeleteAccount();
		bool accDeletedLabel = deleteAccount.IsAccountDeletedLabelVisible();
		Assert.That(accDeletedLabel, Is.True);

		deleteAccount.ClickContinueAfterDelete();
	}

	[TestCase("zbych09@gmail.com", "12345")]
	public void LogIn_UseActualAccount_LogInsCorrectly(string email, string password)
	{
		var indexPage = _indexPage.Open();
		bool indexPageVisible = indexPage.IsIndexPageVisible();
		Assert.That(indexPageVisible, Is.True);

		var loginPage = indexPage.GoToLoginRegisterPage();
		bool loginLabelVisible = loginPage.IsUserLogInVisible();
		Assert.That(loginLabelVisible, Is.True);

		var login = loginPage.CompleteLoginCredentials(email, password).Login();
		bool loggedInVisible = login.IsLoggedInLabelVisible();
		Assert.That(loggedInVisible, Is.True);

		login.Logout();
	}

	[TestCase("erere@ggg", "nbnbgh")]
	public void LogIn_IncorrectCredentials_DisplaysError(string email, string pass)
	{
		var indexPage = _indexPage.Open();
		bool pageVisible = indexPage.IsIndexPageVisible();
		Assert.That(pageVisible, Is.True);

		var loginPage = indexPage.GoToLoginRegisterPage();
		bool loginLabelVisible = loginPage.IsUserLogInVisible();
		Assert.That(loginLabelVisible, Is.True);

		var wrongData = loginPage.LoginWithIncorrectData(email, pass);

		Assert.That(wrongData, Is.True);
	}

	[TestCase("zbych09@gmail.com", "12345")]
	public void Register_AccountAlreadyExists_DisplaysError(string email, string name)
	{
		var indexPage = _indexPage.Open();
		bool pageVisible = indexPage.IsIndexPageVisible();
		Assert.That(pageVisible, Is.True);

		var loginPage = indexPage.GoToLoginRegisterPage().CompleteNewUserCredentials(name, email);
		bool registerLabelVisible = loginPage.IsUserSignUpVisible();
		Assert.That(registerLabelVisible, Is.True);

		var register = loginPage.SignupShowsError();
		bool errorVisible = register.EmailExistsErrorVisible();

		Assert.That(errorVisible, Is.True);
	}

	[TestCase("Jurek", "jurek@gmail.com", "Why so expensive", "Me no liky expensive, me sad")]
	public void ContactUsPage_FillInTheForm_Success(string name, string email, string subject, string message)
	{
		var filePath = Path.Join(AppDomain.CurrentDomain.BaseDirectory, "Resources" ,"hello.png");

		var indexPage = _indexPage.Open();
		bool pageVisible = indexPage.IsIndexPageVisible();
		Assert.That(pageVisible, Is.True);

		var getInTouch = indexPage.GoToContactUsPage();
		bool getInTouchVisible = getInTouch.GetInTouchLabelVisible();
		Assert.That(getInTouchVisible, Is.True);

		var completeTheForm = getInTouch
			.FillInTheForm(name, email, subject, message)
			.AttachFile(filePath)
			.Submit();
		bool successVisible = completeTheForm.DetailsSubmittedSuccessfullyVisible();
		Assert.That(successVisible, Is.True);

		var backToIndexPage = completeTheForm.ClickHomeButton();
		bool indexPageVisible = backToIndexPage.IsIndexPageVisible();
		Assert.That(indexPageVisible, Is.True);
	}

	[Test]
	public void TestCasesPage_OpenSubpage_IsVisible()
	{
		var indexPage = _indexPage.Open();
		bool pageVisible = indexPage.IsIndexPageVisible();
		Assert.That(pageVisible, Is.True);

		bool isTestCasesVisible = indexPage.GoToTestCasesPage().IsPageVisible();
		Assert.That(isTestCasesVisible, Is.True);
	}

	[Test]
	public void ProductsPage_VerifyProduct_ProductExists()
	{
		var indexPage = _indexPage.Open();
		bool pageVisible = indexPage.IsIndexPageVisible();
		Assert.That(pageVisible, Is.True);

		var productPage = indexPage.GoToProductsPage();
		bool allProductsLabel = productPage.AllProductsVisible();
		bool allProductsList = productPage.ListOfFeaturedItemsVisible();
		Assert.That(allProductsLabel, Is.True);
		Assert.That(allProductsList, Is.True);

		var productDetailsPage = productPage.ViewFirstProduct();
		bool detailsPage = productDetailsPage.ProductDetailsPageVisible();
		bool verifyInfo = productDetailsPage.ProductDetailedDescriptionVisible();
		Assert.That(detailsPage, Is.True);
		Assert.That(verifyInfo, Is.True);
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		WebDriverFactory.Quit();
	}
}
