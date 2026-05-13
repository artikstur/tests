using OpenQA.Selenium;
using Guru99Tests.Base; 
using Guru99Tests.Data;

namespace Guru99Tests.Tests 
{ 
    [TestFixture] 
    public class AuthTest : TestBase 
    {
        [Test] 
        public void LoginWithValidData() 
        { 
            app.Auth.Logout();

            AccountData admin = new AccountData(Settings.Settings.Login, Settings.Settings.Password);
            app.Auth.Login(admin);

            Assert.That(app.Auth.IsLoggedIn(admin.Username), Is.True);
        }

        [Test]
        public void LoginWithInvalidData()
        {
            app.Auth.Logout();

            AccountData invalidUser = new AccountData("invalid", "invalid");
            app.Auth.Login(invalidUser);

            try { app.Driver.SwitchTo().Alert().Accept(); }
            catch (NoAlertPresentException) { }

            Assert.That(app.Auth.IsLoggedIn(), Is.False);
        }
    }
}