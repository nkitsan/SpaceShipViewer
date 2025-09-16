using Microsoft.EntityFrameworkCore;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.Infrastructure.Repositories
{
    public class LaunchRepository : ILaunchRepository
    {

        private readonly SpaceXDbContext _spaceXDbContext;

        public LaunchRepository(SpaceXDbContext spaceXDbContext)
        {
            _spaceXDbContext = spaceXDbContext;
        }

        public async Task Add(Launch launch)
        {
            await _spaceXDbContext.AddAsync(launch);

            _spaceXDbContext.SaveChanges();
        }

        public async Task AddRange(IEnumerable<Launch> launches)
        {
            await _spaceXDbContext.AddRangeAsync(launches);

            _spaceXDbContext.SaveChanges();
        }

        public async Task<IEnumerable<Launch>> FilterAsync(string? nameFilter = null, DateTime? launchedFromFilter = null)
        {
            var query = _spaceXDbContext.Launches.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                query = query.Where(l => l.Name.ToLower().Contains(nameFilter.ToLower()));
            }

            if (launchedFromFilter.HasValue) 
            {
                query = query.Where(l => l.DateUTC > launchedFromFilter.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<Launch?> GetAsync(string id)
        {
            return await _spaceXDbContext.Launches
                .FirstOrDefaultAsync(launch => launch.Id == id);
        }

        public async Task<Launch?> GetLatest()
        {
            return await _spaceXDbContext.Launches
                .OrderByDescending(launch => launch.DateUTC)
                .FirstOrDefaultAsync();
        }
    }
}
