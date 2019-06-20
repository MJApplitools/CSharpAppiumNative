using System;
using Applitools.Appium;
using OpenQA.Selenium.Remote;
namespace CSharpAppiumNative
{
    public class AndroidTester
    {
        /*
         * DOES NOT WORK, NEED TO INTEGRATE WITH SAUCE LABS
         */

        public static void AndroidTest()
        {
            Eyes eyes = new Eyes();
            eyes.ApiKey = Environment.GetEnvironmentVariable("APPLITOOLS_API_KEY");

            DesiredCapabilities dc = new DesiredCapabilities();
            dc.SetCapability("platformName", "Android");
            dc.SetCapability("automationName", "UiAutomator2");
            dc.SetCapability("app", "/Users/mattjasaitis/Downloads/test-apps/app-debug.apk");
            dc.SetCapability("deviceName", "Pix3");
            dc.SetCapability("platformVersion", "10");

            RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://localhost:4723/wd/hub"), dc);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            try
            {
                eyes.Open(driver, "Android test app", "Native");
                eyes.CheckWindow("test");
                eyes.Close();
            }
            finally
            {
                eyes.AbortIfNotClosed();
                driver.Quit();
            }


        }
    }
}
