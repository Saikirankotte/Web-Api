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
        //It can be used whenever you want to execute something in parallel.
        //Asynchronous implementation is easy in a task, using’ async’ and ‘await’ keywords.
        public async Task<IActionResult> GetTraindata()
        //    ActionResult Executes the result operation of the action method asynchronously. This method
        //             is called by MVC to process the result of an action method.
        {
            var train = await trainRepos.GetTrainData();
            return Ok(train);
        }
        [HttpGet]
        [Route ("t1")]

        public async Task<IActionResult> GetTrainId(int Train_id)
        {
            var train = await trainRepos.GetTrainId(Train_id);
            return Ok(train);
        }
        [HttpGet]
        [Route ("t2")]
        public async Task<IActionResult> GetTrainName(string Train_name)
        {
            var train = await trainRepos.GetTrainName(Train_name);
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
            return CreatedAtAction(nameof(GetTrainName), new { Train_id = train.Train_id }, train);
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
