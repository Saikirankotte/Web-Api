using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTask1.DataAccess
{
    public interface ITrainRepos
    {
        void Add(Train train);
        Task<Train> GetTrainId(int id);
        Task<Train> GetTrainName(string name);       
        public void Update(Train train);
        Task<IEnumerable<Train>> GetTrainData();
    }
}
