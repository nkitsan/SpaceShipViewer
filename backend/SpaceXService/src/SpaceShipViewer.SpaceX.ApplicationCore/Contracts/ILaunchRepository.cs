using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Contracts
{
    public interface ILaunchRepository
    {
        Task<Launch?> GetAsync(string id, CancellationToken cancellationToken = default);

        Task<Launch?> GetLatest(CancellationToken cancellationToken = default);

        Task<IEnumerable<Launch>> FilterAsync(string? name = null, DateTime? launchedFrom = null, CancellationToken cancellationToken = default);

        Task Add(Launch launch, CancellationToken cancellationToken = default);

        Task AddRange(IEnumerable<Launch> launches, CancellationToken cancellationToken = default);
    }
}
