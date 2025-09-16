using EFCore.BulkExtensions;
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

        public async Task AddOrUpdateRangeAsync(IEnumerable<Launch> launches, CancellationToken cancellationToken = default)
        {
            await _spaceXDbContext.BulkInsertOrUpdateAsync(launches);

            await _spaceXDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<Launch>> FilterAsync(
            string? nameFilter = null,
            DateTime? launchedFromFilter = null,
            CancellationToken cancellationToken = default)
        {
            var query = _spaceXDbContext.Launches.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(nameFilter))
            {
                query = query.Where(l => l.Name.ToLower().Contains(nameFilter.ToLower()));
            }

            if (launchedFromFilter.HasValue) 
            {
                query = query.Where(l => l.DateUTC > launchedFromFilter.Value);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public async Task<Launch?> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _spaceXDbContext.Launches
                .AsNoTracking()
                .FirstOrDefaultAsync(launch => launch.Id == id, cancellationToken);
        }
    }
}
