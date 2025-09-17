using MediatR;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Queries
{
    public class GetLauchesQueryHandler : IRequestHandler<GetLauchesQuery, IEnumerable<Launch>>
    {
        private readonly ILaunchRepository _launchRepository;

        public GetLauchesQueryHandler(ILaunchRepository launchRepository)
        {
            _launchRepository = launchRepository;
        }

        public async Task<IEnumerable<Launch>> Handle(GetLauchesQuery request, CancellationToken cancellationToken)
        {
            return await _launchRepository.FilterAsync(request.Name, request.DateUTC, cancellationToken);
        }
    }
}
