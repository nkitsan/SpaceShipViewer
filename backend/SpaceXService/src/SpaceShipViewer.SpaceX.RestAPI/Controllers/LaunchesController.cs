using Microsoft.AspNetCore.Mvc;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;
using SpaceShipViewer.SpaceX.RestAPI.DTOs;

namespace SpaceShipViewer.SpaceX.RestAPI.Controllers
{
    [Route("spacex/[controller]")]
    [ApiController]
    public class LaunchesController : ControllerBase
    {
        public LaunchesController() 
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<LaunchDetailsDTO> GetLaunchById(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<LaunchDTO>> GetLaunchesByFilters()
        {
            throw new NotImplementedException();
        }
    }
}
