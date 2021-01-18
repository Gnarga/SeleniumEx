using NUnit.Framework;
using Selenium;
using Selenium.Sections;

namespace SeleniumWithC
{
    public class Tests
    {

        [SetUp]
        public static void StartBrowser()
        {
            Helper.Initialize();
        }

        [Test]
        public void Valid_Login_Test()
        {
            //Given
            Login.No_User_Logged_In();

            //When
            Login.Valid_User_Login();

            //Then
            var loggedInUser = Helper.GetElementTextById("nav-link-accountList-nav-line-1");
            Assert.AreEqual(loggedInUser, "Hello, SeleniumTestingFredrik");          
        }

        [Test]
        public void Invalid_Login_Test()
        {
            //Given
            Login.No_User_Logged_In();

            //When
            Login.Invalid_User_Email();

            //Then
            var alertMessage = Helper.GetElementTextByClassName("a-unordered-list");
            Assert.AreEqual(alertMessage, "We cannot find an account with that e-mail address");

        }

        [TearDown]
        public void CloseBrowser()
        {
           Helper.Quit();
        }
    }
}