using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.DataAccess;

namespace WebApiTask1.Controllers
{
    [Route("api/train")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainRepos trainRepos;

        public TrainController(ITrainRepos trainRepos)
        {
            this.trainRepos = trainRepos;
        }
        [HttpGet]
        public async Task<IActionResult> GetTraindata()
        {
            var train = await trainRepos.GetTrainData();
            return Ok(train);
        }
        [HttpGet]
        [Route ("s1")]

        public async Task<IActionResult> GetTrainId(int id)
        {
            var train = await trainRepos.GetTrainId(id);
            return Ok(train);
        }
        [HttpGet]
        [Route ("s2")]
        public async Task<IActionResult> GetTrainName(string name)
        {
            var train = await trainRepos.GetTrainName(name);
            return Ok(train);
        }
        [HttpPost]
        public IActionResult Add(Train train)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            trainRepos.Add(train);
            return CreatedAtAction(nameof(GetTrainName), new { id = train.id }, train);
        }
        [HttpPut]

        public IActionResult Update(Train train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            trainRepos.Update(train);
            return Ok();
        }
    }
}
