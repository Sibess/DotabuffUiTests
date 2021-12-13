using DotabuffUiTests.PageObjects.Home.PlayersPage;
using OpenQA.Selenium;

namespace DotabuffUiTests.PageObjects.Home
{
    public class Home
    {
        protected IWebDriver _driver;
        protected IWebElement listContainer;
        public Home(IWebDriver driver)
        {
            _driver = driver;
        }

        public Players Players => new Players(_driver);

        private BaseElement SearchField => new BaseElement(By.XPath("(//input[@id='q'])[2]"), "Search Field", _driver);

        public void SearchUser(string text)
        {
            SearchField.SendKeys(text);
        }

        public bool IsChenMostPlayedHero(string hero)
        {
            return new BaseElement(By.XPath($"//section[2]//a[normalize-space()='{hero}']"), $"'{hero}' most played hero", _driver).IsDisplayed(5000);
        }
    }
}
