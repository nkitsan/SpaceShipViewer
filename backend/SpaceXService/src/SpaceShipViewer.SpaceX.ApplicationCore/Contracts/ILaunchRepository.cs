using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Contracts
{
    public interface ILaunchRepository
    {
        Task<Launch?> GetAsync(string id);

        Task<Launch?> GetLatest();

        Task<IEnumerable<Launch>> FilterAsync(string? name = null, DateTime? launchedFrom = null);

        Task Add(Launch launch);

        Task AddRange(IEnumerable<Launch> launches);
    }
}
