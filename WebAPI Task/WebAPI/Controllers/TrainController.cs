using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class TrainController : ApiController
    {
        public IHttpActionResult GetTrainData()
        {
            IList<TrainModel> Train = null;
            using (var x = new WebApi_dbEntities1())
            {
                Train = x.TrainDbs.Select(t => new TrainModel()
                {
                    Id = t.id,
                    Name = t.name,
                    Email = t.email,
                    Address = t.address,
                    Phone = t.phone
                }).ToList<TrainModel>();
            }
            if (Train.Count == 0)
                return NotFound();
            return Ok(Train);
        }
        public IHttpActionResult PostTrainData(TrainModel train)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data.Please Recheck");
            using (var x = new WebApi_dbEntities1())
            {
                x.TrainDbs.Add(new TrainDb()
                {
                    name = train.Name,
                    email = train.Email,
                    address = train.Address,
                    phone = train.Phone
                });
                x.SaveChanges();

            }
            return Ok();
        }
        public IHttpActionResult PutTrainData(TrainModel train)
        {
            if (!ModelState.IsValid)
                return BadRequest("this is invalid model. Please Recheck!");
            using(var x = new WebApi_dbEntities1())
            {
                var ExistingTrainData = x.TrainDbs.Where(t => t.id == train.Id)
                    .FirstOrDefault<TrainDb>();
                if (ExistingTrainData != null)
                {
                    ExistingTrainData.name = train.Name;
                    ExistingTrainData.address = train.Address;
                    ExistingTrainData.phone = train.Phone;
                    x.SaveChanges();
                }
                else
                    return NotFound();
            }
            return Ok();
        }
        public IHttpActionResult DeleteTrainData(int id)
        {
            if (id <= 0)
                return BadRequest("Please enter valid Train Id");
            using(var x= new WebApi_dbEntities1())
            {
                var train = x.TrainDbs.Where(t => t.id==id).FirstOrDefault();
                x.Entry(train).State = System.Data.Entity.EntityState.Deleted;
                x.SaveChanges();

            }
            return Ok();
        }



    }
}
