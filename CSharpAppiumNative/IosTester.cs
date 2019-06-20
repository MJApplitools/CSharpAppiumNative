using System;
using Applitools.Appium;
using OpenQA.Selenium.Remote;
namespace CSharpAppiumNative
{
    public class IosTester
    {
        public static void IosTest()
        {
            Eyes eyes = new Eyes();
            eyes.ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY");

            DesiredCapabilities dc = new DesiredCapabilities();
            dc.SetCapability("platformName", "iOS");
            dc.SetCapability("automationName", "XCUITest");
            dc.SetCapability("app", "/Users/mattjasaitis/Downloads/test-apps/Applitools XCUI Demo.zip");
            dc.SetCapability("deviceName", "iPhone XR");
            dc.SetCapability("platformVersion", "12.1");

            //Either of the drivers below work, so this is not an issue
            //IOSDriver<IWebElement> driver = new IOSDriver<IWebElement>(new Uri("http://localhost:4723/wd/hub"), dc);
            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4723/wd/hub"), dc);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            try
            {
                eyes.Open(driver, "iOS test application", "test");

                // Visual validation point #1
                eyes.CheckWindow("Initial view");

                // End visual UI testing. Validate visual correctness.
                eyes.Close();
            }
            finally
            {
                eyes.AbortIfNotClosed();
                driver.Quit();
            }
        }
}
