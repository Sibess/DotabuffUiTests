using DotabuffUiTests.PageObjects.Home.PlayersPage.ItemsPage;
using DotabuffUiTests.PageObjects.Home.PlayersPage.MatchesPage;
using OpenQA.Selenium;

namespace DotabuffUiTests.PageObjects.Home.PlayersPage
{
    public class Players : Home
    {
        public Players(IWebDriver driver) : base(driver)
        {
        }

        public Matches Matches => new Matches(_driver);

        public Items Items => new Items(_driver);

        private BaseElement RankIcon => new BaseElement(By.XPath("//img[@class='rank-tier-pip']"), "Rank Icon", _driver);

        private BaseElement RankTooltip => new BaseElement(By.Id("ui-tooltip-1-content"), "Rank Tooltip", _driver);

        public void ClickHeaderTab(string headerTab)
        {
            new BaseElement(By.XPath($"//nav[@class='header-nav-links header-nav-links-condensed']//a[contains(text(),'{headerTab}')]"), $"{headerTab} Button", _driver).Click();
        }

        public void HoverOverRankIcon()
        {
            RankIcon.HoverOver();
        }

        public bool IsValidRankDisplayed()
        {
            return RankTooltip.GetText().Contains("Rank: Guardian II");
        }
    }
}
