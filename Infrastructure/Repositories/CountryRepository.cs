using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly YourDbContext _context;

        public CountryRepository(YourDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
            => await _context.Countries.AsNoTracking().ToListAsync();

        public async Task<Country> GetByIdAsync(int id)
            => await _context.Countries.FindAsync(id);

        public async Task AddAsync(Country country)
            => await _context.Countries.AddAsync(country);

        public void Update(Country country)
            => _context.Countries.Update(country);

        public void Remove(Country country)
            => _context.Countries.Remove(country);

        public async Task<bool> ExistsAsync(int id)
            => await _context.Countries.AnyAsync(c => c.Id == id);
    }

}
