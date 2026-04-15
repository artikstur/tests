using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Guru99Tests
{
    public class TestBase
    {
        protected IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1200, 1100);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://demo.guru99.com/V4/");
        }

        public void Login(AccountData user)
        {
            FillTheField(By.Name("uid"), user.Username);
            FillTheField(By.Name("password"), user.Password); 

            driver.FindElement(By.Name("btnLogin")).Click();
            Thread.Sleep(2000);
        }

        public void InitCustomerCreation()
        {
            driver.FindElement(By.LinkText("New Customer")).Click();
            Thread.Sleep(1500);
        }

        public void SubmitCustomerCreation()
        {
            IWebElement submitBtn = driver.FindElement(By.Name("sub"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitBtn);
            Thread.Sleep(1000);
            submitBtn.Click();
            Thread.Sleep(3000);
        }

        public void FillTheField(By locator, string value)
        {
            if (value != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(value);
            }
        }
    }
}
