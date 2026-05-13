using Guru99Tests.Base;
using Guru99Tests.Data;
using OpenQA.Selenium;

namespace Guru99Tests.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager) { }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Log out"));
        }

        public bool IsLoggedIn(string username)
        {
            return IsLoggedIn() && driver.PageSource.Contains("Manger Id : " + username);
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                IWebElement logoutLink = driver.FindElement(By.LinkText("Log out"));

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", logoutLink);
                Thread.Sleep(500);

                try
                {
                    logoutLink.Click();
                }
                catch (Exception)
                {
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", logoutLink);
                }

                try
                {
                    driver.SwitchTo().Alert().Accept();
                    Thread.Sleep(1000);
                }
                catch (NoAlertPresentException) { }
            }
        }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }

            FillTheField(By.Name("uid"), user.Username);
            FillTheField(By.Name("password"), user.Password);
            driver.FindElement(By.Name("btnLogin")).Click();
            Thread.Sleep(2000);
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (UnhandledAlertException)
            {
                return false;
            }
        }
    }
}