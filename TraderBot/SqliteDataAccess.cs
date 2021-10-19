using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace TraderBot
{
    internal class SqliteDataAccess
    {
        //TODO: seperate databases for each trading pair
        //TODO: on new tradin pair found create db
        //TODO: auto fill latest data on load? or on watch list maybe
        //TODO: check for info before whole api query sent

        // 329 trading pairs * 6(granulars) = 1974
        // think 1974 tables is too much

        public static List<HistoricalData> LoadData(string tradingPair, int timeframe)
        {
            string tableName = DbTableNameConstructor(tradingPair, timeframe);

            string query = "Select * from " + tableName;


            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HistoricalData>(query, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<HistoricalData> SaveData(string tradingPair, int timeframe)

        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<HistoricalData>("select * from {tradingPair}", new DynamicParameters());
                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private static string DbTableNameConstructor(string tradingPair, int timeframe)
        {
            string stringtimefame = "Hourly";

            if (timeframe == 60)
            {
                stringtimefame = "Minuite";
            }

            string tableName = tradingPair + " " + stringtimefame;
            Console.WriteLine(tableName);

            return string.Empty;
        }
    }
}