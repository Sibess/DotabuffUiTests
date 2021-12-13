using OpenQA.Selenium;

namespace DotabuffUiTests.PageObjects.Home.PlayersPage.ItemsPage.GlimmerCapePage
{
   public class GlimmerCape : Items
    {
        public GlimmerCape(IWebDriver driver) : base(driver)
        {
        }

        public bool IsMostUsedByHero(string hero)
        {
            return new BaseElement(By.XPath($"//a[normalize-space()='{hero}']"), $"'{hero}' link", _driver).IsDisplayed(5000);
        }
    }
}
