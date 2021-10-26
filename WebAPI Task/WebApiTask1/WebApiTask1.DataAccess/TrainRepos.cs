using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiTask1.DataAccess
{
    public class TrainRepos : ITrainRepos
    {
        protected readonly IConfiguration _config;
        public TrainRepos(IConfiguration config)
        {
            _config = config;
        }
        
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("TrainConnection"));
            }
        }

        public void Add(Train train)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"INSERT INTO Trains(Train_id,Train_name) VALUES(@Train_id,@Train_name)";
                    dbConnection.Execute(sqlquery, train);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Train>> GetTrainData()
        {
           
            
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT Train_id,Train_name FROM Trains";
                    return await dbConnection.QueryAsync<Train>(sqlquery);
                }
            

        }

        public async Task<Train> GetTrainId(int Train_id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT *  FROM Trains WHERE train_id= @Train_id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Train>(sqlquery, new { Train_id = Train_id });

                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<Train> GetTrainName(string Train_name)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT * FROM Trains WHERE Train_name=@Train_name";
                    return await dbConnection.QueryFirstOrDefaultAsync<Train>(sqlquery, new { Train_name = Train_name });
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Update(Train train)
        {
            
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"UPDATE Trains SET Train_name=@Train_name WHERE Train_id=@Train_id";
                    dbConnection.Execute(sqlquery, train);
                }
            
            
        }
    }
}
               
               

                    
         
