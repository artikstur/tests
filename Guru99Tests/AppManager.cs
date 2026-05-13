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

        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

        private AppManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1200, 1100);
            baseURL = Settings.Settings.BaseURL;

            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            contact = new ContactHelper(this);
        }

        public static AppManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.Navigation.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

        public IWebDriver Driver { get { return driver; } }
        public NavigationHelper Navigation { get { return navigation; } }
        public LoginHelper Auth { get { return auth; } }
        public ContactHelper Contact { get { return contact; } }

        ~AppManager()
        {
            try
            {
                driver.Quit();
                driver.Dispose();
            }
            catch (Exception)
            {   }
        }
    }
}
