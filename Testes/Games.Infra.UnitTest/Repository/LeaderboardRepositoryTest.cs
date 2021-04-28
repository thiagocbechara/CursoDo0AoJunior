using Games.Domain.Models;
using Games.Infra.Db;
using Games.Infra.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Games.Infra.Test.Repository
{
    public class LeaderboardRepositoryTest
    {
        private ApplicationDbContext MockContext;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("FakeConnectionString")
                .Options;
            MockContext = new ApplicationDbContext(dbContextOptions);
        }

        private void ClearDb()
        {
            MockContext.GameResults.RemoveRange(MockContext.GameResults);
            MockContext.SaveChanges();
        }

        [Test]
        public void Top100_Returns_10_Results()
        {
            ClearDb();
            for(var i = 0; i < 10; i++)
            {
                MockContext.GameResults.Add(new GameResult { PlayerId = i + 1, GameId = 1, Win = i });
            }
            MockContext.SaveChanges();

            var repository = new LeaderboardRepository(MockContext);
            var leader = repository.GetTop100(1);

            Assert.AreEqual(10, leader.Count);
            var first = leader.FirstOrDefault();
            var last = leader.LastOrDefault();

            Assert.AreEqual(9, first.Balance);
            Assert.AreEqual(0, last.Balance);
        }
    }
}
