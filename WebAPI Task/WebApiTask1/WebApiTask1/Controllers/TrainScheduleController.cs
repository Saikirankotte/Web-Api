using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.DataAccess;

namespace WebApiTask1.Controllers
{
    [Route("api/TrainsOnGivenTime")]
    [ApiController]
    public class TrainScheduleController : ControllerBase
    {
        private readonly ITrainSchedule_Repos scheduletrain;
        public TrainScheduleController(ITrainSchedule_Repos scheduletrain)
        {
            this.scheduletrain = scheduletrain;
        }
        [HttpGet]
        public async Task<IEnumerable<TrainSchedule>> FetchScheduleTrains(string data)
       
        {
            return await scheduletrain.FetchScheduleTrains();
            return (IEnumerable<TrainSchedule>)Ok(data);
            
        }
        [HttpGet]
        [Route("d1")]
        public async Task<IEnumerable<TrainSchedule>> FetchBySpecifiedDate( string date)

        {
            return await scheduletrain.FetchBySpecifiedDate(date);

        }
        [HttpGet]
        [Route("d2")]
        public async Task<IEnumerable<TrainSchedule>> FetchTrainlist(string stationname,string arrivaltime,string date)

        {
            return await scheduletrain.FetchTrainlist(stationname, arrivaltime, date);

        }
        [Route("d3")]
        public async Task<IEnumerable<Station>> FetchStationlist(string trainnname, string arrivaltime, string date)

        {
            return await scheduletrain.FetchStationlist(trainnname, arrivaltime, date);

        }
        [HttpPost]
        public async Task<IEnumerable<TrainSchedule>> InsertScheduleTrains([FromBody]TrainSchedule InserData)
        {
            return  await scheduletrain.InsertScheduleTrains(InserData);
        }
        [HttpPut]
        public IActionResult Update([FromBody] string UpdateData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            scheduletrain.Update(UpdateData);
            return Ok();
        }
    }
}
