using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.DataAccess;

namespace WebApiTask1.Controllers
{
    [Route("api/station")]
    public class StationController :ControllerBase
    {
        private readonly IStationRepos StationRepos;
        public StationController(IStationRepos StationRepos)
        {
            this.StationRepos = StationRepos;
        }
        [HttpGet]
        public async Task<IActionResult> FetchStationData()
            {
                var station = await StationRepos.FetchStationData();
                return Ok(station);
            }
        [HttpGet]
        [Route("s1")]

        public async Task<IActionResult> GetStationId([FromBody]int Station_id)
        {
            var station = await StationRepos.GetStationId(Station_id);
            return Ok(station);
        }
        [HttpGet]
        [Route("s2")]

        public async Task<IActionResult> GetStationName([FromBody]int Station_name)
        {
            var station = await StationRepos.GetStationId(Station_name);
            return Ok(station);
        }
        [HttpPost]
  public IActionResult InsertStationDetails([FromBody]Station station)
        
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            StationRepos.InsertStationDetails(station);
            return CreatedAtAction(nameof(GetStationName), new { Station_id = station.Station_id }, station);
        }
        [HttpPut]
        public IActionResult UpdateStationData([FromBody]Station station)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            StationRepos.UpdateStationData(station);
            return Ok();
        }
    }
}
