using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTask1.DataAccess;

namespace WebApiTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        private readonly ITrainRepos trainRepos;

        public TrainController(ITrainRepos trainRepos)
        {
            this.trainRepos = trainRepos;
        }
        [HttpGet]
        public Task<IEnumerable<Train>> GetAllTrainData()
        {
            return trainRepos.Get();
        }
        [HttpPost]
        public Task<IEnumerable<Train>> Add()
        {
            return trainRepos.Get();
        }
    }
}
