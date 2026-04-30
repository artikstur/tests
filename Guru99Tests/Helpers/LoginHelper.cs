using Guru99Tests.Base;
using Guru99Tests.Data;
using OpenQA.Selenium;

namespace Guru99Tests.Helpers
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager)
        {
        }

        public void Login(AccountData user)
        {
            if (IsElementPresent(By.Name("uid")))
            {
                FillTheField(By.Name("uid"), user.Username);
                FillTheField(By.Name("password"), user.Password);

                driver.FindElement(By.Name("btnLogin")).Click();
                Thread.Sleep(2000);
            }
        }

        private bool IsElementPresent(By locator)
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
        }
    }
}
