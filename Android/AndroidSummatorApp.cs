using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using System;

namespace Android_Summator_App
{
    public class Tests
    {
        private AppiumLocalService appiumLocalService;
        private AndroidDriver<AndroidElement> driver;

        [OneTimeSetUp]
        public void SetupRemoteServer()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.App,
                @"C:\Adi\Automation docs\Day7\com.example.androidappsummator.apk");
            appiumOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            // appiumOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Nexus5X_API_30");

            //Start appium driver
            driver = new AndroidDriver<AndroidElement>(
                new Uri("http://[::1]:4723/wd/hub"), appiumOptions);
        }

        [Test]
        public void Test_Android_Summator_ValidData()
        {
            var textBoxFirstNum = driver.FindElementById("com.example.androidappsummator:id/editText1");
            textBoxFirstNum.Clear();
            textBoxFirstNum.SendKeys("5");
            var textBoxSecondNum = driver.FindElementById("com.example.androidappsummator:id/editText2");
            textBoxSecondNum.Clear();
            textBoxSecondNum.SendKeys("10");
            var buttonCalc = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            buttonCalc.Click();
            var textBoxSum = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            Assert.AreEqual("15", textBoxSum.Text);
        }

        [Test]
        public void Test_Android_Summator_InvalidData()
        {
            var textBoxFirstNum = driver.FindElementById("com.example.androidappsummator:id/editText1");
            textBoxFirstNum.Clear();
            textBoxFirstNum.SendKeys("test");
            var textBoxSecondNum = driver.FindElementById("com.example.androidappsummator:id/editText2");
            textBoxSecondNum.Clear();
            textBoxSecondNum.SendKeys("10");
            var buttonCalc = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
            buttonCalc.Click();
            var textBoxSum = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            Assert.AreEqual("error", textBoxSum.Text);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}