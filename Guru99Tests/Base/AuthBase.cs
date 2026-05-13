using Guru99Tests.Data;

namespace Guru99Tests.Base
{
    public class AuthBase : TestBase 
    {
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData(Settings.Settings.Login, Settings.Settings.Password));
        }
    }
}