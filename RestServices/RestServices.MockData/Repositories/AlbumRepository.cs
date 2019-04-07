using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using RestServices.Domain.Repositories;
using RestServices.Domain.Entities;

namespace RestServices.MockData.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public void Dispose()
        {
        }

        public async Task<List<Country>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            IList<Country> list = new List<Country>();

            var album = new Country
            {
                Id = 1,
                Name = "Test country",
                Alpha2 = "ds394",
                Alpha3 = "jskdf",
                Iso = "34809234"
            };
            list.Add(album);

            return list.ToList();
        }

        public async Task<Country> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var country = new Country
            {
                Id = 1,
                Name = "Test country",
                Alpha2 = "ds394",
                Alpha3 = "jskdf",
                Iso = "34809234"
            };
            return country;
        }

        public async Task<List<Country>> GetByAlpha2IdAsync(string alpha2, CancellationToken ct = default(CancellationToken))
        {
            IList<Country> list = new List<Country>();
            var newisd = new Country
            {
                Id = 1,
                Name = "Test country",
                Alpha2 = "ds394",
                Alpha3 = "jskdf",
                Iso = "34809234"
            };
            list.Add(newisd);
            return list.ToList();
        }
    }
}