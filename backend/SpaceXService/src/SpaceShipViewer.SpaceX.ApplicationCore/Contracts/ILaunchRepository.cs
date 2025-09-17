using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Contracts
{
    public interface ILaunchRepository
    {
        Task<Launch?> GetAsync(string id, CancellationToken cancellationToken = default);

        Task<IEnumerable<Launch>> FilterAsync(
            string? name = null,
            DateTime? launchedFrom = null,
            bool orderByDesc = false,
            CancellationToken cancellationToken = default);

        Task AddOrUpdateRangeAsync(IEnumerable<Launch> launches, CancellationToken cancellationToken = default);
    }
}
