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
            FillTheField(By.Name("uid"), user.Username);
            FillTheField(By.Name("password"), user.Password);

            driver.FindElement(By.Name("btnLogin")).Click();
            Thread.Sleep(2000);
        }
    }
}