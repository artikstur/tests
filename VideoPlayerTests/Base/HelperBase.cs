using OpenQA.Selenium.Appium.Windows;

namespace VideoPlayerTests.Base;

public class HelperBase
{
    protected AppManager manager;
    protected WindowsDriver<WindowsElement> driver;

    public HelperBase(AppManager manager)
    {
        this.manager = manager;
        this.driver = manager.Driver;
    }
}