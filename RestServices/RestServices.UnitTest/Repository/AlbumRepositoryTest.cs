using System;
using RestServices.MockData.Repositories;
using System.Threading.Tasks;
using RestServices.Domain.Entities;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace Chinook.UnitTest.Repository
{
    public class CountryRepositoryTest
    {
        private readonly CountryRepository _repo;

        public CountryRepositoryTest()
        {
            _repo = new CountryRepository();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task CountryGetAllAsync()
        {
            // Arrange

            // Act
            var countries = await _repo.GetAllAsync();

            // Assert
            Assert.Single(countries);
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task AlbumGetOneAsync()
        {
            // Arrange
            var id = 1;

            // Act
            var country = await _repo.GetByIdAsync(id);

            // Assert
            Assert.Equal(id, country.Id);
        }

        [AssertTraffic(AllocatedSizeInBytes = 1000, Types = new[] {typeof(Country)})]
        [Fact]
        public async Task DotMemoryUnitTest()
        {
            var repo = new CountryRepository();

            await repo.GetAllAsync();

            dotMemory.Check(memory =>
                Assert.Equal(1, memory.GetObjects(where => where.Type.Is<Country>()).ObjectsCount));

            GC.KeepAlive(repo); // prevent objects from GC if this is implied by test logic
        }
    }
}