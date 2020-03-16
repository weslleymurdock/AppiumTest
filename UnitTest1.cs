using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.IO;

namespace AppiumCSharp
{
    public class Tests
    { 
        private AndroidDriver<AndroidElement> driver;
        [SetUp]
        public void Setup()
        { 
            OpenQA.Selenium.DriverOptions driverOptions = new OpenQA.Selenium.Appium.AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus_5X_API_29_x86");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 12000); 
            driverOptions.AddAdditionalCapability("uiautomator2ServerInstallTimeout", 80000);
            driverOptions.AddAdditionalCapability("uiautomator2ServerLaunchTimeout", 80000); 
            driverOptions.AddAdditionalCapability("appActivity", "com.google.android.apps.youtube.app.WatchWhileActivity"); 
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\weslley\Desktop\YouTube.apk"); 
            driverOptions.AddAdditionalCapability("noSign", true);

            driver = new AndroidDriver<AndroidElement>(new System.Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);
            driver.Manage().Timeouts().ImplicitWait = (new System.TimeSpan(0, 0, 0, 10)); 
        }

        [TearDown()]
        public void AfterAll()
        {
            driver?.Quit();
        }

        [Test()]
        public void TestShouldSendKetsToSearchBoxThenCheckTheValue()
        {
            var screenshot = driver.GetScreenshot();
            var file = $"screenshot{System.DateTime.Now.Ticks}.png";
            var f = File.Create(file);
            f.Close();
            screenshot.SaveAsFile(file,ScreenshotImageFormat.Png); 
            Assert.AreEqual("Home",
                driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Home\"]/android.widget.TextView")).Text);
        }
    }
}