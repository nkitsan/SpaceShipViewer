using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpaceShipViewer.SpaceX.ApplicationCore.Queries;
using SpaceShipViewer.SpaceX.RestAPI.DTOs;

namespace SpaceShipViewer.SpaceX.RestAPI.Controllers
{
    [Route("spacex/[controller]")]
    [ApiController]
    public class LaunchesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LaunchesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLaunchById(string id)
        {
            var launch = await _mediator.Send(new GetLaunchByIdQuery(id));

            if (launch is not null)
            {
                return Ok(_mapper.Map<LaunchDetailsDTO>(launch));
            }

            return BadRequest($"Launch with {id} was not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetLaunchesByFilters(string? name, DateTime? lauchFromDate, bool orderByDesc = false)
        {
            var launches = await _mediator.Send(new GetLauchesQuery(name, lauchFromDate, orderByDesc));

            return Ok(_mapper.Map<IEnumerable<LaunchDTO>>(launches));
        }
    }
}
