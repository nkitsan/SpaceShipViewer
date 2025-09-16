using Microsoft.AspNetCore.Mvc;
using SpaceShipViewer.SpaceX.ApplicationCore.Contracts;
using SpaceShipViewer.SpaceX.ApplicationCore.Entities;

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
        public async Task<Launch> GetLaunchById(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<Launch>> GetLaunchesByFilters()
        {
            throw new NotImplementedException();
        }
    }
}
