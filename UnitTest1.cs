using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.IO;

namespace AppiumCSharp
{
    public class Tests
    {
        private AndroidDriver<AndroidElement> driver;
        OpenQA.Selenium.DriverOptions driverOptions;
        [SetUp]
        public void Setup()
        {
            driverOptions = new OpenQA.Selenium.Appium.AppiumOptions();
            //YoutubeOptions();
            ChromeOptions();
            driver = new AndroidDriver<AndroidElement>(new System.Uri("http://127.0.0.1:4723/wd/hub"), driverOptions);
            driver.Manage().Timeouts().ImplicitWait = (new System.TimeSpan(0, 0, 0, 10));
        }

        private void ChromeOptions()
        {
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "nexus_5_q_10_0_-_api_29");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 12000);
            driverOptions.AddAdditionalCapability("uiautomator2ServerInstallTimeout", 80000);
            driverOptions.AddAdditionalCapability("uiautomator2ServerLaunchTimeout", 80000);
            driverOptions.AddAdditionalCapability("adbExecTimeout", 80000);
            driverOptions.AddAdditionalCapability("appActivity", "com.google.android.apps.chrome.Main");
            driverOptions.AddAdditionalCapability("appWaitActivity", "org.chromium.chrome.browser.firstrun.FirstRunActivity");
            //driverOptions.AddAdditionalCapability(MobileCapabilityType.BrowserName, MobileBrowserType.Chrome);
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\weslley\Desktop\Chrome.apk");
            driverOptions.AddAdditionalCapability("noSign", true);
        }

        private void YoutubeOptions()
        {
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "nexus_5_q_10_0_-_api_29");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 12000);
            driverOptions.AddAdditionalCapability("uiautomator2ServerInstallTimeout", 80000);
            driverOptions.AddAdditionalCapability("uiautomator2ServerLaunchTimeout", 80000);
            driverOptions.AddAdditionalCapability("adbExecTimeout", 80000);
            driverOptions.AddAdditionalCapability("appActivity", "com.google.android.apps.youtube.app.WatchWhileActivity");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.App, @"C:\Users\weslley\Desktop\YouTube.apk");
            driverOptions.AddAdditionalCapability("noSign", true);
        }

        [TearDown()]
        public void AfterAll()
        {
            driver?.Quit();
        }

        //[Test()]
        //public void TestButtonHomeExistsText()
        //{
        //    var fileName = $"screenshot{System.DateTime.Now.Ticks}.png";
        //    var file = File.Create(fileName);
        //    file.Close();
        //    driver.GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);
        //    Assert.AreEqual("Home",
        //        driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Home\"]/android.widget.TextView")).Text);
        //}
        [Test()]
        public void TestChromeNavigation()
        {
            var page = "Tesouro Direto";

            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.support.v4.view.ViewPager/android.widget.FrameLayout/android.widget.Button")).Click();
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.support.v4.view.ViewPager/android.widget.FrameLayout/android.widget.Button")).Click();
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.support.v4.view.ViewPager/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.Button[1]")).Click();
            driver.FindElement(By.XPath("//android.support.v7.widget.RecyclerView[@content-desc=\"New tab\"]/android.widget.LinearLayout[1]/android.widget.LinearLayout/android.widget.EditText")).SendKeys("www.tesourodireto.com.br");
            System.Threading.Thread.Sleep(123123);
            driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.EditText")).SendKeys("www.google.com");


            //Assert.AreEqual(page, driver.FindElement(By.XPath, "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.EditText"))
        }
    }
}
