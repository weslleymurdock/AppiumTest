
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace AppiumCSharp
{
    public class MobileTests
    {
        private RemoteWebDriver driver;
        private OpenQA.Selenium.Appium.AppiumOptions options;
        [SetUp]
        public void Setup()
        {
            Options('a');
            var driverUri = new System.Uri("http://127.0.0.1:4727/wd/hub");
            StartSession(driverUri,'w');
        }
        private void StartSession(System.Uri driverUri, char v = 'a')
        {
            if (v == 'a')
                driver = new AndroidDriver<AndroidElement>(driverUri, options);
            else if (v == 'i')
                driver = new IOSDriver<IOSElement>(driverUri, options);
            else if (v == 'w')
                driver = new WindowsDriver<WindowsElement>(driverUri, options);
            driver.Manage().Timeouts().ImplicitWait = new System.TimeSpan(420000);
        }

        private void Options(char v = 'a')
        {
            options = new OpenQA.Selenium.Appium.AppiumOptions();

            if (v == 'a')
            {
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "11");
                options.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UIAutomator2");
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "foo");
                options.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            }
            else if (v == 'i')
            {
                options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
                options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "14.3");
                options.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
                options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone 12 Pro Max");
                options.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Safari");
            }
            else if (v == 'w')
            {
                options.AddAdditionalCapability("app", "\\Windows\\System32\\cmd.exe");
                options.AddAdditionalCapability("deviceName", "WindowsPC");
            }
        }

        [TearDown()]
        public void AfterAll()
        {
            driver?.Quit();
        }

        [Test()]
        public void TestNavigation()
        {
            driver.Navigate().GoToUrl("https://github.com/weslleyluiz/");
            System.Threading.Thread.Sleep(7000);
            var pageCode = driver.PageSource;

            Assert.Contains("<title>weslleyluiz", pageCode.Split(' '));
        }
        [Test()]
        public void TestFingerPrint()
        {
            if ((driver as AndroidDriver<AndroidElement>) == null)
                return;
            System.Diagnostics.Debug.WriteLine("fingerprint test");
            ((AndroidDriver<AndroidElement>)driver).FingerPrint(1);
            System.Threading.Thread.Sleep(400);
            System.Diagnostics.Debug.WriteLine("fingerprint test");
            ((AndroidDriver<AndroidElement>)driver).FingerPrint(1);
            ((AndroidDriver<AndroidElement>)driver).FingerPrint(1);
            System.Threading.Thread.Sleep(400);
            System.Diagnostics.Debug.WriteLine("end fingerprint test");
        }

        [Test()]
        public void PrintAppKeys()
        {
            System.Diagnostics.Debug.WriteLine("app keys");
            var keys = ((AndroidDriver<AndroidElement>)driver).GetAppStringDictionary();
            System.Threading.Thread.Sleep(400);
            foreach (var key in keys)
            {
                System.Diagnostics.Debug.WriteLine(key.Key + " => " + key.Value);
            }
        }

        [Test()]
        public void AssertKeysContainsKey()
        {
            //var isIos = driver as IOSDriver<IOSElement> is not null; /// c# 9 rules 
            var isIos = (driver as IOSDriver<IOSElement>) != null && (driver as AndroidDriver<AndroidElement>) == null;
            if (isIos)
            {
                var iosDriver = (IOSDriver<IOSElement>)driver;
                var b = iosDriver.PullFolder("/Users/weslleyluiz/Library/Developer/CoreSimulator/Devices/AC721224-0B13-42A2-9BB8-5907E0DD8C2C/data");
                for (int i = 0; i < b.Length; i++)
                {
                    System.Diagnostics.Debug.WriteLine(b[i].ToString());
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("os keys");
                var keys = ((AndroidDriver<AndroidElement>)driver).Settings.Keys;
                foreach (var key in keys)
                {
                    System.Diagnostics.Debug.Write("\n" + key + " => ");
                    System.Diagnostics.Debug.WriteLine(((AndroidDriver<AndroidElement>)driver)?.Settings[key].ToString());
                }
                Assert.Contains("trackScrollEvents", keys);
                Assert.Contains("shutdownOnPowerDisconnect", keys);
                Assert.Contains("normalizeTagNames", keys);
                Assert.Contains("waitForSelectorTimeout", keys);
                Assert.Contains("waitForIdleTimeout", keys);
                Assert.Contains("shouldUseCompactResponses", keys);
            }
        }
    }
}