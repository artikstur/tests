using Guru99Tests.Base;
using Guru99Tests.Data;

namespace Guru99Tests.Tests
{
    [TestFixture]
    public class AuthTest : TestBase
    {
        [Test]
        public void authTest()
        {
            app.Navigation.OpenHomePage();

            AccountData admin = new AccountData("mngr659011", "byturEg");
            app.Auth.Login(admin);

            Assert.That(app.Driver.PageSource, Does.Contain("Manger Id : mngr659011"));
        }
    }
}