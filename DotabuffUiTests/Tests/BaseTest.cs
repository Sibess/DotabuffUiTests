using DotabuffUiTests.Common;
using DotabuffUiTests.Common.DriverInitialization;
using DotabuffUiTests.Common.Infrastructure;
using DotabuffUiTests.PageObjects.Home;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace DotabuffUiTests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver driver { get; set; }
        public static IConfiguration TestConfiguration { get; } = new ConfigurationBuilder().AddJsonFile("testrunsettings.json").Build();
        protected Home Home { get; set; }


        [SetUp]
        public void StartDriver()
        {
            DriverInitialization driverInitialization = new DriverInitialization();
            driver = driverInitialization.InitializeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(GlobalRunSettings.StartUrl);
            Home = new Home(driver);

        }

        [OneTimeSetUp]
        public static void InitializeAssembly()
        {
            InitializeRunSettings();
        }

        private static void InitializeRunSettings()
        {
            GlobalRunSettings.BrowserName = (BrowserName)Enum.Parse(typeof(BrowserName), TestConfiguration["Settings:BrowserName"]);
            GlobalRunSettings.IsRemoteRun = bool.Parse(TestConfiguration["Settings:IsRemoteRun"]);
            GlobalRunSettings.RemoteDriverUrl = TestConfiguration["Settings:RemoteDriverUrl"];     
            GlobalRunSettings.StartUrl = TestConfiguration["Settings:StartUrl"];
            GlobalRunSettings.TimeoutSeconds = int.Parse(TestConfiguration["Settings:TimeoutSeconds"]);




        }

        [TearDown]
        public void QuitDriver()
        {
            driver?.Quit();
        }
    }
}