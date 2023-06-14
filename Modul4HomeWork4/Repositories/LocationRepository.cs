using Microsoft.EntityFrameworkCore;
using Modul4HomeWork4.Data;
using Modul4HomeWork4.Data.Entities;
using Modul4HomeWork4.Repositories.Abstractions;
using Modul4HomeWork4.Services.Abstractions;

namespace Modul4HomeWork4.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _context = dbContextWrapper.DbContext;
        }

        public async Task<int> AddLocationAsync(string name)
        {
            var location = new LocationEntity()
            {
                Location_Name = name
            };

            var result = await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<LocationEntity?> GetLocationAsync(int id)
        {
            return await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task UpdateLocationAsync(int id, string name)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l =>l.Id == id);

            if (location != null) 
            {
                location.Location_Name = name;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FirstOrDefaultAsync(l => l.Id == id);

            if (location != null)
            {
                _context.Locations.Remove(location);
                await _context.SaveChangesAsync();
            }
        }
    }
}
