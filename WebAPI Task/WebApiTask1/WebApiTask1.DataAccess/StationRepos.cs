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
    public class StationRepos : IStationRepos
    {
        private readonly IConfiguration _config;
        public StationRepos(IConfiguration Config)
        {
            _config = Config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("TrainConnection"));
            }
        }

        public async Task<IEnumerable<Station>> FetchStationData()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlquery = @"SELECT Station_id,Station_name FROM STATION";
                return await dbConnection.QueryAsync<Station>(sqlquery);
            }
        }

        public async Task<Station> GetStationId(int Station_id)
        {

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlquery = @"SELECT *  FROM STATION WHERE Station_id= @Station_id";
                return await dbConnection.QueryFirstOrDefaultAsync<Station>(sqlquery, new { Station_id = Station_id });
            }
        }

        public async Task<Station> GetStationName(string Station_name)
        {

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                string sqlquery = @"SELECT *  FROM STATION WHERE Station_name= @Station_name";
                return await dbConnection.QueryFirstOrDefaultAsync<Station>(sqlquery, new { Station_name =Station_name });
            }
        }

        public void InsertStationDetails(Station station)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlquery = @"INSERT INTO STATION(Station_id,Station_name) VALUES(@Station_id,@Station_name)";
                dbConnection.Execute(sqlquery, station);
            }
        }

        public void UpdateStationData(Station station)
        {

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlquery = @"UPDATE STATION SET Station_name=@Station_name WHERE Station_id=@Station_id";
                dbConnection.Execute(sqlquery, station);
            }

        }
    }
}

