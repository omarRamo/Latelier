using CatMash.DataAccess;
using CatMash.DataAccess.Entities;
using CatMash.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatMash.Tests.DAL
{
    [TestClass]
    public class CatPictureRepositoryUnitTests
    {
        [TestMethod]
        public void Should_GetCatPictureById_return_Null_When_CatPicture_IsNonExisting()
        {
            var options = new DbContextOptionsBuilder<CatMashDbContext>()
                .UseInMemoryDatabase(databaseName: "Should_GetCatById_return_Null_When_Cat_IsNoutFound")
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
                var catRepository = new CatPictureRepository(context);
                var cat = catRepository.GetCatPictureById(10);

                Assert.IsNull(cat);
            }
        }

        [TestMethod]
        public void Should_GetCatPictureById_return_CatPicture_When_CatPicture_IsExist()
        {
            var options = new DbContextOptionsBuilder<CatMashDbContext>()
                .UseInMemoryDatabase(databaseName: "Should_GetCatPictureById_return_CatPicture_When_CatPicture_IsExist")
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
                var catRepository = new CatPictureRepository(context);
                var cat = catRepository.GetCatPictureById(1);

                Assert.IsNotNull(cat);
                Assert.AreEqual("test.com/test1", cat.Url);
            }
        }
    }
}
