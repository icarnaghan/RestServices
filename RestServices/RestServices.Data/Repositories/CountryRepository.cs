using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestServices.Domain.Repositories;
using RestServices.Domain.Entities;

namespace RestServices.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly RestServicesContext _context;

        public CountryRepository(RestServicesContext context)
        {
            _context = context;
        }

        private async Task<bool> CountryExists(int id, CancellationToken ct = default(CancellationToken))
        {
            return await GetByIdAsync(id, ct) != null;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<Country>> GetAllAsync(CancellationToken ct = default(CancellationToken))
        {
            return await _context.Country.ToListAsync(ct);
        }

        public async Task<Country> GetByIdAsync(int id, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Country.FindAsync(id);
        }

        public async Task<List<Country>> GetByAlpha2IdAsync(string alpha2, CancellationToken ct = default(CancellationToken))
        {
            return await _context.Country.Where(a => a.Alpha2 == alpha2).ToListAsync(ct);
        }
    }
}