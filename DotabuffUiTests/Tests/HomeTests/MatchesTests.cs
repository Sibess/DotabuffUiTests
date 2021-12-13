
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;

namespace DotabuffUiTests.Tests.HomeTests
{
    [TestFixture]
    [Parallelizable]
    public class MatchesTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldFilterMatchesByRole()
        {
            Home.SearchUser("Total_wignat");
            Home.Players.ClickHeaderTab("Matches");
            Home.Players.Matches.FilterPlayerByRole("Support");
            Home.Players.Matches.FilterPlayerByLaneRole("Off Lane");
            Assert.IsTrue(Home.Players.Matches.IsValidIconDisplayed("support"), "Support icon is not displayed");
            Assert.IsTrue(Home.Players.Matches.IsValidIconDisplayed("offlane"), "Offlane icon is not displayed");
        }
    }
    
}
