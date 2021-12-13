using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DotabuffUiTests.Tests.HomeTests
{
    [TestFixture]
    [Parallelizable]
    public class PlayersTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldDisplayValidPlayerRank()
        {
            Home.SearchUser("Total_wignat");
            Home.Players.HoverOverRankIcon();  
            Assert.IsTrue(Home.Players.IsValidRankDisplayed(), "Rank wasn't valid");
        }

        [Category("Smoke")]
        [Test]
        public void ShouldNotContainChenInMostPlayedHeroesList()
        {
            Home.SearchUser("Total_wignat");
            Assert.IsFalse(Home.Players.IsChenMostPlayedHero("Chen"), "'Chen' is in most played heroes list");
        }
    }
}
