using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTask1.Dapper
{
    class TrainSchedule
    {
        public int schedule_id { get; set; }
        public int Train_id { get; set; }
        public int Station_id { get; set; }
        public string Arrival_time { get; set; }

        public string Dep_time { get; set; }
        public string date { get; set; }
    }
}
