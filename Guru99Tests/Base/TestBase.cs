namespace Guru99Tests.Base
{
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetUp()
        {
            app = new AppManager();
        }

        [TearDown]
        protected void TearDown()
        {
            app.Stop();
        }
    }
}
