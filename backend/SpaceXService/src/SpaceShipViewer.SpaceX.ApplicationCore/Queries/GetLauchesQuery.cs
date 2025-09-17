using MediatR;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

namespace SpaceShipViewer.SpaceX.ApplicationCore.Queries
{
    public record GetLauchesQuery(string? Name, DateTime? DateUTC, bool orderByDesc) : IRequest<IEnumerable<Launch>>;
}
