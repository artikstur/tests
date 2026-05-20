namespace VideoPlayerTests.Base;

public class TestBase
{
    protected AppManager app;

    [SetUp]
    public void SetUp()
    {
        app = AppManager.GetInstance();
    }

    [TearDown]
    public void TearDown()
    {
        app.Stop();
    }
}