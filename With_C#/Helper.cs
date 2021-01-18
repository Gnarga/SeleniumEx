using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumWithC;
using System;


namespace Selenium
{

    class Helper
    {
        static IWebDriver driver = new ChromeDriver(TestData.Get_chromedriver());
        public static void Initialize()
        {         
            driver.Url = "https://www.amazon.co.uk/";
            driver.Manage().Window.Maximize();
        }


    public static void ClickOnButtonById(string elementId)
       {
            WaitUntilIdAvailable(elementId);
            driver.FindElement(By.Id(elementId)).Click();
        }

    public static void SendKeys(string elementId, string text)
        {
            WaitUntilIdAvailable(elementId);
            driver.FindElement(By.Id(elementId)).SendKeys(text);
        }


    public static bool WaitUntilIdAvailable(string elementId)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    return driver.FindElement(By.Id(elementId));
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public static bool WaitUntilClassNameAvailable(string elementClassName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    return driver.FindElement(By.ClassName(elementClassName));
                });
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public static string GetElementTextById(string elementId)
        {
            WaitUntilIdAvailable(elementId);
            return driver.FindElement(By.Id(elementId)).Text;
        }

        public static string GetElementTextByClassName(string elementClassName)
        {
            WaitUntilClassNameAvailable(elementClassName);
            return driver.FindElement(By.ClassName(elementClassName)).Text;
        }

        public static void Quit()
        {
            driver.Quit();
        }

    }
}
