using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraderBot
{
    class SqliteDataAccess
    {

        //TODO: seperate databases for each trading pair
        //TODO: on new tradin pair found create db
        //TODO: auto fill latest data on load? or on watch list maybe
        //TODO: check for info before whole api query sent

        // 329 trading pairs * 6(granulars) = 1974
        // think 1974 tables is too much


        public static List<HistoricalData> LoadData(string tradingPair)
           

        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) 
            {
                var output = cnn.Query<HistoricalData>("select * from {TradingPair}", new DynamicParameters());
                return output.ToList();
            
            }


}

public static List<HistoricalData> SaveData()
{

}

private static string LoadConnectionString(string id = "default")
{
    return ConfigurationManager.ConnectionStrings[id].ConnectionString;

}







    }
}
