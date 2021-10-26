using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTask1.DataAccess
{
    public interface IStationRepos
    {
      public void InsertStationDetails(Station station);
      public Task<IEnumerable<Station>> FetchStationData();
      public  Task<Station> GetStationId(int Station_id);
      public  Task<Station> GetStationName(string Station_name);
        public void UpdateStationData(Station station);
    }
}
