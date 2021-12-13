using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DotabuffUiTests.Tests.HomeTests
{
    [TestFixture]
    [Parallelizable]
    public class ItemsTests : BaseTest
    {
        [Category("Smoke")]
        [Test]
        public void ShouldntContainChenInMostPlayedHeroesList()
        {
            Home.SearchUser("Total_wignat");
            Home.Players.ClickHeaderTab("Items");
            Home.Players.Items.ClickItemLink("Glimmer Cape");
            Assert.IsTrue(Home.Players.Items.GlimmerCape.IsMostUsedByHero("Disruptor"));
        }
    }

}
