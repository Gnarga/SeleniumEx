using NUnit.Framework;
using SeleniumWithC;


namespace Selenium.Sections
{
    class Login
    {
        public static void Valid_User_Login()
        {
            Helper.ClickOnButtonById("nav-link-accountList");
            Helper.SendKeys("ap_email", TestData.Get_email());
            Helper.ClickOnButtonById("continue");
            Helper.SendKeys("ap_password", TestData.Get_password());
            Helper.ClickOnButtonById("signInSubmit");
        }
        
        public static void No_User_Logged_In()
        {
            var text = Helper.GetElementTextById("nav-link-accountList-nav-line-1");
            Assert.AreEqual(text, "Hello, Sign in");
        }

        public static void Invalid_User_Email()
        {
            Helper.ClickOnButtonById("nav-link-accountList");
            Helper.SendKeys("ap_email", TestData.Get_Invalid_email());
            Helper.ClickOnButtonById("continue");
        }
    }
}
