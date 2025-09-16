using AutoMapper;
using Oddity;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.Workers.Services
{
    public interface ILaunchesService
    {
        Task SaveLatestUpdates(CancellationToken cancellationToken = default);
    }

    public class LaunchesService : ILaunchesService
    {
        private readonly OddityCore _oddityCore;
        private readonly ILaunchRepository _launchRepository;
        private readonly IMapper _mapper;

        public LaunchesService(
            OddityCore oddityCore,
            ILaunchRepository launchRepository,
            IMapper mapper) 
        { 
            _oddityCore = oddityCore;
            _launchRepository = launchRepository;
            _mapper = mapper;
        }

        public async Task SaveLatestUpdates(CancellationToken cancellationToken = default)
        {
            var launchInfos = await _oddityCore.LaunchesEndpoint.GetAll().ExecuteAsync();
            var launches = _mapper.Map<IEnumerable<Launch>>(launchInfos);

            await _launchRepository.AddOrUpdateRangeAsync(launches, cancellationToken);
        }
    }
}
