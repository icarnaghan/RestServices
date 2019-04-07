using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestServices.Domain.Entities;

namespace RestServices.Domain.Repositories
{
    public interface ICountryRepository : IDisposable
    {
        Task<List<Country>> GetAllAsync(CancellationToken ct = default(CancellationToken));
        Task<Country> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken));
        Task<List<Country>> GetByAlpha2IdAsync(string alpha2, CancellationToken ct = default(CancellationToken));
    }
}