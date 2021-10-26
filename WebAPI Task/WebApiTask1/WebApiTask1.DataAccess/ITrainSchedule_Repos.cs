using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTask1.DataAccess
{
    public interface ITrainSchedule_Repos
    {
        public Task<IEnumerable<TrainSchedule>> InsertScheduleTrains(TrainSchedule InsertData);
        public Task<IEnumerable<TrainSchedule>> FetchTrainlist(string stationname,string arrivaltime,string date);
        public Task<IEnumerable<Station>> FetchStationlist(string trainname,string arrivaltime,string date);
        public Task<IEnumerable<TrainSchedule>> FetchScheduleTrains();
        public Task<IEnumerable<TrainSchedule>> FetchBySpecifiedDate(string date);
        public void Update(string UpdateData);
    }
}
