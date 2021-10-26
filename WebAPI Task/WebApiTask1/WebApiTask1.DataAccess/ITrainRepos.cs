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
        Task<Train> GetTrainId(int Train_id);
        Task<Train> GetTrainName(string Train_Name);       
        public void Update(Train train);
        Task<IEnumerable<Train>> GetTrainData();
    }
}
