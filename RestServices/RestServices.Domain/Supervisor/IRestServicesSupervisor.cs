using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestServices.Domain.ViewModels;

namespace RestServices.Domain.Supervisor
{
    public interface IRestServicesSupervisor
    {
        Task<List<CountryViewModel>> GetAllCountryAsync(CancellationToken ct = default(CancellationToken));
        Task<CountryViewModel> GetCountryByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<CountryViewModel>> GetCountryByAlpha2Async(string id, CancellationToken ct = default(CancellationToken));
    }
}