using System.Threading;
using System.Threading.Tasks;
using RestServices.Domain.Repositories;
using RestServices.Domain.ViewModels;

namespace RestServices.Domain.Supervisor
{
    public partial class RestServicesSupervisor : IRestServicesSupervisor
    {
        private readonly ICountryRepository _countryRepository;

        public RestServicesSupervisor()
        {
        }

        public RestServicesSupervisor(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
    }
}