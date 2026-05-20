using VideoPlayerTests.Base;

namespace VideoPlayerTests.Helpers;

public class PlayerHelper(AppManager manager) : HelperBase(manager)
{
    public void ClickPlay()
    {
        driver.FindElementByName("Воспроизвести").Click();
        Thread.Sleep(1000);
    }

    public void ClickPause()
    {
        driver.FindElementByName("Приостановить").Click();
        Thread.Sleep(1500);
    }

    public void ClickStop()
    {
        driver.FindElementByName("Остановить").Click();
        Thread.Sleep(500);
    }
}