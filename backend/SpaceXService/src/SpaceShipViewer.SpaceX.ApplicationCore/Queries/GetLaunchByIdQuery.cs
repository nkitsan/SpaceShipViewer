using MediatR;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Queries
{
    public record GetLaunchByIdQuery(string Id) : IRequest<Launch?>;
}
