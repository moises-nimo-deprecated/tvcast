using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TvCast.Entity.Entities;
using TvCast.Entity.Repositories;

namespace TvCast.Tests.Repositories
{
    [TestFixture]
    public class ShowsRepositoryTests
    {
        private readonly Mock<IShowsRepository> _showsMock = new Mock<IShowsRepository>();

        [SetUp]
        public void SetUp()
        {
            _showsMock.Setup(s => s.GetAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new List<Show>());
        }

        [Test]
        public async Task GetAsyncTest()
        {
            var result = await _showsMock.Object.GetAsync(1, 20);
            Assert.Zero(result.Count());
        }
    }
}