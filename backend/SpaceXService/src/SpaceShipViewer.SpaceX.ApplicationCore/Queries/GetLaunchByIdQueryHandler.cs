using MediatR;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Queries
{
    public class GetLaunchByIdQueryHandler : IRequestHandler<GetLaunchByIdQuery, Launch?>
    {
        private readonly ILaunchRepository _launchRepository;

        public GetLaunchByIdQueryHandler(ILaunchRepository launchRepository)
        {
            _launchRepository = launchRepository;
        }

        public async Task<Launch?> Handle(GetLaunchByIdQuery request, CancellationToken cancellationToken)
        {
            return await _launchRepository.GetAsync(request.Id, cancellationToken);
        }
    }
}
