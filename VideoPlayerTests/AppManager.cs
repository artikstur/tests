using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using VideoPlayerTests.Helpers;

namespace VideoPlayerTests;

public class AppManager
{
    protected WindowsDriver<WindowsElement> driver;
    protected PlayerHelper player;
    private static AppManager instance;

    private AppManager()
    {
        AppiumOptions options = new AppiumOptions();
        options.AddAdditionalCapability("app", @"C:\Program Files (x86)\Windows Media Player\wmplayer.exe");

        string localVideoPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "test_video.mp4");
        string safePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos),
            "test_video.mp4");

        if (File.Exists(localVideoPath))
        {
            File.Copy(localVideoPath, safePath, true);
        }


        options.AddAdditionalCapability("appArguments", $"\"{safePath}\"");

        driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        player = new PlayerHelper(this);
    }

    public static AppManager GetInstance()
    {
        if (instance == null)
        {
            instance = new AppManager();
        }

        return instance;
    }

    public WindowsDriver<WindowsElement> Driver
    {
        get { return driver; }
    }

    public PlayerHelper Player
    {
        get { return player; }
    }

    public void Stop()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
            instance = null;
        }
    }
}