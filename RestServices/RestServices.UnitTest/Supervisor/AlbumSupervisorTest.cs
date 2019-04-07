using System.Threading.Tasks;
using RestServices.Domain.Supervisor;
using JetBrains.dotMemoryUnit;
using Xunit;

namespace RestServices.UnitTest.Supervisor
{
    public class CountrySupervisorTest
    {
        private readonly RestServicesSupervisor _super;

        public CountrySupervisorTest(RestServicesSupervisor super)
        {
            _super = new RestServicesSupervisor();
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task CountryGetAllAsync()
        {
            // Arrange

            // Act
            var countries = await _super.GetAllCountryAsync();

            // Assert
            Assert.Single(countries);
        }

        [DotMemoryUnit(FailIfRunWithoutSupport = false)]
        [Fact]
        public async Task CountryGetOneAsync()
        {
            // Arrange
            var id = 1;

            // Act
            var country = await _super.GetCountryByIdAsync(id);

            // Assert
            Assert.Equal(id, country.Id);
        }
    }
}