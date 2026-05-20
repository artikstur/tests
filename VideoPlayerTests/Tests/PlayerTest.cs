using VideoPlayerTests.Base;

namespace VideoPlayerTests.Tests;

[TestFixture]
public class PlayerTest : TestBase
{
    [Test]
    public void TestPlayPauseAndStopMedia()
    {
        Thread.Sleep(1500);

        app.Player.ClickPause();

        app.Player.ClickPlay();

        app.Player.ClickStop();

        var playButton = app.Driver.FindElementByName("Воспроизвести");
        Assert.That(playButton, Is.Not.Null);

        Thread.Sleep(2000);
    }
}