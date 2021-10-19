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
        // idbconnection
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("TrainDbConnection"));
            }
        }

        public void Add(Train train)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"INSERT INTO TrainDb(name,email,address,phone) VALUES(@name,@email,@address,@phone)";
                    dbConnection.Execute(sqlquery, train);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"DELETE FROM TrainDb WHERE Id=@Id";
                    dbConnection.Execute(sqlquery, new { id = id });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Train>> GetAllTrainData()
        {
            try
            {
                using(IDbConnection dbConnection=Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT id,name,email,address,phone  FROM TrainDb";
                     return await dbConnection.QueryAsync<Train>(sqlquery);
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Train> GetTrainId(int id)
        {
            try
            {
                using(IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT FROM TrainDb WHERE id= @id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Train>(sqlquery, new { id = id });

                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<Train> GetTrainName(string name)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT FROM TrainDb WHERE name=@name";
                    return await dbConnection.QueryFirstOrDefaultAsync<Train>(sqlquery, new { name = name });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Train train)
        {
            throw new NotImplementedException();
        }
    }
}
               
               

                    
         
