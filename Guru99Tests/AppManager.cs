using Guru99Tests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Guru99Tests
{
    public class AppManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected NavigationHelper navigation;
        protected LoginHelper auth;
        protected ContactHelper contact;

        public AppManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1200, 1100);
            baseURL = "https://demo.guru99.com/V4/";

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            contact = new ContactHelper(this);
        }

        public IWebDriver Driver { get { return driver; } }
        public NavigationHelper Navigation { get { return navigation; } }
        public LoginHelper Auth { get { return auth; } }
        public ContactHelper Contact { get { return contact; } }

        public void Stop()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}