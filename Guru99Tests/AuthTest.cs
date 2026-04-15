using NUnit.Framework;

namespace Guru99Tests
{
    [TestFixture]
    public class AuthTest : TestBase
    {
        [Test]
        public void authTest()
        {
            OpenHomePage();
            AccountData admin = new AccountData("mngr659011", "byturEg");
            Login(admin);

            Assert.That(driver.PageSource, Does.Contain("Manger Id : mngr659011"));
        }
    }
}
