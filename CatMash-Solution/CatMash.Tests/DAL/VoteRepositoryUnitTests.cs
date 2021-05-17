using CatMash.DataAccess;
using CatMash.DataAccess.Entities;
using CatMash.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CatMash.Tests.DAL
{
    [TestClass]
    public class VoteRepositoryUnitTests
    {
        [TestMethod]
        public void Should_AddVote_Return_Zero_When_Vote_Is_Null()
        {
            var voteRepository = new VoteRepository(null,null);

            var updateCount = voteRepository.InsertVote(null);

            Assert.AreEqual(0, updateCount);
        }
      

        [TestMethod]
        public void Should_AddVote_Add_Vote_When_Is_Correct()
        {
            var options = new DbContextOptionsBuilder<CatMashDbContext>()
                .UseInMemoryDatabase(databaseName: "Should_AddVote_Add_Vote_When_Is_Correct")
                .Options;

            using (var context = new CatMashDbContext(options))
            {
                context.TCatPicture.Add(new TCatPicture { Id = 1, Url = "test.com/test1" });
                context.TCatPicture.Add(new TCatPicture { Id = 2, Url = "test.com/test2" });
                context.TCatPicture.Add(new TCatPicture { Id = 3, Url = "test.com/test3" });
                context.TCatPicture.Add(new TCatPicture { Id = 4, Url = "test.com/test4" });
                context.TCatPicture.Add(new TCatPicture { Id = 5, Url = "test.com/test5" });
                context.TCatPicture.Add(new TCatPicture { Id = 6, Url = "test.com/test6" });
                var updateCount = context.SaveChanges();

                Assert.AreEqual(6, updateCount);
            }

            using (var context = new CatMashDbContext(options))
            {
                var mock = new Mock<ILogger<VoteRepository>>();
                ILogger<VoteRepository> logger = mock.Object;

                logger = Mock.Of<ILogger<VoteRepository>>();

                var catRepository = new VoteRepository(context, logger);

                var vote = new TVote { CatId = 1};

                var updateCount = catRepository.InsertVote(vote);
                Assert.AreEqual(1, updateCount);
            }
        }
    }
}
