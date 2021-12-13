using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace DotabuffUiTests.Common.DriverInitialization
{
    public class DriverInitialization
    {
        public IWebDriver InitializeDriver()
        {
            IWebDriver driver;

            switch (GlobalRunSettings.BrowserName)
            {
                case Infrastructure.BrowserName.Chrome:
                    var chromeOptions = new ChromeOptions
                    {
                        PageLoadStrategy = PageLoadStrategy.Normal,
                        AcceptInsecureCertificates = true,
                        UnhandledPromptBehavior = UnhandledPromptBehavior.Accept
                    };
                                        
                    chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    chromeOptions.SetLoggingPreference(LogType.Driver, LogLevel.All);
                    chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
                    chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
                    chromeOptions.AddArgument("no-sandbox");

                    //for selenoid
                    var runName = GetType().Assembly.GetName().Name;
                    var timestamp = $"{DateTime.Now:yyyyMMdd.HHmm}";
                    chromeOptions.AddAdditionalOption("name", runName);
                    chromeOptions.AddAdditionalOption("videoName", $"{runName}.{timestamp}.mp4");
                    chromeOptions.AddAdditionalOption("logName", $"{runName}.{timestamp}.log");
                    chromeOptions.AddAdditionalOption("enableVNC", true);
                    chromeOptions.AddAdditionalOption("enableVideo", true);
                    chromeOptions.AddAdditionalOption("enableLog", true);
                    chromeOptions.AddAdditionalOption("screenResolution", "1920x1080x24");
                    driver = GlobalRunSettings.IsRemoteRun ? new RemoteWebDriver(new Uri(GlobalRunSettings.RemoteDriverUrl), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(GlobalRunSettings.TimeoutSeconds)) :
    (IWebDriver?)new ChromeDriver(chromeOptions);

                    break;
                default:
                    throw new Exception($"{GlobalRunSettings.BrowserName} driver can not be initialized");
            }
            return driver;
        }
    }
}
