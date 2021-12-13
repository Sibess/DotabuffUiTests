using OpenQA.Selenium;

namespace DotabuffUiTests.PageObjects.Home.PlayersPage.MatchesPage
{
    public class Matches : Players
    {
        public Matches(IWebDriver driver) : base(driver)
        {

        }

        private BaseElement PlayerRoleDropdown => new BaseElement(By.Id("role_type"), "Player Role Dropdown", _driver);

        private BaseElement PlayerLaneRoleDropdown => new BaseElement(By.Id("lane_role"), "Player Lane Role Dropdown", _driver);


        public void FilterPlayerByRole(string role)
        {
            PlayerRoleDropdown.SelectDropdownOptionByText(role);
        }
        public void FilterPlayerByLaneRole(string role)
        {
            PlayerLaneRoleDropdown.SelectDropdownOptionByText(role);
        }

        public bool IsValidIconDisplayed(string iconName)
        {
            return new BaseElement(By.XPath($"//td[@class='cell-centered r-none-mobile']//i[contains(@class,'{iconName}')] "), $"'{iconName}' icon", _driver).IsDisplayed(5000);
        }

    }
}
