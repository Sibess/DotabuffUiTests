using OpenQA.Selenium;
using DotabuffUiTests.PageObjects.Home.PlayersPage.ItemsPage.GlimmerCapePage;

namespace DotabuffUiTests.PageObjects.Home.PlayersPage.ItemsPage
{
    public class Items : Players
    {
        public Items(IWebDriver driver) : base(driver)
        {
        }
        public GlimmerCape GlimmerCape => new GlimmerCape(_driver);

        public void ClickItemLink(string itemName)
        {
            new BaseElement(By.XPath($"//a[normalize-space()='{itemName}']"), $"'{itemName}' link", _driver).Click();
        }
    }
}
