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
    public class TrainSchedule_Repos : ITrainSchedule_Repos
    {
        private readonly IConfiguration _config;
        public TrainSchedule_Repos(IConfiguration Config)
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

        public async Task<IEnumerable<TrainSchedule>> FetchBySpecifiedDate(string date)
        {
            try
            {

                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = "select schedule_id,Train_id, Station_id, Arrival_time, Dep_time FROM TrainSchedule where date=@date";
                    return await dbConnection.QueryAsync<TrainSchedule>(sqlquery, new { date=date});
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<TrainSchedule>> FetchScheduleTrains()
        {
            try
            {

                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT schedule_id,Train_id, Station_id,Arrival_time,Dep_time,date FROM TrainSchedule";
                    return await dbConnection.QueryAsync<TrainSchedule>(sqlquery);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Station>> FetchStationlist(string trainname, string arrivaltime, string date)
        {
            try
            {

                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT * from STATION WHERE STATION.Station_id in 
                                      (SELECT Station_id FROM TrainSchedule where Train_id=(SELECT Train_id FROM 
                                       Trains WHERE Train_name=@Train_name)
                                       and Arrival_time=@Arrival_time and date=@date)";
                    return await dbConnection.QueryAsync<Station>(sqlquery, new { Train_name = trainname, Arrival_time = arrivaltime,date=date});
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<TrainSchedule>> FetchTrainlist(string stationname,string arrivaltime,string date)
        {
            try
            {

                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string sqlquery = @"SELECT Train_name from Trains WHERE Trains.Train_id in 
                                      (SELECT Train_id FROM TrainSchedule where Station_id = (SELECT Station_id FROM
                                       STATION WHERE Station_name = @Station_name)and 
                                       Arrival_time= @Arrival_time and date = @date)";
                    return await dbConnection.QueryAsync<TrainSchedule>(sqlquery, new { Station_name = stationname, Arrival_time = arrivaltime, date=date });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<TrainSchedule>>InsertScheduleTrains(TrainSchedule InsertData)
        {
            
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlquery = @"INSERT INTO TrainSchedule(schedule_id,Train_id,Station_id,Arrival_time,Dep_time,date)
                                      VALUES(@schedule_id,@Train_id,@Station_id,@Arrival_time,@Dep_time,@date)";
                return await dbConnection.QueryAsync<TrainSchedule>(sqlquery, new
                {
                    InsertData.schedule_id,
                    InsertData.Train_id,
                    InsertData.Station_id,
                    InsertData.Arrival_time,
                    InsertData.Dep_time,
                    InsertData.date

                }) ;
                return ((IEnumerable<TrainSchedule>)InsertData);
                
            }


        }
        public void Update(string UpdateData)
        {

            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string sqlquery = @"UPDATE TrainSchedule SET Train_id=@Train_id,Station_id=@Station_id,Arrival_time=@Arrival_time,
                                   Dep_time=@Dep_time,date=@date
                                   WHERE Train_id=@Train_id,Station_id=@Station_id,Arrival_time=@Arrival_time,
                                    Dep_time=@Dep_time,date=@date ";
                dbConnection.Execute(sqlquery, UpdateData);
            }
        }
    }
}
