using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTask1.DataAccess
{
    public interface ITrainRepos
    {
        Task<IEnumerable<Train>> GetAllTrainData();
        Task<Train> GetTrainId(int id);
        Task<Train> GetTrainName(string name);
        void Add(Train train);
        void Update(Train  train);
        Task<IEnumerable<Train>> Get();
    }
}
