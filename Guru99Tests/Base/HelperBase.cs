using OpenQA.Selenium;

namespace Guru99Tests.Base
{
    public class HelperBase
    {
        protected AppManager manager;
        protected IWebDriver driver;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        protected void FillTheField(By locator, string value)
        {
            if (value != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(value);
            }
        }
    }
}
