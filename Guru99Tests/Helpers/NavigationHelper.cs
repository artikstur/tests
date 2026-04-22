using Guru99Tests.Base;
using OpenQA.Selenium;

namespace Guru99Tests.Helpers
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToNewCustomerPage()
        {
            driver.FindElement(By.LinkText("New Customer")).Click();
            Thread.Sleep(1500);
        }

        public void GoToEditCustomerPage()
        {
            driver.FindElement(By.LinkText("Edit Customer")).Click();
            Thread.Sleep(1500);
        }

        public void GoToDeleteCustomerPage()
        {
            driver.FindElement(By.LinkText("Delete Customer")).Click();
            Thread.Sleep(1500);
        }
    }
}
