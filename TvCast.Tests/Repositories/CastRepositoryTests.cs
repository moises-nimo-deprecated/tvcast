using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TvCast.Entity.Entities;
using TvCast.Entity.Repositories;

namespace TvCast.Tests.Repositories
{
    [TestFixture]
    public class CastRepositoryTests
    {
        private readonly Mock<ICastRepository> _repository = new Mock<ICastRepository>();
        
        [SetUp]
        public void SetUp()
        {
            _repository.Setup(s => s.SaveRangeAsync(It.IsAny<IEnumerable<Casting>>())).ReturnsAsync(0);
            _repository.Setup(s => s.FindLastInsertedShowAsync()).ReturnsAsync(20L);
        }

        [Test]
        public async Task SaveRangeAsyncTest()
        {
            var result = await _repository.Object.SaveRangeAsync(null);
            Assert.Equals(result, 0);
        }

        [Test]
        public async Task FindLastInsertedShowAsyncTest()
        {
            var result = await _repository.Object.FindLastInsertedShowAsync();
            Assert.Equals(result, 20L);
        }
    }
}