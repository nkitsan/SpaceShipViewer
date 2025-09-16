using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;
using SpaceShipViewer.SpaceX.Infrastructure.Repositories;
using SpaceShipViewer.SpaceX.RestAPI.DTOs;

namespace SpaceShipViewer.SpaceX.RestAPI.Controllers
{
    [Route("spacex/[controller]")]
    [ApiController]
    public class LaunchesController : ControllerBase
    {
        private readonly ILaunchRepository _launchRepository;
        private readonly IMapper _mapper;

        public LaunchesController(ILaunchRepository launchRepository,
            IMapper mapper) 
        {
            _launchRepository = launchRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLaunchById(string id)
        {
            var launch = await _launchRepository.GetAsync(id);

            if (launch is not null)
            {
                return Ok(_mapper.Map<LaunchDetailsDTO>(launch));
            }

            return BadRequest($"Launch with {id} was not found");
        }

        [HttpGet]
        public async Task<IActionResult> GetLaunchesByFilters()
        {
            var launches = await _launchRepository.FilterAsync();

            return Ok(_mapper.Map<IEnumerable<LaunchDTO>>(launches));
        }
    }
}
