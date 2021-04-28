using Games.Domain.Models;
using Games.Infra.Db;
using Games.Infra.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace Games.Infra.Test.Repository
{
    public class GameResultRepositoryTest
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
        public void SaveOrUpdate_When_New_Result_Success()
        {
            ClearDb();
            var repository = new GameResultRepository(MockContext);

            var fakeGameResult = new GameResult { GameId = 1, PlayerId = 1, Win = 1 };
            Assert.DoesNotThrowAsync(() => repository.SaveOrUpdate(fakeGameResult));
            var fakeDbResult = MockContext.GameResults.FirstOrDefault(x => x.PlayerId == 1 && x.GameId == 1);
            Assert.NotNull(fakeDbResult);
        }

        [Test]
        public void SaveOrUpdate_When_Result_Success()
        {
            ClearDb();
            MockContext.GameResults.Add(new GameResult { GameId = 1, PlayerId = 1, Win = 1 });
            MockContext.SaveChanges();

            var fakeGameResult = new GameResult { GameId = 1, PlayerId = 1, Win = 1 };

            var repository = new GameResultRepository(MockContext);
            Assert.DoesNotThrowAsync(() => repository.SaveOrUpdate(fakeGameResult));

            var fakeDbResult = MockContext.GameResults.FirstOrDefault(x => x.PlayerId == 1 && x.GameId == 1);
            Assert.NotNull(fakeDbResult);
            Assert.AreEqual(2, fakeDbResult.Win);
        }
    }
}
