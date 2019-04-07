using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestServices.Domain.ViewModels;
using RestServices.Domain.Converters;
using RestServices.Domain.Entities;

namespace RestServices.Domain.Supervisor
{
    public partial class RestServicesSupervisor
    {
        public async Task<List<CountryViewModel>> GetAllCountryAsync(CancellationToken ct = default(CancellationToken))
        {
            var countries = CountryCoverter.ConvertList(await _countryRepository.GetAllAsync(ct));
            return countries;
        }

        public async Task<CountryViewModel> GetCountryByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            var countryViewModel = CountryCoverter.Convert(await _countryRepository.GetByIdAsync(id, ct));
            countryViewModel.Name = _countryRepository.GetByIdAsync(countryViewModel.Id, ct).Result.Name;
            return countryViewModel;
        }

        public async Task<List<CountryViewModel>> GetCountryByAlpha2Async(string alpha2,
            CancellationToken ct = default(CancellationToken))
        {
            var albums = CountryCoverter.ConvertList(await _countryRepository.GetByAlpha2IdAsync(alpha2, ct));
            return albums;
        }
    }
}